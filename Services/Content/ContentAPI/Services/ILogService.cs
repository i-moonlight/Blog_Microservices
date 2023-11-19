using ContentAPI.Models.Dtos;
using RabbitMQ.Client;

namespace ContentAPI.Services;

public interface ILogService
{
    void Publish(LogCreatedEvent logCreatedEvent);
}
