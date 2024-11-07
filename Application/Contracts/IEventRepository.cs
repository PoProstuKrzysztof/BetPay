using Domain.Entities;

namespace Application.Contracts;

public interface IEventRepository : IRepositoryBase<Event>
{
    Task<IEnumerable<Event>> GetAllEventsAsync();

    Task<IEnumerable<EventCategoryChart>> GetAllEventsWithCategoryAsync();
    void CreateEvent(Event @event);

    void DeleteEvent(Event @event);

    void UpdateEvent(Event @event);
}