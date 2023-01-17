using Financial.Bot.Application.DTOs;

namespace Financial.Bot.Application.Interfaces
{
    public interface IProcessCommandUseCase
    {
        Task ExecuteAsync(ProcessCommandDto processCommand);
    }
}
