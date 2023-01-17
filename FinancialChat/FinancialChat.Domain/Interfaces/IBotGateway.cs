using FinancialChat.Domain.Dtos;

namespace FinancialChat.Domain.Interfaces
{
    public interface IBotGateway
    {
        Task SendCommandAsync(string url, BotCommandRequestDto command);
    }
}
