using RabbitMQ.Client;
using ReactionAPI.Models.Dtos;
using SharedLib.Dtos;

namespace ReactionAPI.Services;

public interface IReactionService
{
    Task<Response<NoContent>> Like(LikeCreateDto likeCreateDto);
    IModel Connect();
    void Publish(LikeCreatedEvent likeCreatedEvent);
}
