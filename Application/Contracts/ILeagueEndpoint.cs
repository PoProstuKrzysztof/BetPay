using Domain.Models.FootballApi.League;

namespace Application.Contracts
{
    public interface ILeagueEndpoint
    {
        Task<LeagueResponse> GetLeaguesByCountryCodeAsync(string countryCode, CancellationToken cancellationToken = default);
        Task<LeagueResponse> GetLeaguesByCountryNameAsync(string countryName, CancellationToken cancellationToken = default);
        Task<LeagueResponse> GetLeagueByIdAsync(int leagueId, CancellationToken cancellationToken = default);
    }
} 