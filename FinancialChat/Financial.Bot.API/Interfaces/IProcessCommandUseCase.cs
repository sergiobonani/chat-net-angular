using Financial.Bot.API.DTOs;

namespace Financial.Bot.Application.Interfaces
{
    public interface IProcessCommandUseCase
    {
        Task ExecuteAsync(ProcessCommandDto processCommand);
    }
}
