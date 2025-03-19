using System.Text.Json.Serialization;

namespace Domain.Models.FootballApi.Country
{
    public class CountryResponse
    {
        [JsonPropertyName("get")]
        public string Get { get; set; } = string.Empty;

        [JsonPropertyName("parameters")]
        public object[] Parameters { get; set; } = Array.Empty<object>();

        [JsonPropertyName("errors")]
        public object[] Errors { get; set; } = Array.Empty<object>();

        [JsonPropertyName("results")]
        public int Results { get; set; }

        [JsonPropertyName("paging")]
        public Paging Paging { get; set; } = new();

        [JsonPropertyName("response")]
        public List<CountryApiModel> Response { get; set; } = new();
    }
}