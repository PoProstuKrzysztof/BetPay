using Domain.Contracts;
using Infrastructure.Data;

namespace Infrastructure.Repositories;

public class RepositoryWrapper : IRepositoryWrapper
{
    private RepositoryContext _context;
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
            if (_eventRepository == null)
            {
                _eventRepository = new EventRepository(_context);
            }

            return _eventRepository;
        }
    }

    public IBetRepository BetRepository
    {
        get
        {
            if (BetRepository == null)
            {
                _betRepository = new BetRepository(_context);
            }

            return _betRepository;
        }
    }

    public async Task SaveAsync()
    {
        await _context.SaveChangesAsync();
    }
}