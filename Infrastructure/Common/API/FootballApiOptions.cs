public class FootballApiOptions
{
    public const string SectionName = "FootballApi";

    public string BaseUrl { get; set; } = "https://v3.football.api-sports.io/";
    public string ApiKey { get; set; } = string.Empty;
    public string ApiHost { get; set; } = string.Empty;
}