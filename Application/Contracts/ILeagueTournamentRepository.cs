using Domain.Entities;

namespace Application.Contracts
{
    public interface ILeagueTournamentRepository
    {
        Task<IEnumerable<LeagueTournament>> GetAllAsync(CancellationToken cancellationToken = default);
        Task<IEnumerable<LeagueTournament>> GetByCountryCodeAsync(string countryCode, CancellationToken cancellationToken = default);
        Task<LeagueTournament?> GetByApiIdAsync(int apiId, CancellationToken cancellationToken = default);
        Task AddOrUpdateRangeAsync(IEnumerable<LeagueTournament> leagues, CancellationToken cancellationToken = default);
        Task<bool> ExistsByApiIdAsync(int apiId, CancellationToken cancellationToken = default);
    }
}