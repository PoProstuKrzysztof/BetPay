using Application.Contracts;
using Domain.Entities;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Services
{
    public class LeagueSynchronizationService
    {
        private readonly ILeagueEndpoint _leagueEndpoint;
        private readonly ILeagueTournamentRepository _leagueRepository;
        private readonly ICountryRepository _countryRepository;
        private readonly ILogger<LeagueSynchronizationService> _logger;

        public LeagueSynchronizationService(
            ILeagueEndpoint leagueEndpoint,
            ILeagueTournamentRepository leagueRepository,
            ICountryRepository countryRepository,
            ILogger<LeagueSynchronizationService> logger)
        {
            _leagueEndpoint = leagueEndpoint;
            _leagueRepository = leagueRepository;
            _countryRepository = countryRepository;
            _logger = logger;
        }

        private async Task<List<LeagueTournament>> MapApiResponseToEntitiesAsync(
            Domain.Models.FootballApi.League.LeagueResponse response,
            CancellationToken cancellationToken)
        {
            var leagues = new List<LeagueTournament>();

            foreach (var leagueData in response.Response)
            {
                if (string.IsNullOrEmpty(leagueData.League.Logo) || string.IsNullOrEmpty(leagueData.Country.Code))
                {
                    _logger.LogWarning("Skipping league {LeagueName} due to missing required fields", leagueData.League.Name);
                    continue;
                }

                var country = await _countryRepository.GetByCodeAsync(leagueData.Country.Code, cancellationToken);

                if (country == null)
                {
                    _logger.LogWarning("Skipping league {LeagueName} - country with code {CountryCode} not found",
                        leagueData.League.Name, leagueData.Country.Code);
                    continue;
                }

                var league = new LeagueTournament
                {
                    ApiId = leagueData.League.Id,
                    Name = leagueData.League.Name,
                    Type = leagueData.League.Type,
                    LogoUrl = leagueData.League.Logo,
                    CountryId = country.CountryId,
                    CountryCode = country.Code,
                    CategoryId = 1 // Football
                };

                leagues.Add(league);
            }

            return leagues;
        }

        public async Task SynchronizeLeaguesByCountryCodeAsync(string countryCode, CancellationToken cancellationToken = default)
        {
            try
            {
                _logger.LogInformation("Starting league synchronization for country code {CountryCode}", countryCode);

                var response = await _leagueEndpoint.GetLeaguesByCountryCodeAsync(countryCode, cancellationToken);

                if (!response.Response.Any())
                {
                    _logger.LogWarning("No leagues received from the API for country code {CountryCode}", countryCode);
                    return;
                }

                var leagues = await MapApiResponseToEntitiesAsync(response, cancellationToken);

                _logger.LogInformation("Processing {Count} valid leagues for country code {CountryCode}",
                    leagues.Count, countryCode);

                await _leagueRepository.AddOrUpdateRangeAsync(leagues, cancellationToken);
                _logger.LogInformation("Successfully synchronized {Count} leagues for country code {CountryCode}",
                    leagues.Count, countryCode);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while synchronizing leagues for country code {CountryCode}", countryCode);
                throw;
            }
        }

        public async Task SynchronizeAllLeaguesAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                _logger.LogInformation("Starting synchronization of leagues for all countries");

                var countries = await _countryRepository.GetAllAsync(cancellationToken);

                foreach (var country in countries)
                {
                    try
                    {
                        await SynchronizeLeaguesByCountryCodeAsync(country.Code, cancellationToken);
                    }
                    catch (Exception ex)
                    {
                        _logger.LogError(ex, "Error synchronizing leagues for country {CountryName} ({CountryCode})",
                            country.Name, country.Code);
                    }
                }

                _logger.LogInformation("Completed league synchronization for all countries");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while synchronizing leagues for all countries");
                throw;
            }
        }
    }
}