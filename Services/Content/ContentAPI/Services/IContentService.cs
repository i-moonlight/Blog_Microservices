using ContentAPI.Models.Dtos;
using SharedLib.Dtos;

namespace ContentAPI.Services;

public interface IContentService
{
    Task<Response<List<ContentDto>>> GetAll();
    Task<Response<ContentDto>> GetById(string id);
    Task<Response<NoContent>> Create(ContentCreateDto contentCreateDto);
    Task<Response<NoContent>> Update(ContentUpdateDto contentUpdateDto);
    Task<Response<NoContent>> Delete(string id);

}
