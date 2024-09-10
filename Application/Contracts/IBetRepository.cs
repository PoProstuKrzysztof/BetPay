using Domain.Entities;

namespace Application.Contracts;

public interface IBetRepository : IRepositoryBase<Bet>
{
    Task<IEnumerable<Bet>> GetAllBetsAsync();

    Task<Bet> GetBetByGuid(Guid id);

    void ChangeBetStatus(string status, Guid betId);

    void DeleteBet(Bet bet);

    void UpdateBet(Bet bet);

    void CreateBet(Bet bet);
}