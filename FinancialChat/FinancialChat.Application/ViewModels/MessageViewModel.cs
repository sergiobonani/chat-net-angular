namespace FinancialChat.Application.ViewModels
{
    public class MessageViewModel
    {
        public MessageViewModel(Guid destination, string message)
        {
            Destination = destination;
            Content = message;
            Timestamp = DateTime.Now;
        }

        public MessageViewModel(Guid destination, string message, UserViewModel sender)
            : this(destination, message)
        {
            User = sender;
        }

        public Guid Destination { get; set; }

        public string Content { get; set; }

        public UserViewModel User { get; set; }

        public DateTime Timestamp { get; set; }

        public bool IsCommand()
        {
            return !string.IsNullOrWhiteSpace(Content) && Content.StartsWith("/");
        }
    }
}
