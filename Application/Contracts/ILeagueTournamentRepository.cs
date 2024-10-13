using Domain.Entities;

namespace Application.Contracts
{
    public interface ILeagueTournamentRepository
    {
        Task<IEnumerable<LeagueTournament>> GetAllLeagueTournamentsAsync();
    }
}