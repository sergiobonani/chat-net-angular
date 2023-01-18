using FinancialChat.Consumer.DTOs;

namespace FinancialChat.Consumer.Interfaces
{
    public interface IChatGateway
    {
        Task SendMessageAsyc(string url, MessageRequestDto request);
    }
}
