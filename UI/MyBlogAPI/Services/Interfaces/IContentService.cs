namespace MyBlogAPI.Services.Interfaces;
using MyBlogAPI.Models.Contents;
public interface IContentService
{
    Task<List<ContentDto>> GetContentsAsync();
}
