using Domain.Entities;

namespace Application.Contracts;

public interface IEventRepository : IRepositoryBase<Event>
{
    Task<IEnumerable<Event>> GetAllEventsAsync();

    Task<IEnumerable<Event>> GetEventsByBetIdAsync(Guid? id);

    void CreateEvent(Event @event);

    void DeleteEvent(Event @event);

    void UpdateEvent(Event @event);
}