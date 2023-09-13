using MyBlogAPI.Models.Contents;
using MyBlogAPI.Services.Interfaces;

namespace MyBlogAPI.Services;

public class ContentService : IContentService
{
    private readonly HttpClient _httpClient;


    public ContentService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<ContentDto>> GetContentsAsync()
    {
        var response = await _httpClient.GetAsync("contents");
        if (!response.IsSuccessStatusCode)
        {
            return null;
        }

        return new List<ContentDto>();

    }
}
