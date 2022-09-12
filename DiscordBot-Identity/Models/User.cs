using System;

namespace DiscordBot_Identity.Models
{
    public class User
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int DiscordId { get; set; }
    }
}
