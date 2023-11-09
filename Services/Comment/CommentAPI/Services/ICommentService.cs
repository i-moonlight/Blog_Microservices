using CommentAPI.Models.Dtos;
using SharedLib.Dtos;

namespace CommentAPI.Services;

public interface ICommentService
{
    Task<Response<List<CommentDto>>> GetAll();
    Task<Response<List<CommentDto>>> GetAllByContentId(string contentId);
    Task<Response<CommentDto>> GetById(string id);
    Task<Response<NoContent>> Create(CommentCreateDto commentCreateDto);
    Task<Response<NoContent>> Update(CommentUpdateDto commentUpdateDto);
    Task<Response<NoContent>> Delete(string id);
}
