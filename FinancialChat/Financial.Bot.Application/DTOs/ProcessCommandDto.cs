namespace Financial.Bot.Application.DTOs
{
    public class ProcessCommandDto
    {
        public Guid Destination { get; set; }

        public string Message { get; set; }

        public string CommandParameter;

        public Guid SenderId { get; set; }
    }
}
