using Financial.Core.ViewModels;

namespace Financial.Bot.API.DTOs
{
    public class AllowedCommandsSettings
    {
        public string BaseUrl { get; set; }

        public string Command { get; set; }

        public string Name { get; set; }

        public string QueryString { get; set; }

        public QueueSettings QueueSettings { get; set; }
    }
}
