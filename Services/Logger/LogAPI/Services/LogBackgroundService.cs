using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using LogAPI.Models;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace ContentAPI.Services
{
    public class LogBackgroundService : BackgroundService
    {

        private readonly ConnectionFactory _connectionFactory;
        private IConnection _connection;
        private IModel _channel;
        public static string ExchangeName = "LogExchange";
        public static string RoutingLog = "log-route-send";
        public static string QueueName = "queue-log-send";
        private readonly IServiceProvider _serviceProvider;
        private readonly ILogger<LogBackgroundService> _logger;

        public LogBackgroundService(ConnectionFactory connectionFactory, IServiceProvider serviceProvider, ILogger<LogBackgroundService> logger)
        {
            _connectionFactory = connectionFactory;
            _channel = Connect();
            _serviceProvider = serviceProvider;
            _logger = logger;
        }


        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var channel = Connect();
                var consumer = new EventingBasicConsumer(channel);
                consumer.Received += (model, ea) =>
                {
                    var logCreatedEvent = JsonSerializer.Deserialize<LogCreatedEvent>(Encoding.UTF8.GetString(ea.Body.ToArray()));
                    var logJson = JsonSerializer.Serialize(logCreatedEvent);
                    _logger.LogInformation(logJson);
                };

                channel.BasicConsume(queue: QueueName, autoAck: true, consumer: consumer);

                while (!stoppingToken.IsCancellationRequested)
                {
                    await Task.Delay(1000, stoppingToken);
                }
            }
        }

        public IModel Connect()
        {
            _connection = _connectionFactory.CreateConnection();
            if (_channel is { IsOpen: true })
            {
                return _channel;
            }
            _channel = _connection.CreateModel();
            _channel.ExchangeDeclare(ExchangeName, type: "direct", true, false);
            _channel.QueueDeclare(QueueName, durable: true, exclusive: false, false, null);
            _channel.QueueBind(exchange: ExchangeName, queue: QueueName, routingKey: RoutingLog);
            return _channel;
        }
    }
}