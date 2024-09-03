using BetPay.Enums;
using Domain.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BetPay.Entities;

public class Bet
{
    [Key]
    [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
    public Guid BetId { get; init; }

    public decimal TotalOdds { get; set; }

    public decimal Stake { get; set; }

    public DateTime BetDate { get; set; }

    public int Year { get; set; }
    public int Month { get; set; }
    public int DayOfWeek { get; set; }
    public string? Bookmaker { get; set; }
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

    // Relationships

    public ICollection<Event> EventsList { get; set; }
}