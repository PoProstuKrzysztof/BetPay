using System.Text.Json.Serialization;

namespace Domain.Models.FootballApi.League
{
    public class Parameters
    {
        [JsonPropertyName("country")]
        public string? Country { get; set; }

        [JsonPropertyName("current")]
        public string? Current { get; set; }

        [JsonPropertyName("season")]
        public string? Season { get; set; }
        
        [JsonPropertyName("code")]
        public string? Code { get; set; }
        
        [JsonPropertyName("id")]
        public string? Id { get; set; }
    }
} 