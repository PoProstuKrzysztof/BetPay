using Application.Contracts;
using Domain.Entities;
using Infrastructure.Data;
using Infrastructure.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class EventTypeRepository : RepositoryBase<EventType>, IEventTypeRepository
    {
        public EventTypeRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public async Task<IEnumerable<EventType>> GetAllEventTypesAsync()
        {
            try
            {
                return await FindAll()
                        .OrderBy(x => x.EventTypeId)
                        .ToListAsync();
            }
            catch (Exception ex)
            {
                throw new RetrieveException("Failed to retrieve event types.", nameof(EventType), ex);
            }
        }
    }
}