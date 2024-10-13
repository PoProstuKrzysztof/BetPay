using Application.Contracts;
using Domain.Entities;
using Infrastructure.Data;
using Infrastructure.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class LeagueTournamentsRepository : RepositoryBase<LeagueTournament>, ILeagueTournamentRepository
{
    public LeagueTournamentsRepository(RepositoryContext repositoryContext) : base(repositoryContext)
    {
    }

    public async Task<IEnumerable<LeagueTournament>> GetAllLeagueTournamentsAsync()
    {
        try
        {
            return await FindAll()
                    .Result
                    .OrderBy(x => x.LeagueTournamentId)
                    .ToListAsync();
        }
        catch (Exception ex)
        {
            throw new RetrieveException("Failed to retrieve bookmakers.", nameof(Bookmaker), ex);
        }
    }
}