using System.Text.Json.Serialization;

namespace DiscordBot_Web.Models
{
    public class User
    {
        [JsonPropertyName("id")]
        public Guid Id { get; set; }
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("discordId")]
        public int DiscordId { get; set; }
    }
}
