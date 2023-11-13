using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using AutoMapper;
using ContentAPI.Models;
using ContentAPI.Models.Dtos;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace ContentAPI.Services
{
    public class ReactionBackgroundService : BackgroundService
    {

        private readonly ConnectionFactory _connectionFactory;
        private IConnection _connection;
        private IModel _channel;
        public static string ExchangeName = "LikeExchange";
        public static string RoutingComment = "like-route-send";
        public static string QueueName = "queue-like-send";
        private readonly IServiceProvider _serviceProvider;
        private readonly IContentService _contentService;
        private readonly IMapper _mapper;

        public ReactionBackgroundService(ConnectionFactory connectionFactory, IServiceProvider serviceProvider, IContentService contentService, IMapper mapper)
        {
            _connectionFactory = connectionFactory;
            _channel = Connect();
            _serviceProvider = serviceProvider;
            _contentService = contentService;
            _mapper = mapper;
        }


        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var channel = Connect();
                var consumer = new EventingBasicConsumer(channel);
                consumer.Received += (model, ea) =>
                {
                    var likeCreatedEvent = JsonSerializer.Deserialize<LikeCreatedEvent>(Encoding.UTF8.GetString(ea.Body.ToArray()));
                    var like=_mapper.Map<Like>(likeCreatedEvent);
                    _contentService.UpdateLike(like);
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
            _channel.QueueBind(exchange: ExchangeName, queue: QueueName, routingKey: RoutingComment);
            return _channel;
        }
    }
}