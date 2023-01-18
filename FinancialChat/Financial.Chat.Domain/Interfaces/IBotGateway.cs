using Financial.Chat.Domain.Dtos;

namespace Financial.Chat.Domain.Interfaces
{
    public interface IBotGateway
    {
        Task SendCommandAsync(string url, MessageRequestDto command);
    }
}
