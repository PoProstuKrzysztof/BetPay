using Application.Contracts;
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
        return await FindAll()
            .Result
            .OrderByDescending(e => e.EventId)
            .ToListAsync();
    }

    public void UpdateEvent(Event @event)
    {
        var local = RepositoryContext.Set<Event>()
            .Local.FirstOrDefault(e => e.EventId.Equals(@event.EventId));

        if (local != null)
        {
            RepositoryContext.Entry(local).State = EntityState.Detached;
        }

        RepositoryContext.Entry(@event).State = EntityState.Modified;

        Update(@event);
    }

    public void CreateEvent(Event @event)
    {
        var bet = RepositoryContext.Set<Bet>()
            .FirstOrDefault(b => b.BetId == @event.BetId);

        var eventType = RepositoryContext.Set<EventType>()
            .FirstOrDefault(et => et.EventTypeId == @event.EventTypeId);

        var category = RepositoryContext.Set<Category>()
            .FirstOrDefault(c => c.CategoryId == @event.CategoryId);

        RepositoryContext.Attach(category);
        RepositoryContext.Attach(eventType);
        RepositoryContext.Attach(bet);

        @event.Bet = bet;
        @event.Category = category;
        @event.EventType = eventType;

        Create(@event);
    }

    public void DeleteEvent(Event @event)
    {
        var local = RepositoryContext.Set<Event>()
        .Local.FirstOrDefault(e => e.BetId.Equals(other: @event.EventId));

        if (local != null)
        {
            RepositoryContext.Entry(local).State = EntityState.Detached;
        }

        RepositoryContext.Entry(@event).State = EntityState.Deleted;

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