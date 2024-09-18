using Application.Contracts;
using Domain.Entities;
using Infrastructure.Data;
using Infrastructure.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class BookmakerRepository : RepositoryBase<Bookmaker>, IBookmakerRepository
{
    public BookmakerRepository(RepositoryContext repositoryContext) : base(repositoryContext)
    {
    }

    public async Task<IEnumerable<Bookmaker>> GetAllBookmakersAsync()
    {
        try
        {
            return await FindAll()
                    .Result
                    .OrderBy(x => x.BookmakerId)
                    .ToListAsync();

        }
        catch (Exception ex)
        {

            throw new RetrieveException("Failed to retrieve bookmakers.",nameof(Bookmaker),ex);
        }
    }
}