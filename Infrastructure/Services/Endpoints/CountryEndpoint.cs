using Application.Contracts;
using Domain.Models.FootballApi.Country;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Services.Endpoints
{
    public class CountryEndpoint : ICountryEndpoint
    {
        private readonly IFootballApiService _apiService;
        private readonly ILogger<CountryEndpoint> _logger;
        private const string BaseEndpoint = "countries";

        public CountryEndpoint(
            IFootballApiService apiService,
            ILogger<CountryEndpoint> logger)
        {
            _apiService = apiService;
            _logger = logger;
        }

        public async Task<CountryResponse> GetAllCountriesAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                _logger.LogInformation("Fetching all countries from Football API");
                return await _apiService.GetAsync<CountryResponse>(BaseEndpoint, cancellationToken)
                    ?? throw new Exception("Failed to get countries from API");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while fetching all countries");
                throw;
            }
        }

        public async Task<CountryResponse> GetCountryByCodeAsync(string code, CancellationToken cancellationToken = default)
        {
            try
            {
                _logger.LogInformation("Fetching country with code {Code} from Football API", code);
                var endpoint = $"{BaseEndpoint}?code={code}";
                return await _apiService.GetAsync<CountryResponse>(endpoint, cancellationToken)
                    ?? throw new Exception($"Failed to get country with code {code} from API");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while fetching country with code {Code}", code);
                throw;
            }
        }
    }
}