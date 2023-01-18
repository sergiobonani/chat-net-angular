using FinancialChat.Application.Interfaces.UseCases;
using FinancialChat.Domain.Dtos;
using FinancialChat.Web.Interfaces;
using Microsoft.AspNetCore.SignalR;

namespace FinancialChat.Web.Hubs
{
    //public class ChatHub : Hub<IChatHub>, IChatHub
    //{
    //    private AppSettings _appSettings;
    //    private ISendCommandToBotUseCase _sendCommandToBotUseCase;
    //    private readonly ILogger<ChatHub> _logger;
    //    public ChatHub(AppSettings appSettings,
    //        ISendCommandToBotUseCase sendCommandToBotUseCase,
    //        ILogger<ChatHub> logger)
    //    {
    //        _appSettings = appSettings;
    //        _sendCommandToBotUseCase = sendCommandToBotUseCase;
    //        _logger = logger;
    //    }

    //    private const string CHAT_GROUP = "MainGroup";

    //    public override async Task OnConnectedAsync()
    //    {
    //        await Groups.AddToGroupAsync(Context.ConnectionId, CHAT_GROUP);
    //    }

    //    public override async Task OnDisconnectedAsync(System.Exception exception)
    //    {
    //        await Groups.RemoveFromGroupAsync(Context.ConnectionId, CHAT_GROUP);
    //    }

    //    public async Task OnEnterChatAsync(string userName)
    //    {
    //        await Clients.Groups(CHAT_GROUP).OnEnterChatAsync(userName);
    //    }

    //    public async Task OnExitChatAsync(string userName)
    //    {
    //        await Clients.OthersInGroup(CHAT_GROUP).OnExitChatAsync(userName);
    //    }

    //    public async Task OnNewMessageAsync(string userName, string message)
    //    {
    //        _logger.LogInformation(String.Format("Message -{0}- received by {1}", message, userName));
    //        var viewModel = new MessageDto(Guid.NewGuid(), message);
    //        if (!string.IsNullOrWhiteSpace(message) && message.StartsWith("/"))
    //        {
    //            message = await _sendCommandToBotUseCase.ExecuteAsync(viewModel);
    //        }
    //        await Clients.OthersInGroup(CHAT_GROUP).OnNewMessageAsync(userName, message);
    //    }

    //    //public async Task OnNewMessageAsync(MessageViewModel newMessage)
    //    //{
    //    //    if (newMessage.IsCommand())
    //    //    {
    //    //        await _sendCommandToBotUseCase.ExecuteAsync(newMessage);
    //    //    }

    //    //    await Clients.OthersInGroup(CHAT_GROUP).OnNewMessageAsync(newMessage);
    //    //}
    //}
}
