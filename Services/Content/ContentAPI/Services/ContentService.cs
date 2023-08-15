using System.Net;
using ContentAPI.Models;
using ContentAPI.Models.Dtos;
using ContentAPI.Models.Settings;
using MongoDB.Driver;
using SharedLib.Dtos;

namespace ContentAPI.Services;

public class ContentService : IContentService
{
    private readonly IMongoCollection<Content> _contentCollection;

    public ContentService(IDatabaseSettings databaseSettings)
    {
        var client = new MongoClient(databaseSettings.ConnectionString);
        var database = client.GetDatabase(databaseSettings.DatabaseName);
        _contentCollection = database.GetCollection<Content>(databaseSettings.ContentCollectionName);
    }

    public async Task<Response<NoContent>> Create(ContentCreateDto contentCreateDto)
    {
        Content content = new Content
        {
            Title = contentCreateDto.Title,
            Text = contentCreateDto.Text,
            AuthorId = "1235",
            ImageUrl = ".png"
        };

        await _contentCollection.InsertOneAsync(content);

        return Response<NoContent>.Success((int)HttpStatusCode.OK);
    }

    public Task<Response<NoContent>> Delete(string id)
    {
        throw new NotImplementedException();
    }

    public Task<Response<List<ContentDto>>> GetAll()
    {
        return Task.FromResult(new Response<List<ContentDto>>());
    }

    public Task<Response<ContentDto>> GetById(string id)
    {
        throw new NotImplementedException();
    }

    public Task<Response<NoContent>> Update(ContentUpdateDto contentUpdateDto)
    {
        throw new NotImplementedException();
    }
}
