using ContentAPI.Models;
using ContentAPI.Models.Dtos;
using RabbitMQ.Client;
using SharedLib.Dtos;

namespace ContentAPI.Services;

public interface IContentService
{
    Task<Response<List<ContentDto>>> GetAll();
    Task<Response<ContentDto>> GetById(string id);
    Task<Response<List<ContentDto>>> GetAllByCategoryId(string id);
    Task<Response<List<ContentDto>>> GetAllByUserId(string id);
    Task<Response<string>> Create(ContentCreateDto contentCreateDto);
    Task<Response<NoContent>> Update(ContentUpdateDto contentUpdateDto);
    Task<Response<NoContent>> UpdateComment(Comment comment);
    Task<Response<NoContent>> UpdateLike(Like like);
    Task<Response<NoContent>> Delete(string id);

}
