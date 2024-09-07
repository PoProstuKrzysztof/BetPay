using Domain.Entities;

namespace Domain.Contracts;

public interface IEventRepository : IRepositoryBase<Event>
{
    Task<IEnumerable<Event>> GetAllEventsAsync();

    Task<Event> GetEventByGuidAsync(Guid id);

    Task<IEnumerable<Event>> GetEventsByBetIdAsync(Guid id);

    void CreateEvent(Event @event);

    void DeleteEvent(Event @event);

    void UpdateEvent(Event @event);
}