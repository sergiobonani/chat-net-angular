using FinancialChat.Web.Interfaces;
using Microsoft.AspNetCore.SignalR;

namespace FinancialChat.Web.Hubs
{
    public class ChatHub : Hub<IChatHub>, IChatHub
    {

        //public async Task OnSendMessage(string user, string message)
        //{
        //    await Clients.All.SendAsync("ReceiveMessage", user, message);
        //}

        private const string CHAT_GROUP = "MainGroup";

        public override async Task OnConnectedAsync()
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, CHAT_GROUP);
        }

        public override async Task OnDisconnectedAsync(System.Exception exception)
        {
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, CHAT_GROUP);
        }

        public async Task OnEnterChatAsync(string userName)
        {
            await Clients.Groups(CHAT_GROUP).OnEnterChatAsync(userName);
        }

        public async Task OnExitChatAsync(string userName)
        {
            await Clients.OthersInGroup(CHAT_GROUP).OnExitChatAsync(userName);
        }

        public async Task OnNewMessageAsync(string userName, string message)
        {
            await Clients.OthersInGroup(CHAT_GROUP).OnNewMessageAsync(userName, message);
        }
    }
}
