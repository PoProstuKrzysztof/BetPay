using Domain.Entities;
using Domain.Contracts;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class BetRepository : RepositoryBase<Bet>, IBetRepository
    {
        public BetRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public async Task<IEnumerable<Bet>> GetAllBetsAsync()
        {
            return await FindAll()
                .Result
                .OrderByDescending(x => x.BetDate)
                .Include(b => b.EventsList)
                .ToListAsync();
        }

        public async Task<Bet> GetBetByGuid(Guid id)
        {
            return await FindByCondition(x => x.BetId.Equals(id))
                .Result.FirstOrDefaultAsync();
        }

        public void CreateBet(Bet bet)
        {
            Create(bet);
        }

        public void DeleteBet(Bet bet)
        {
            Delete(bet);
        }

        public void UpdateBet(Bet bet)
        {
            Update(bet);
        }
    }
}