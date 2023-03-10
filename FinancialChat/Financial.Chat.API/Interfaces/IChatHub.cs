namespace Financial.Chat.API.Interfaces
{
    public interface IChatHub
    {
        Task OnExitChatAsync(string userName);
        Task OnEnterChatAsync(string userName);
        Task OnNewMessageAsync(string userName, string message);
        //Task OnNewMessageAsync(MessageViewModel message);
    }
}
