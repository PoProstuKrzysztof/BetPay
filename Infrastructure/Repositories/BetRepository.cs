using Application.Contracts;
using Domain.Entities;
using Domain.Enums;
using Infrastructure.Data;
using Infrastructure.Exceptions;
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
            try
            {
                return await FindAll()
                .Result
                .OrderByDescending(x => x.BetDate)
                .Include(b => b.EventsList)
                .Include(b => b.Bookmaker)
                .ToListAsync();
            }
            catch (Exception ex)
            {
                throw new RetrieveException("Failed to retrieve bets from the database.", nameof(Bet), ex);
            }
        }
        public async Task<IEnumerable<MonthlyIncomeChart>> GetAllMonthlyIncomeSummariesAsync()
        {
            try
            {

                var allBets = await FindAll()
                    .Result
                    .Include(b => b.EventsList)
                    .ToListAsync();

               // Grouping by month and year
                var incomeByMonth = allBets
                    .GroupBy(b => new { b.BetDate.Year, b.BetDate.Month })
                    .Select(g =>
                    {
                       // Calculating monthly income
                        decimal monthlyIncome = g.Sum(b =>
                        {                   
                           return b.Status == StatusEnum.Won ? (b.PotentialWin  ?? 0) : -b.Stake;
                        });

                        return new MonthlyIncomeChart(g.Key.Year, g.Key.Month, monthlyIncome);
                    })
                    .OrderBy(x => x.MonthDate)
                    .ToList();

                return incomeByMonth;
            }
            catch (Exception ex)
            {
                throw new RetrieveException("Failed to retrieve monthly income summaries.", nameof(Bet), ex);
            }
        }
        public async Task<Bet> GetBetByGuid(Guid id)
        {
            try
            {
                return await FindByCondition(x => x.BetId.Equals(id))
                    .Result
                    .Include(el => el.EventsList)
                    .Include(b => b.Bookmaker)
                    .FirstAsync();
            }
            catch (Exception ex)
            {
                throw new RetrieveException($"Failed to retrieve bet with ID: {id}.", nameof(Bet), ex);
            }
        }

        public void CreateBet(Bet bet)
        {
            try
            {
                var bookmaker = RepositoryContext.Set<Bookmaker>()
                .First(x => x.BookmakerId == bet.BookmakerId);

                if (bookmaker == null)
                {
                    throw new CreateException("Bookmaker not found for bet creation.", nameof(Bet));
                }

                RepositoryContext.Attach(bookmaker);
                bet.Bookmaker = bookmaker;

                RepositoryContext.Entry(bet).State = EntityState.Added;

                Create(bet);
            }
            catch (Exception ex)
            {
                throw new CreateException("Failed to create bet.", nameof(Bet), ex);
            }
        }

        public void DeleteBet(Bet bet)
        {
            try
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
            catch (Exception ex)
            {
                throw new DeleteException($"Failed to delete bet with ID: {bet.BetId}.", nameof(Bet), ex);
            }
        }

        public void UpdateBet(Bet bet)
        {
            try
            {
                var local = RepositoryContext.Set<Bet>()
                        .Local.FirstOrDefault(e => e.BetId.Equals(bet.BetId));

                if (local != null)
                {
                    RepositoryContext.Entry(local).State = EntityState.Detached;
                }

                RepositoryContext.Entry(bet).State = EntityState.Modified;

                Update(bet);
            }
            catch (Exception ex)
            {
                throw new UpdateException($"Failed to update bet with ID: {bet.BetId}.", nameof(Bet), ex);
            }
        }
    }
}