using Financial.Bot.API.DTOs;

namespace Financial.Bot.API.Interfaces
{
    public interface IGetInfoGatewayUseCase
    {
        Task<string> ExecuteAsync(string command); 
    }
}
