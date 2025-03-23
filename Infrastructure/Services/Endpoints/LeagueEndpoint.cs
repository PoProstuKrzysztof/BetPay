using Application.Contracts;
using Domain.Models.FootballApi.League;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Services.Endpoints
{
    public class LeagueEndpoint : ILeagueEndpoint
    {
        private readonly IFootballApiService _apiService;
        private readonly ILogger<LeagueEndpoint> _logger;
        private const string BaseEndpoint = "leagues";

        public LeagueEndpoint(
            IFootballApiService apiService,
            ILogger<LeagueEndpoint> logger)
        {
            _apiService = apiService;
            _logger = logger;
        }

        public async Task<LeagueResponse> GetLeaguesByCountryCodeAsync(string countryCode, CancellationToken cancellationToken = default)
        {
            try
            {
                _logger.LogInformation("Fetching leagues for country code {CountryCode}", countryCode);
                var endpoint = $"{BaseEndpoint}?code={countryCode}";
                
                return await _apiService.GetAsync<LeagueResponse>(endpoint, cancellationToken)
                    ?? throw new Exception($"Failed to get leagues for country code {countryCode}");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while fetching leagues for country code {CountryCode}", countryCode);
                throw;
            }
        }

        public async Task<LeagueResponse> GetLeaguesByCountryNameAsync(string countryName, CancellationToken cancellationToken = default)
        {
            try
            {
                _logger.LogInformation("Fetching leagues for country {CountryName}", countryName);
                var endpoint = $"{BaseEndpoint}?country={countryName}";
                
                return await _apiService.GetAsync<LeagueResponse>(endpoint, cancellationToken)
                    ?? throw new Exception($"Failed to get leagues for country {countryName}");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while fetching leagues for country {CountryName}", countryName);
                throw;
            }
        }

        public async Task<LeagueResponse> GetLeagueByIdAsync(int leagueId, CancellationToken cancellationToken = default)
        {
            try
            {
                _logger.LogInformation("Fetching league with ID {LeagueId}", leagueId);
                var endpoint = $"{BaseEndpoint}?id={leagueId}";
                
                return await _apiService.GetAsync<LeagueResponse>(endpoint, cancellationToken)
                    ?? throw new Exception($"Failed to get league with ID {leagueId}");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while fetching league with ID {LeagueId}", leagueId);
                throw;
            }
        }
    }
} 