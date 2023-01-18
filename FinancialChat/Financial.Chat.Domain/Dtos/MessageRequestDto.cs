namespace Financial.Chat.Domain.Dtos
{
    public class MessageRequestDto
    {
        public MessageRequestDto(Guid destination, string message)
        {
            Destination = destination;
            Message = message;
            Timestamp = DateTime.Now;
        }

        public Guid Destination { get; set; }

        public string Message { get; set; }

        public string SenderName { get; set; }

        public DateTime Timestamp { get; set; }
    }
}
