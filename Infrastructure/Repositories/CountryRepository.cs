using Application.Contracts;
using Domain.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Repositories
{
    public class CountryRepository : ICountryRepository
    {
        private readonly RepositoryContext _context;
        private readonly ILogger<CountryRepository> _logger;

        public CountryRepository(RepositoryContext context, ILogger<CountryRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<IEnumerable<Country>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await _context.Countries.ToListAsync(cancellationToken);
        }

        public async Task AddOrUpdateRangeAsync(IEnumerable<Country> countries, CancellationToken cancellationToken = default)
        {
            try
            {
                foreach (var country in countries)
                {
                    _logger.LogDebug("Processing country: {Code} with FlagUrl: {FlagUrl}", country.Code, country.FlagUrl);

                    var existingCountry = await _context.Countries
                        .FirstOrDefaultAsync(c => c.Code == country.Code, cancellationToken);

                    if (existingCountry != null)
                    {
                        // Upewnij się, że wszystkie wymagane pola są skopiowane
                        existingCountry.Name = country.Name;
                        existingCountry.FlagUrl = string.IsNullOrEmpty(country.FlagUrl) ? existingCountry.FlagUrl : country.FlagUrl;
                        existingCountry.UpdatedOn = DateTime.UtcNow;

                        _context.Entry(existingCountry).State = EntityState.Modified;
                    }
                    else
                    {
                        // Upewnij się, że nowy kraj ma wszystkie wymagane pola
                        if (string.IsNullOrEmpty(country.FlagUrl))
                        {
                            _logger.LogWarning("Skipping country {Code} due to missing FlagUrl", country.Code);
                            continue;
                        }

                        country.CreatedOn = DateTime.UtcNow;
                        await _context.Countries.AddAsync(country, cancellationToken);
                    }
                }

                await _context.SaveChangesAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while adding or updating countries");
                throw;
            }
        }

        public async Task<bool> ExistsAsync(string code, CancellationToken cancellationToken = default)
        {
            return await _context.Countries
                .AnyAsync(x => x.Code == code, cancellationToken);
        }
    }
}