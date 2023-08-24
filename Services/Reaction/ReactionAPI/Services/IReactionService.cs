using ReactionAPI.Models.Dtos;
using SharedLib.Dtos;

namespace ReactionAPI.Services;

public interface IReactionService
{
    Task<Response<NoContent>> Like(LikeCreateDto likeCreateDto);
}
