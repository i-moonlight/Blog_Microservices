using AutoMapper;
using CommentAPI.Models;
using CommentAPI.Models.Dtos;
using Couchbase.Extensions.DependencyInjection;
using SharedLib.Dtos;
using System.Linq;

namespace CommentAPI.Services;

public class CommentService : ICommentService
{
    private readonly IBucketProvider _bucketProvider;
    private readonly string _bucketName;
    private readonly IMapper _mapper;
    public CommentService(IBucketProvider bucketProvider, IConfiguration configuration, IMapper mapper)
    {
        _bucketProvider = bucketProvider;
        _bucketName = configuration.GetSection("Couchbase").GetSection("BucketName").Value;
        _mapper = mapper;
    }
    public async Task<Response<NoContent>> Create(CommentCreateDto commentCreateDto)
    {
        var bucket = await _bucketProvider.GetBucketAsync(_bucketName);
        var collection = await bucket.DefaultCollectionAsync();
        var comment = new Comment
        {
            Id = Guid.NewGuid().ToString(),
            Text = commentCreateDto.Text
        };
        await collection.InsertAsync<Comment>(comment.Id, comment);
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

    public async Task<Response<CommentDto>> GetById(string id)
    {
        var bucket = await _bucketProvider.GetBucketAsync(_bucketName);
        var result = await bucket.DefaultCollection().GetAsync(id);
        var comment = result.ContentAs<Comment>();
        var commentDto = _mapper.Map<CommentDto>(comment);
        return Response<CommentDto>.Success(commentDto, 200);
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
