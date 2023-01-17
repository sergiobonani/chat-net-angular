using Financial.Bot.API.DTOs;
using Financial.Bot.API.Interfaces;
using Financial.Bot.Application.Interfaces;
using Financial.Core.Converter;

namespace Financial.Bot.API.UseCases
{
    public class ProcessCommandUseCase : IProcessCommandUseCase
    {
        private readonly ILogger<ProcessCommandUseCase> _logger;
        private readonly IGetInfoGatewayUseCase _getInfoGatewayUseCase;
        private readonly IMessageBroker _messageBroker;
        private readonly IGetCommandParameter _getCommandParameter;

        public ProcessCommandUseCase(ILogger<ProcessCommandUseCase> logger,
            IGetInfoGatewayUseCase getInfoGatewayUseCase,
            IMessageBroker messageBroker,
            IGetCommandParameter getCommandParameter)
        {
            _logger = logger;
            _getInfoGatewayUseCase = getInfoGatewayUseCase;
            _messageBroker = messageBroker;
            _messageBroker = messageBroker;
            _getCommandParameter = getCommandParameter;
        }
        public async Task ExecuteAsync(ProcessCommandDto processCommand)
        {
            var (allowedCommand, parameter) = _getCommandParameter.Execute(processCommand.Message);
            try
            {
                var result = await _getInfoGatewayUseCase.ExecuteAsync(parameter);

                var message = StockPriceConverter.Execute(result);

                if (!string.IsNullOrEmpty(message))
                {
                    processCommand.Message = message;

                    _messageBroker.Publish(processCommand, allowedCommand.MessageBroker);
                    return;
                }

                throw new Exception("Invalid to convert");
                
            }
            catch (Exception ex)
            {
                var message = string.Format("Error processing command {0} with parameter {1}", "allowedCommand.Command", parameter);
                _logger.LogError(ex, message);
                processCommand.Message = message;
                _messageBroker.Publish(processCommand, null);
            }
        }
    }
}
