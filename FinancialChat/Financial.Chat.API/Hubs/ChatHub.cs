using Financial.Chat.API.Interfaces;
using Financial.Chat.Application.Interfaces.UseCases;
using Financial.Chat.Domain.Dtos;
using Microsoft.AspNetCore.SignalR;

namespace Financial.Chat.API.Hubs
{
    public class ChatHub : Hub<IChatHub>, IChatHub
    {
        private AppSettings _appSettings;
        private ISendCommandToBotUseCase _sendCommandToBotUseCase;
        private readonly ILogger<ChatHub> _logger;
        public ChatHub(AppSettings appSettings,
            ISendCommandToBotUseCase sendCommandToBotUseCase,
            ILogger<ChatHub> logger)
        {
            _appSettings = appSettings;
            _sendCommandToBotUseCase = sendCommandToBotUseCase;
            _logger = logger;
        }

        public override async Task OnConnectedAsync()
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, _appSettings.ChatSettings.GroupName);
        }

        public override async Task OnDisconnectedAsync(System.Exception exception)
        {
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, _appSettings.ChatSettings.GroupName);
        }

        public async Task OnEnterChatAsync(string userName)
        {
            await Clients.Groups(_appSettings.ChatSettings.GroupName).OnEnterChatAsync(userName);
        }

        public async Task OnExitChatAsync(string userName)
        {
            await Clients.OthersInGroup(_appSettings.ChatSettings.GroupName).OnExitChatAsync(userName);
        }

        public async Task OnNewMessageAsync(string userName, string message)
        {
            _logger.LogInformation(String.Format("Message -{0}- received by {1}", message, userName));
            var viewModel = new MessageRequestDto(Guid.NewGuid(), message);
            if (!string.IsNullOrWhiteSpace(message) && message.StartsWith("/"))
            {
                var response = await _sendCommandToBotUseCase.ExecuteAsync(viewModel);
                message = string.IsNullOrEmpty(response) ? message : response;
            }
            await Clients.OthersInGroup(_appSettings.ChatSettings.GroupName).OnNewMessageAsync(userName, message);
        }
    }
}
