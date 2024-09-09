using Domain.Contracts;
using Domain.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class EventRepository : RepositoryBase<Event>, IEventRepository
{
    public EventRepository(RepositoryContext repositoryContext) : base(repositoryContext)
    {
    }

    public async Task<IEnumerable<Event>> GetAllEventsAsync()
    {
        return await FindAll().Result

                .OrderByDescending(e => e.EventId)
                .ToListAsync();
    }

    public void UpdateEvent(Event @event)
    {
        Update(@event);
    }

    public void CreateEvent(Event @event)
    {
        Create(@event);
    }

    public void DeleteEvent(Event @event)
    {
        Delete(@event);
    }

    public async Task<IEnumerable<Event>> GetEventsByBetIdAsync(Guid? id)
    {
        return await FindByCondition(x => x.BetId.Equals(id))
            .Result
            .Include(c => c.Category)
            .Include(et => et.EventType)
            .ToListAsync();
    }
}