namespace FinancialChat.Consumer.DTOs
{
    public class MessageRequestDto
    {
        public Guid Destination { get; set; }

        public string Message { get; set; }

        public string SenderName { get; set; }
    }
}
