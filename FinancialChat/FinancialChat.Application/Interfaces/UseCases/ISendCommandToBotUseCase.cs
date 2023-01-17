using FinancialChat.Application.ViewModels;

namespace FinancialChat.Application.Interfaces.UseCases
{
    public interface ISendCommandToBotUseCase 
    {
        Task<string> ExecuteAsync(MessageViewModel message);
    }
}
