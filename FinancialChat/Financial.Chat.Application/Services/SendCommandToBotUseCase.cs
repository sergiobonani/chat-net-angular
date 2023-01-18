using AutoMapper;
using Financial.Chat.Application.Interfaces.UseCases;
using Financial.Chat.Domain.Dtos;
using Financial.Chat.Domain.Interfaces;
using Microsoft.Extensions.Logging;

namespace Financial.Chat.Application.Services
{
    public class SendCommandToBotUseCase : ISendCommandToBotUseCase
    {
        private readonly AppSettings _settings;
        private readonly IBotGateway _botGateway;
        private readonly ILogger<SendCommandToBotUseCase> _logger;
        public SendCommandToBotUseCase(AppSettings appSettings,
            IBotGateway botGateway,
            ILogger<SendCommandToBotUseCase> logger)
        {
            _settings = appSettings;
            _botGateway = botGateway;
            _logger = logger;
        }
        public async Task<string> ExecuteAsync(MessageRequestDto message)
        {
            var responseMessage = string.Empty;
            if (_settings.AllowedBotCommands.Any(x => message.Message.StartsWith(x.Command)))
            {
                 //var botCommand = _mapper.Map<BotCommandRequestDto>(message);
                await _botGateway.SendCommandAsync(_settings.UrlBot, message);
                _logger.LogInformation(string.Format("Processing command {0} sended by ", message.Message, message.SenderName));
            }
            else
            {
                responseMessage = string.Format("Invalid command {0}", message);
                _logger.LogWarning(string.Format("Invalid command {0} sended by ", message.Message, message.SenderName));
            }

            return responseMessage;
        }
    }
}
