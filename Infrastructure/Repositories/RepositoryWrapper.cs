using Application.Contracts;
using Infrastructure.Data;

namespace Infrastructure.Repositories
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private readonly RepositoryContext _context;
        private IBetRepository _betRepository;
        private IEventRepository _eventRepository;
        private IBookmakerRepository _bookmakerRepository;
        private IEventTypeRepository _eventTypeRepository;
        private ICategoryRepository _categoryRepository;
        private ILeagueTournamentRepository _leagueTournamentRepository;

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

        public ILeagueTournamentRepository LeagueTournamentRepository
        {
            get
            {
                return _leagueTournamentRepository ??= new LeagueTournamentsRepository(_context);
            }
        }

        public IBookmakerRepository BookmakerRepository
        {
            get
            {
                return _bookmakerRepository ??= new BookmakerRepository(_context);
            }
        }

        public IEventTypeRepository EventTypeRepository
        {
            get
            {
                return _eventTypeRepository ??= new EventTypeRepository(_context);
            }
        }

        public ICategoryRepository CategoryRepository
        {
            get
            {
                return _categoryRepository ??= new CategoryRepository(_context);
            }
        }

        public IBetRepository BetRepository
        {
            get
            {
                return _betRepository ??= new BetRepository(_context);
            }
        }

        public IEventTypeRepository EventTypeRepostiory
        {
            get
            {
                return _eventTypeRepository ??= new EventTypeRepository(_context);
            }
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}