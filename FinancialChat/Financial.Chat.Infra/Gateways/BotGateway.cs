using Financial.Core.Gateways;
using Financial.Chat.Domain.Dtos;
using Financial.Chat.Domain.Interfaces;
using Microsoft.Extensions.Logging;

namespace Financial.Chat.Infra.Gateways
{
    public class BotGateway : BaseGateway<BotGateway>, IBotGateway
    {
        public BotGateway(ILogger<BotGateway> logger) : base(logger)
        {
        }

        public async Task SendCommandAsync(string url, MessageRequestDto command)
        {
            await PostRequest(url, command);
        }
    }
}