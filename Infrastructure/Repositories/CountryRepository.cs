using Application.Contracts;
using Domain.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class CountryRepository : ICountryRepository
    {
        private readonly RepositoryContext _context;

        public CountryRepository(RepositoryContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Country>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await _context.Countries.ToListAsync(cancellationToken);
        }

        public async Task AddOrUpdateRangeAsync(IEnumerable<Country> countries, CancellationToken cancellationToken = default)
        {
            foreach (var country in countries)
            {
                var existingCountry = await _context.Countries
                    .FirstOrDefaultAsync(c => c.Code == country.Code, cancellationToken);

                if (existingCountry != null)
                {
                    existingCountry.Name = country.Name;
                    existingCountry.FlagUrl = country.FlagUrl;
                    existingCountry.UpdatedOn = DateTime.UtcNow;
                    _context.Countries.Update(existingCountry);
                }
                else
                {
                    // Dodaj nowy kraj
                    await _context.Countries.AddAsync(country, cancellationToken);
                }
            }

            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task<bool> ExistsAsync(string code, CancellationToken cancellationToken = default)
        {
            return await _context.Countries
                .AnyAsync(x => x.Code == code, cancellationToken);
        }

        public async Task<Country?> GetByCodeAsync(string code, CancellationToken cancellationToken = default)
        {
            return await _context.Countries
                .FirstOrDefaultAsync(c => c.Code == code, cancellationToken);
        }
    }
}