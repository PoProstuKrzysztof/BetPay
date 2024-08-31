using BetPay.Entities;

namespace BetPay.Repositories;

public static class BetRepository
{
    private static List<Bet> bets = new List<Bet>
        {
            new Bet
            {
                TotalOdds = 2.5m,
                Stake = 100.00m,
                BetDate = new DateTime(2024, 8, 15),
                IsWinning = Enums.BetStatusEnum.Won
            },
            new Bet
            {
                TotalOdds = 1.8m,
                Stake = 50.00m,
                BetDate = new DateTime(2024, 8, 16),
                IsWinning = Enums.BetStatusEnum.Lost
            },
            new Bet
            {
                TotalOdds = 3.2m,
                Stake = 75.00m,
                BetDate = new DateTime(2024, 8, 17),
                IsWinning = Enums.BetStatusEnum.Unfinished
            },
            new Bet
            {
                TotalOdds = 4.0m,
                Stake = 150.00m,
                BetDate = new DateTime(2024, 8, 18),
                IsWinning = Enums.BetStatusEnum.Won
            },
            new Bet
            {
                TotalOdds = 2.0m,
                Stake = 200.00m,
                BetDate = new DateTime(2024, 8, 19),
                IsWinning = Enums.BetStatusEnum.Won
            },
            new Bet
            {
                TotalOdds = 3.5m,
                Stake = 120.00m,
                BetDate = new DateTime(2024, 8, 20),
                IsWinning = Enums.BetStatusEnum.Lost
            },
            new Bet
            {
                TotalOdds = 1.9m,
                Stake = 90.00m,
                BetDate = new DateTime(2024, 8, 21),
                IsWinning = Enums.BetStatusEnum.Unfinished
            }
        };

    public static void AddBet(Bet bet)
    {
        bets.Add(bet);
    }

    public static List<Bet> GetBets() => bets;

    public static Bet GetBetByGuid(Guid guid)
    {
        var bet = bets.FirstOrDefault(s => s.Id == guid);
        if (bet != null)
        {
            return new Bet
            {
                TotalOdds = bet.TotalOdds,
                Stake = bet.Stake,
                BetDate = bet.BetDate,
                IsWinning = bet.IsWinning
            };
        }

        return null;
    }

    public static void UpdateBet(Guid id, Bet bet)
    {
        if (id != bet.Id) return;

        var betToUpdate = bets.FirstOrDefault(x => x.Id == id);

        if (betToUpdate != null)
        {
            betToUpdate.IsWinning = bet.IsWinning;
            betToUpdate.Stake = bet.Stake;
            betToUpdate.TotalOdds = bet.TotalOdds;
        }
    }

    public static void DeleteBet(Guid id)
    {
        Bet? bet = bets.FirstOrDefault(x => x.Id == id);

        if (bet != null)
        {
            bets.Remove(bet);
        }
    }
}