using Financial.Bot.API.DTOs;

namespace Financial.Bot.API.Interfaces
{
    public interface IGetCommandParameter
    {
        (AllowedCommandsSettings, string) Execute(string message);
    }
}
