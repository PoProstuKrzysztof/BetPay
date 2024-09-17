using Application.Contracts;
using Domain.Entities;
using Infrastructure.Data;
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
            return await FindAll()
                .Result
                .OrderBy(x => x.EventTypeId)
                .ToListAsync();
        }
    }
}