using Domain.Contracts;
using Infrastructure.Data;

namespace Infrastructure.Repositories;

public class RepositoryWrapper : IRepositoryWrapper
{
    private readonly RepositoryContext _context;
    private IBetRepository _betRepository;
    private IEventRepository _eventRepository;

    public RepositoryWrapper(RepositoryContext context)
    {
        _context = context;
    }

    public IEventRepository EventRepository
    {
        get
        {
            return _eventRepository ??= new EventRepository(_context);
        }
    }

    public IBetRepository BetRepository
    {
        get
        {
            return _betRepository ??= new BetRepository(_context);
        }
    }

    public async Task SaveAsync()
    {
        await _context.SaveChangesAsync();
    }
}
