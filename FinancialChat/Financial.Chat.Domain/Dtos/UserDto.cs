namespace Financial.Chat.Domain.Dtos
{
    public class UserDto
    {
        public string ConnectionId { get; set; }

        public DateTime ConnectionDate { get; set; }

        public Guid Id { get; set; }

        public string Name { get; set; }
    }
}
