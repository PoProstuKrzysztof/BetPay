using BetPay.Enums;
using System.ComponentModel.DataAnnotations;

namespace BetPay.Models;

public class Bet
{
    public Bet()
    {
        Id = Guid.NewGuid();
        BetDate = DateTime.UtcNow;
    }

    public Guid Id { get; init; }

    
    public required decimal TotalOdds { get; set; }

    
    public required decimal Stake { get; set; }

    public DateTime BetDate { get; set; }
    public BetStatusEnum IsWinning { get; set; } = BetStatusEnum.Unfinished;

    public bool IsTaxIncluded { get; set; } = true;

    public decimal PotentialWin { get; set; }

    public decimal CalculatePotentialWin()
    {
        if (IsTaxIncluded.Equals(true))
        {
            return PotentialWin = Math.Round(Stake * TotalOdds) * 0.86M;
        }

        return PotentialWin = Math.Round(Stake * TotalOdds);
    }
}