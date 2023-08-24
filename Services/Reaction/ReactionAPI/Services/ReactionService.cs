using System.Net;
using AutoMapper;
using MongoDB.Driver;
using ReactionAPI.Models;
using ReactionAPI.Models.Dtos;
using ReactionAPI.Models.Settings;
using SharedLib.Dtos;

namespace ReactionAPI.Services;

public class ReactionService : IReactionService
{
    private readonly IMongoCollection<Like> _likeCollection;
    private readonly IMapper _mapper;

    public ReactionService(IDatabaseSettings databaseSettings, IMapper mapper)
    {
        var client = new MongoClient(databaseSettings.ConnectionString);
        var database = client.GetDatabase(databaseSettings.DatabaseName);
        _likeCollection = database.GetCollection<Like>(databaseSettings.ContentCollectionName);
        _mapper = mapper;
    }

    public async Task<Response<NoContent>> Like(LikeCreateDto likeCreateDto)
    {
        var content= _mapper.Map<Like>(likeCreateDto);
        await _likeCollection.InsertOneAsync(content);
        return Response<NoContent>.Success((int)HttpStatusCode.OK);
    }
}
