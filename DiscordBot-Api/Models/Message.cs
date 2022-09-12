namespace DiscordBot_Api.Models
{
    public class Message
    {
        public int Text { get; set; }
        public DateTimeOffset DateTime { get; set; }
        public int OwnerId { get; set; }
    }
}
