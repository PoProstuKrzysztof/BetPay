using System.Text.Json.Serialization;

namespace Domain.Models.FootballApi.League
{
    public class LeagueResponse
    {
        [JsonPropertyName("get")]
        public string Get { get; set; } = string.Empty;

        [JsonPropertyName("parameters")]
        public Parameters Parameters { get; set; } = new();

        [JsonPropertyName("errors")]
        public object[] Errors { get; set; } = Array.Empty<object>();

        [JsonPropertyName("results")]
        public int Results { get; set; }

        [JsonPropertyName("paging")]
        public Paging Paging { get; set; } = new();

        [JsonPropertyName("response")]
        public List<LeagueData> Response { get; set; } = new();
    }
}