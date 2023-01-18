using Financial.Bot.API.DTOs;
using Financial.Bot.API.Interfaces;
using System.Text.RegularExpressions;

namespace Financial.Bot.API.UseCases
{
    public class GetCommandParameter : IGetCommandParameter
    {
        private readonly AppSettings _appSettings;
        public GetCommandParameter(AppSettings appSettings)
        {
            _appSettings = appSettings;
        }
        public (AllowedCommandsSettings?, string) Execute(string message)
        {
            foreach (var item in _appSettings.AllowedCommandsSettings)
            {
                var regex = new Regex($"(?<={item.Command}).*").Matches(message);
                if (regex.Count > 0)
                {
                    return (item, regex.First().Value);
                }
            }

            return (null, string.Empty);
        }
    }
}
