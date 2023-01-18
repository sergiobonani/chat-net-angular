namespace Financial.Bot.API.DTOs
{
    public class ProcessCommandDto
    {
        public Guid Destination { get; set; }

        public string Message { get; set; }

        //public Guid SenderId { get; set; }

        public string SenderName => "Bot";
    }
}
