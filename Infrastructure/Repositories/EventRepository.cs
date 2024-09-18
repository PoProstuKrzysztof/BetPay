﻿using Application.Contracts;
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
               .Result
               .OrderByDescending(e => e.EventId)
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
            var local = RepositoryContext.Set<Event>()
               .Local.FirstOrDefault(e => e.EventId.Equals(@event.EventId));

            if (local != null)
            {
                RepositoryContext.Entry(local).State = EntityState.Detached;
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


}