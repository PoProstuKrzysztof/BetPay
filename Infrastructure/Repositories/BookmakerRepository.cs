using Application.Contracts;
using Domain.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class BookmakerRepository : RepositoryBase<Bookmaker>, IBookmakerRepository
{
    public BookmakerRepository(RepositoryContext repositoryContext) : base(repositoryContext)
    {
    }

    public async Task<IEnumerable<Bookmaker>> GetAllBookmakersAsync()
    {
        return await FindAll()
            .Result
            .OrderBy(x => x.BookmakerId)
            .ToListAsync();
    }
}