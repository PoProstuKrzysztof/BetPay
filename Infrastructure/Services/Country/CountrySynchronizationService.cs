using Application.Contracts;
using Domain.Entities;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Services
{
    public class CountrySynchronizationService
    {
        private readonly ICountryEndpoint _countryEndpoint;
        private readonly ICountryRepository _countryRepository;
        private readonly ILogger<CountrySynchronizationService> _logger;

        public CountrySynchronizationService(
            ICountryEndpoint countryEndpoint,
            ICountryRepository countryRepository,
            ILogger<CountrySynchronizationService> logger)
        {
            _countryEndpoint = countryEndpoint;
            _countryRepository = countryRepository;
            _logger = logger;
        }

        public async Task SynchronizeCountriesAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                _logger.LogInformation("Starting country synchronization");

                var response = await _countryEndpoint.GetAllCountriesAsync(cancellationToken);

                if (!response.Response.Any())
                {
                    _logger.LogWarning("No countries received from the API");
                    return;
                }

                var countries = response.Response
                    .Where(x => !string.IsNullOrEmpty(x.Flag))
                    .Select(x => new Country
                    {
                        Name = x.Name,
                        Code = x.Code,
                        FlagUrl = x.Flag,
                        CreatedOn = DateTime.UtcNow
                    })
                    .ToList();

                _logger.LogInformation("Processing {Count} valid countries", countries.Count);

                foreach (var country in countries)
                {
                    _logger.LogDebug("Country data - Code: {Code}, Name: {Name}, FlagUrl: {FlagUrl}",
                        country.Code, country.Name, country.FlagUrl);
                }

                await _countryRepository.AddOrUpdateRangeAsync(countries, cancellationToken);
                _logger.LogInformation("Successfully synchronized {Count} countries", countries.Count);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while synchronizing countries");
                throw;
            }
        }
    }
}