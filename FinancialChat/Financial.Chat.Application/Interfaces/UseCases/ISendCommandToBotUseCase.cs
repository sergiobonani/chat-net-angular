using Financial.Chat.Domain.Dtos;

namespace Financial.Chat.Application.Interfaces.UseCases
{
    public interface ISendCommandToBotUseCase 
    {
        Task<string> ExecuteAsync(MessageRequestDto message);
    }
}
