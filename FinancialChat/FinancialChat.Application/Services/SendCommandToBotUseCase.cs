using AutoMapper;
using FinancialChat.Application.Interfaces.UseCases;
using FinancialChat.Application.ViewModels;
using FinancialChat.Domain.Dtos;
using FinancialChat.Domain.Interfaces;

namespace FinancialChat.Application.Services
{
    public class SendCommandToBotUseCase : ISendCommandToBotUseCase
    {
        private readonly AppSettings _settings;
        private readonly IBotGateway _botGateway;
        private readonly IMapper _mapper;
        public SendCommandToBotUseCase(AppSettings appSettings,
            IBotGateway botGateway,
            IMapper mapper)
        {
            _settings = appSettings;
            _botGateway = botGateway;
            _mapper = mapper;
        }
        public async Task<string> ExecuteAsync(MessageViewModel message)
        {
            var responseMessage = string.Empty;
            if (_settings.AllowedBotCommands.Any(x => message.Content.StartsWith(x.Command)))
            {
                 var botCommand = _mapper.Map<BotCommandRequestDto>(message);
                await _botGateway.SendCommandAsync(_settings.UrlBot, botCommand);
                responseMessage = string.Format("Processing command {0}", message);
            }
            else
            {
                responseMessage = string.Format("Invalid command {0}", message);
            }

            return responseMessage;
        }
    }
}
