using Financial.Bot.API.Interfaces;
using Financial.Core.ViewModels;
using RabbitMQ.Client;
using System.Text;
using System.Text.Json;

namespace Financial.Bot.API.Infra
{
    public class MessageBroker : IMessageBroker
    {
        private readonly ILogger<MessageBroker> _logger;
        public MessageBroker(ILogger<MessageBroker> logger)
        {
            _logger = logger;
        }
        public void Publish<T>(T message, MessageBrokerSettings messageBroker)
        {
            try
            {
                var factory = new ConnectionFactory() { Uri = new Uri(messageBroker.ConnectionString) };
                using var connection = factory.CreateConnection();
                using var channel = connection.CreateModel();
                channel.QueueDeclare(
                                     queue: messageBroker.Queue,
                                     durable: false,
                                     exclusive: false,
                                     autoDelete: false,
                                     arguments: null);

                var json = JsonSerializer.Serialize(message);
                var body = Encoding.UTF8.GetBytes(json);

                _logger.LogInformation("Publishing {Message} into {Queue} - {RoutingKey}", json, messageBroker.Queue, messageBroker.RoutingKey);

                channel.BasicPublish(
                                     exchange: string.Empty,
                                     routingKey: messageBroker.RoutingKey,
                                     basicProperties: null,
                                     body: body);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error trying to publish message into {Hostname}", messageBroker.ConnectionString);
                throw;
            }
        }
    }
}
