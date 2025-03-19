using Domain.Models.FootballApi.Country;

namespace Application.Contracts
{
    public interface ICountryEndpoint
    {
        Task<CountryResponse> GetAllCountriesAsync(CancellationToken cancellationToken = default);

        Task<CountryResponse> GetCountryByCodeAsync(string code, CancellationToken cancellationToken = default);
    }
}