using FinancialChat.Consumer.DTOs;
using FinancialChat.Consumer.Interfaces;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
using System.Text.Json;

namespace FinancialChat.Consumer
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly AppSettings _appSettings;
        private readonly IChatGateway _chatGateway;

        public Worker(ILogger<Worker> logger,
            AppSettings appSettings,
            IChatGateway chatGateway)
        {
            _logger = logger;
            _appSettings = appSettings;
            _chatGateway = chatGateway;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            try
            {
                var factory = new ConnectionFactory()
                {
                    Uri = new Uri(_appSettings.QueueSettings.ConnectionString)
                };
                using var connection = factory.CreateConnection();
                using var channel = connection.CreateModel();

                channel.QueueDeclare(queue: _appSettings.QueueSettings.QueueName,
                                    durable: false,
                                    exclusive: false,
                                    autoDelete: false,
                                    arguments: null);

                var consumer = new EventingBasicConsumer(channel);
                consumer.Received += ConsumerReceived;
                channel.BasicConsume(queue: _appSettings.QueueSettings.QueueName,
                    autoAck: true,
                    consumer: consumer);

                while (!stoppingToken.IsCancellationRequested)
                {
                    _logger.LogInformation(
                        $"Worker active: {DateTime.Now:yyyy-MM-dd HH:mm:ss}");
                    await Task.Delay(_appSettings.IntervalWorkerActive, stoppingToken);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error trying to process the message.");
                throw;
            }
        }

        private async void ConsumerReceived(
            object sender, BasicDeliverEventArgs e)
        {
            var message = Encoding.UTF8.GetString(e.Body.ToArray());

            _logger.LogInformation(
                $"[New message from bot | {DateTime.Now:yyyy-MM-dd HH:mm:ss}] " +
                message);

            var requestDto = JsonSerializer.Deserialize<MessageRequestDto>(message);
            var url = _appSettings.ChatApiUrl + _appSettings.SendMethod;

            await _chatGateway.SendMessageAsyc(url, requestDto);
        }
    }
}