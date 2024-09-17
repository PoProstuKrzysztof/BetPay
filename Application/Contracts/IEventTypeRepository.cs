using Domain.Entities;

namespace Application.Contracts
{
    public interface IEventTypeRepository
    {
        Task<IEnumerable<EventType>> GetAllEventTypesAsync();
    }
}