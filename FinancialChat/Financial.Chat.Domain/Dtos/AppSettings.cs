namespace Financial.Chat.Domain.Dtos
{
    public class AppSettings
    {
        public string UrlBot { get; set; }
        public List<AllowedBotCommands> AllowedBotCommands { get; set;}
        public ChatSettings ChatSettings { get; set; } 
    }

    public class AllowedBotCommands
    {
        public string Command { get; set; }
    }

    public class ChatSettings
    {
        public string GroupName { get; set;}
    }
}
