using Application.Contracts;
using Domain.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Repositories
{
    public class LeagueTournamentRepository : ILeagueTournamentRepository
    {
        private readonly RepositoryContext _context;
        private readonly ILogger<LeagueTournamentRepository>? _logger;

        public LeagueTournamentRepository(
            RepositoryContext context,
            ILogger<LeagueTournamentRepository>? logger = null)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<IEnumerable<LeagueTournament>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                _logger?.LogDebug("Fetching all league tournaments");
                return await _context.LeagueTournaments
                    .Include(l => l.Country)
                    .ToListAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                _logger?.LogError(ex, "Error occurred while fetching all league tournaments");
                throw;
            }
        }

        public async Task<IEnumerable<LeagueTournament>> GetByCountryCodeAsync(string countryCode, CancellationToken cancellationToken = default)
        {
            return await _context.LeagueTournaments
                .Include(l => l.Country)
                .Where(l => l.CountryCode == countryCode)
                .ToListAsync(cancellationToken);
        }

        public async Task<LeagueTournament?> GetByApiIdAsync(int apiId, CancellationToken cancellationToken = default)
        {
            return await _context.LeagueTournaments
                .Include(l => l.Country)
                .FirstOrDefaultAsync(l => l.ApiId == apiId, cancellationToken);
        }

        public async Task AddOrUpdateRangeAsync(IEnumerable<LeagueTournament> leagues, CancellationToken cancellationToken = default)
        {
            try
            {
                foreach (var league in leagues)
                {
                    _logger?.LogDebug("Processing league: {LeagueName} with ApiId: {ApiId}", league.Name, league.ApiId);

                    var existingLeague = await _context.LeagueTournaments
                        .FirstOrDefaultAsync(l => l.ApiId == league.ApiId, cancellationToken);

                    if (existingLeague != null)
                    {
                        existingLeague.Name = league.Name;
                        existingLeague.Type = league.Type;
                        existingLeague.LogoUrl = string.IsNullOrEmpty(league.LogoUrl) ? existingLeague.LogoUrl : league.LogoUrl;
                        existingLeague.CountryId = league.CountryId;
                        existingLeague.CountryCode = league.CountryCode;
                        existingLeague.UpdatedOn = DateTime.UtcNow;

                        _context.Entry(existingLeague).State = EntityState.Modified;
                    }
                    else
                    {
                        if (string.IsNullOrEmpty(league.LogoUrl) || league.CountryId == 0)
                        {
                            _logger?.LogWarning("Skipping league {LeagueName} due to missing required fields", league.Name);
                            continue;
                        }

                        await _context.LeagueTournaments.AddAsync(league, cancellationToken);
                    }
                }

                await _context.SaveChangesAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                _logger?.LogError(ex, "Error occurred while adding or updating leagues");
                throw;
            }
        }

        public async Task<bool> ExistsByApiIdAsync(int apiId, CancellationToken cancellationToken = default)
        {
            return await _context.LeagueTournaments
                .AnyAsync(l => l.ApiId == apiId, cancellationToken);
        }
    }
}