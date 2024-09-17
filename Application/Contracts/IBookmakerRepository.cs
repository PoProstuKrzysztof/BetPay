using Domain.Entities;

namespace Application.Contracts
{
    public interface IBookmakerRepository
    {
        Task<IEnumerable<Bookmaker>> GetAllBookmakersAsync();
    }
}