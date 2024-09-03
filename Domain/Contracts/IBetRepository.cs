using BetPay.Entities;

namespace Domain.Contracts;

public interface IBetRepository : IRepositoryBase<Bet>
{
    Task<IEnumerable<Bet>> GetAllBetsAsync();

    Task<Bet> GetBetByGuid(Guid id);

    void DeleteBet(Bet bet);

    void UpdateBet(Bet bet);

    void CreateBet(Bet bet);
}