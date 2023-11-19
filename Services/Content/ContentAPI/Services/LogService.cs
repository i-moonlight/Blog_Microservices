using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using ContentAPI.Models.Dtos;
using RabbitMQ.Client;

namespace ContentAPI.Services
{
    public class LogService : ILogService
    {
        private readonly ConnectionFactory _connectionFactory;
        private readonly string _exchangeName = "LogExchange";
        private readonly string _routingKey = "log-route-send";
        public readonly string _queueName = "queue-log-send";

        public LogService(ConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory ?? throw new ArgumentNullException(nameof(connectionFactory));
        }

        public void Publish(LogCreatedEvent logEvent)
        {
            using (var connection = _connectionFactory.CreateConnection())
            {
                using (var channel = connection.CreateModel())
                {
                    channel.ExchangeDeclare(exchange: _exchangeName, type: ExchangeType.Direct, durable: true);
                    channel.QueueDeclare(_queueName, durable: true, exclusive: false, false, null);
                    channel.QueueBind(exchange: _exchangeName, queue: _queueName, routingKey: _routingKey);
                    var bodyString = JsonSerializer.Serialize(logEvent);
                    var bodyBytes = Encoding.UTF8.GetBytes(bodyString);

                    var properties = channel.CreateBasicProperties();
                    properties.Persistent = true;

                    channel.BasicPublish(exchange: _exchangeName, routingKey: _routingKey, basicProperties: properties, body: bodyBytes);
                    Console.WriteLine("Log published to RabbitMQ: {0}", bodyString);
                }
            }
        }
    }
}