namespace FinancialChat.Web.Interfaces
{
    public interface IChatHub
    {
        Task OnExitChatAsync(string userName);
        Task OnEnterChatAsync(string userName);
        Task OnNewMessageAsync(string userName, string message);
    }
}
