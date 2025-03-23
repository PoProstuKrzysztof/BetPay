using System.Text.Json.Serialization;

namespace Domain.Models.FootballApi.League
{
    public class LeagueData
    {
        [JsonPropertyName("league")]
        public LeagueInfo League { get; set; } = new();
        
        [JsonPropertyName("country")]
        public CountryInfo Country { get; set; } = new();
        
        [JsonPropertyName("seasons")]
        public List<SeasonInfo> Seasons { get; set; } = new();
    }
} 