using System.Net;
using System.Text;
using AutoMapper;
using MongoDB.Driver;
using Newtonsoft.Json;
using RabbitMQ.Client;
using ReactionAPI.Models;
using ReactionAPI.Models.Dtos;
using ReactionAPI.Models.Settings;
using SharedLib.Dtos;

namespace ReactionAPI.Services;

public class ReactionService : IReactionService
{
    private readonly IMongoCollection<Like> _likeCollection;
    private readonly IMapper _mapper;
    private readonly ConnectionFactory _connectionFactory;
    private IConnection _connection;
    private IModel _channel;
    public static string ExchangeName = "LikeExchange";
    public static string RoutingComment = "like-route-send";
    public static string QueueName = "queue-like-send";

    public ReactionService(IDatabaseSettings databaseSettings, IMapper mapper, ConnectionFactory connectionFactory)
    {
        var client = new MongoClient(databaseSettings.ConnectionString);
        var database = client.GetDatabase(databaseSettings.DatabaseName);
        _likeCollection = database.GetCollection<Like>(databaseSettings.ContentCollectionName);
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

    public async Task<Response<NoContent>> Like(LikeCreateDto likeCreateDto)
    {
        var content = _mapper.Map<Like>(likeCreateDto);
        await _likeCollection.InsertOneAsync(content);
        LikeCreatedEvent likeCreatedEvent = new LikeCreatedEvent();
        likeCreatedEvent.ContentId = likeCreateDto.ContentId;
        likeCreatedEvent.User = likeCreateDto.User;
        likeCreatedEvent.Id = likeCreatedEvent.Id;
        Publish(likeCreatedEvent);
        return Response<NoContent>.Success((int)HttpStatusCode.OK);
    }

    public void Publish(LikeCreatedEvent likeCreatedEvent)
    {
        var channel = Connect();
        var bodyString = JsonConvert.SerializeObject(likeCreatedEvent);
        var bodyByte = Encoding.UTF8.GetBytes(bodyString);
        var properties = channel.CreateBasicProperties();
        properties.Persistent = true;
        channel.BasicPublish(exchange: ExchangeName, routingKey: RoutingComment, basicProperties: properties, body: bodyByte);
    }
}
