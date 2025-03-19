using Domain.Entities;

namespace Application.Contracts
{
    public interface ICountryRepository
    {
        Task<IEnumerable<Country>> GetAllAsync(CancellationToken cancellationToken = default);
        Task AddOrUpdateRangeAsync(IEnumerable<Country> countries, CancellationToken cancellationToken = default);
        Task<bool> ExistsAsync(string code, CancellationToken cancellationToken = default);
    }
}