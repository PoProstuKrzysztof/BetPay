using Application.Contracts;
using Domain.Entities;
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
                .Include(b => b.Bookmaker)
                .ToListAsync();
        }

        public async Task<Bet> GetBetByGuid(Guid id)
        {
            return await FindByCondition(x => x.BetId.Equals(id))
                .Result
                .Include(el => el.EventsList)
                .Include(b => b.Bookmaker)
                .FirstOrDefaultAsync();
        }

        public void CreateBet(Bet bet)
        {
            var bookmaker = RepositoryContext.Set<Bookmaker>()
                .FirstOrDefault(x => x.BookmakerId == bet.BookmakerId);
            RepositoryContext.Attach(bookmaker);

            bet.Bookmaker = bookmaker;
            Create(bet);
        }

        public void DeleteBet(Bet bet)
        {
            var local = RepositoryContext.Set<Bet>()
                .Local.FirstOrDefault(e => e.BetId.Equals(bet.BetId));

            if (local != null)
            {
                RepositoryContext.Entry(local).State = EntityState.Detached;
            }

            RepositoryContext.Entry(bet).State = EntityState.Deleted;

            Delete(bet);
        }

        public void UpdateBet(Bet bet)
        {
            Update(bet);
        }

        public void ChangeBetStatus(string status, Guid betId)
        {
            GetBetByGuid(betId);
        }
    }
}