using Financial.Bot.API.DTOs;
using Financial.Bot.API.Interfaces;
using Financial.Core.Gateways;

namespace Financial.Bot.API.UseCases
{
    public class GetInfoGatewayUseCase : BaseGateway<GetInfoGatewayUseCase>, IGetInfoGatewayUseCase
    {
        private readonly AppSettings _appSettings;
        public GetInfoGatewayUseCase(ILogger<GetInfoGatewayUseCase> logger,
            AppSettings appSettings) : base(logger)
        {
            _appSettings = appSettings;
        }

        public async Task<string> ExecuteAsync(string command)
        {
            var url = _appSettings.AllowedCommands.First().BaseUrl + string.Format(_appSettings.AllowedCommands.First().QueryString, command);
            return await GetRequest<string>(url);
        }
    }
}
