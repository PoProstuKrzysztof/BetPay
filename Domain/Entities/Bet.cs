using BetPay.Enums;
using Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace BetPay.Entities;

public class Bet
{
    public Bet()
    {
        BetId = Guid.NewGuid();
        BetDate = DateTime.UtcNow;
        Year = BetDate.Year;
        Month = BetDate.Month;
        DayOfWeek = (int)BetDate.DayOfWeek;
    }

    [Key]
    public Guid BetId { get; init; }

    public decimal TotalOdds { get; set; }

    public decimal Stake { get; set; }

    public DateTime BetDate { get; set; }

    public int Year { get; set; }
    public int Month { get; set; }
    public int DayOfWeek { get; set; }
    public BetStatusEnum IsWinning { get; set; } = BetStatusEnum.Unfinished;

    public bool IsTaxIncluded { get; set; } = true;

    public decimal PotentialWin
    {
        get
        {
            decimal win = Math.Round(Stake * TotalOdds);
            return IsTaxIncluded ? win * 0.86M : win;
        }
    }

    public List<Event> EventsList { get; set; } = new List<Event>();
}