using Financial.Core.Gateways;
using FinancialChat.Domain.Dtos;
using FinancialChat.Domain.Interfaces;
using Microsoft.Extensions.Logging;

namespace FinancialChat.Infra.Gateways
{
    public class BotGateway : BaseGateway<BotGateway>, IBotGateway
    {
        public BotGateway(ILogger<BotGateway> logger) : base(logger)
        {
        }

        public async Task SendCommandAsync(string url, BotCommandRequestDto command)
        {
            await PostRequest(url, command);
        }
    }
}