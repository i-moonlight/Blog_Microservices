using AutoMapper;
using CommentAPI.Models;
using CommentAPI.Models.Dtos;
using Couchbase.Extensions.DependencyInjection;
using Couchbase.Search;
using Newtonsoft.Json;
using RabbitMQ.Client;
using SharedLib.Dtos;
using System.Linq;
using System.Text;

namespace CommentAPI.Services;

public class CommentService : ICommentService
{
    private readonly IBucketProvider _bucketProvider;
    private readonly string _bucketName;
    private readonly IMapper _mapper;
    private readonly ConnectionFactory _connectionFactory;
    private IConnection _connection;
    private IModel _channel;
    public static string ExchangeName = "CommentExchange";
    public static string RoutingComment = "comment-route-send";
    public static string QueueName = "queue-comment-send";
    public CommentService(IBucketProvider bucketProvider, IConfiguration configuration, IMapper mapper, ConnectionFactory connectionFactory)
    {
        _bucketProvider = bucketProvider;
        _bucketName = configuration.GetSection("Couchbase").GetSection("BucketName").Value;
        _mapper = mapper;
        _connectionFactory = connectionFactory;
    }

    public IModel Connect()
    {
        _connection = _connectionFactory.CreateConnection();
        if (_channel is { IsOpen: true })
        {
            return _channel;
        }
        _channel = _connection.CreateModel();
        _channel.ExchangeDeclare(ExchangeName, type: "direct", true, false);
        _channel.QueueDeclare(QueueName, durable: true, exclusive: false, false, null);
        _channel.QueueBind(exchange: ExchangeName, queue: QueueName, routingKey: RoutingComment);
        return _channel;
    }

    public async Task<Response<NoContent>> Create(CommentCreateDto commentCreateDto)
    {
        var bucket = await _bucketProvider.GetBucketAsync(_bucketName);
        var collection = await bucket.DefaultCollectionAsync();
        var comment = new Comment
        {
            Id = Guid.NewGuid().ToString(),
            ContentId = commentCreateDto.ContentId,
            Text = commentCreateDto.Text,
            User = commentCreateDto.User
        };
        await collection.InsertAsync<Comment>(comment.Id, comment);

        CommentCreatedEvent commentCreatedEvent=new();
        commentCreatedEvent.Text=comment.Text;
        commentCreatedEvent.User=comment.User;
        commentCreatedEvent.ContentId=comment.ContentId;
        commentCreatedEvent.Id=comment.Id;
        Publish(commentCreatedEvent);
        return Response<NoContent>.Success(200);
    }

    public async Task<Response<NoContent>> Delete(string id)
    {
        var bucket = await _bucketProvider.GetBucketAsync(_bucketName);
        var collection = await bucket.DefaultCollectionAsync();
        await collection.RemoveAsync(id);
        return Response<NoContent>.Success(200);
    }

    public async Task<Response<List<CommentDto>>> GetAll()
    {
        var cluster = (await _bucketProvider.GetBucketAsync(_bucketName)).Cluster;
        var query = "select c.* from `Comment` c";
        var result = await cluster.QueryAsync<Comment>(query);
        var comments = await result.ToListAsync();
        var commentDtos = _mapper.Map<List<CommentDto>>(comments);

        return Response<List<CommentDto>>.Success(commentDtos, 200);
    }

    public async Task<Response<List<CommentDto>>> GetAllByContentId(string contentId)
    {
        var cluster = (await _bucketProvider.GetBucketAsync(_bucketName)).Cluster;
        var query = $"select c.* from `Comment` c where c.contentId='{contentId}'";
        var result = await cluster.QueryAsync<Comment>(query);
        var comments = await result.ToListAsync();
        var commentDtos = _mapper.Map<List<CommentDto>>(comments);

        return Response<List<CommentDto>>.Success(commentDtos, 200);
    }

    public async Task<Response<CommentDto>> GetById(string id)
    {
        var bucket = await _bucketProvider.GetBucketAsync(_bucketName);
        var result = await bucket.DefaultCollection().GetAsync(id);
        var comment = result.ContentAs<Comment>();
        var commentDto = _mapper.Map<CommentDto>(comment);
        return Response<CommentDto>.Success(commentDto, 200);
    }

    public void Publish(CommentCreatedEvent commentCreatedEvent)
    {
        var channel = Connect();
        var bodyString = JsonConvert.SerializeObject(commentCreatedEvent);
        var bodyByte = Encoding.UTF8.GetBytes(bodyString);
        var properties = channel.CreateBasicProperties();
        properties.Persistent = true;
        channel.BasicPublish(exchange: ExchangeName, routingKey: RoutingComment, basicProperties: properties, body: bodyByte);
    }

    public async Task<Response<NoContent>> Update(CommentUpdateDto commentUpdateDto)
    {
        var bucket = await _bucketProvider.GetBucketAsync(_bucketName);
        var collection = await bucket.DefaultCollectionAsync();
        var newComment = _mapper.Map<Comment>(commentUpdateDto);
        await collection.ReplaceAsync(commentUpdateDto.Id, newComment);
        return Response<NoContent>.Success(200);
    }
}
