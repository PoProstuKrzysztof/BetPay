namespace Domain.Models.FootballApi.League
{
    public class SeasonInfo
    {
        public int Year { get; set; }
        public string Start { get; set; } = string.Empty;
        public string End { get; set; } = string.Empty;
        public bool Current { get; set; }
        public CoverageInfo Coverage { get; set; } = new();
    }
}