using Application.Contracts;
using Domain.Entities;
using Infrastructure.Data;
using Infrastructure.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class EventRepository : RepositoryBase<Event>, IEventRepository
{
    public EventRepository(RepositoryContext repositoryContext) : base(repositoryContext)
    {
    }

    public async Task<IEnumerable<Event>> GetAllEventsAsync()
    {
        try
        {
            return await FindAll()
               .ToListAsync();
        }
        catch (Exception ex)
        {
            throw new RetrieveException("Failed to retrieve events.", nameof(Event), ex);
        }
    }

    public void UpdateEvent(Event @event)
    {
        try
        {
            var localEvent = RepositoryContext.Set<Event>()
               .Local.FirstOrDefault(e => e.EventId.Equals(@event.EventId));

            if (localEvent != null)
            {
                RepositoryContext.Entry(localEvent).State = EntityState.Detached;
            }

            RepositoryContext.Entry(@event).State = EntityState.Modified;

            Update(@event);
        }
        catch (Exception ex)
        {
            throw new UpdateException($"Failed to update event with ID: {@event.EventId} .", nameof(Event), ex);
        }
    }

    public void CreateEvent(Event @event)
    {
        try
        {
            if (@event.GetType().GetProperties().All(p => p.GetValue(null) == null))
            {
                return;
            }

            var bet = RepositoryContext.Set<Bet>()
                .First(b => b.BetId == @event.BetId);

            var eventType = RepositoryContext.Set<EventType>()
                .First(et => et.EventTypeId == @event.EventTypeId);

            var category = RepositoryContext.Set<Category>()
                .First(c => c.CategoryId == @event.CategoryId);

            RepositoryContext.Attach(category);
            RepositoryContext.Attach(eventType);
            RepositoryContext.Attach(bet);

            @event.Bet = bet;
            @event.Category = category;
            @event.EventType = eventType;

            RepositoryContext.Entry(@event).State = EntityState.Added;

            Create(@event);
        }
        catch (Exception ex)
        {
            throw new CreateException("Failed to create event.", nameof(Event), ex);
        }
    }

    public void DeleteEvent(Event @event)
    {
        try
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
        catch (Exception ex)
        {
            throw new DeleteException($"Failed to delete event with ID: {@event.EventId}.", nameof(Event), ex);
        }
    }

    public async Task<IEnumerable<EventCategoryChart>> GetAllEventsWithCategoryAsync()
    {
        var events = await FindAll()
            .Include(c => c.Category)
            .ToListAsync();

        var totalEvents = events.Count;
        var categoryCounts = events
            .GroupBy(e => e.Category.Name)
            .Select(g => new
            {
                Category = g.Key,
                Count = g.Count()
            })
            .ToList();

        var eventCategoryCharts = categoryCounts
            .Select(cc => new EventCategoryChart(
                cc.Category,
                Math.Round((double)cc.Count / totalEvents * 100, 0)
            ))
            .ToList();

        return eventCategoryCharts;
    }
}