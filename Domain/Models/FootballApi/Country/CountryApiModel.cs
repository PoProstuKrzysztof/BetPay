using System.Text.Json.Serialization;

public class CountryApiModel
{
    [JsonPropertyName("name")]
    public string Name { get; set; } = string.Empty;

    [JsonPropertyName("code")]
    public string Code { get; set; } = string.Empty;

    [JsonPropertyName("flag")]
    public string Flag { get; set; } = string.Empty;
}