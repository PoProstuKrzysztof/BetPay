using Domain.Entities;

namespace Application.Contracts;

public interface IBetRepository : IRepositoryBase<Bet>
{
    Task<IEnumerable<Bet>> GetAllBetsAsync();

    Task<IEnumerable<MonthlyBalance>> GetAllMonthlyBalanceSummariesAsync();

    Task<Bet> GetBetByGuid(Guid id);

    void DeleteBet(Bet bet);

    void UpdateBet(Bet bet);

    void CreateBet(Bet bet);
}