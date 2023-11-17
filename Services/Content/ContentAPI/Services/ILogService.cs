using ContentAPI.Models.Dtos;
using RabbitMQ.Client;

namespace CommentAPI.Services;

public interface ILogService
{
    void Publish(LogCreatedEvent logCreatedEvent);
}
