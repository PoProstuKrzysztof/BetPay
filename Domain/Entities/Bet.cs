using BetPay.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities;

public class Bet
{
    [Key]
    [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
    public Guid BetId { get; init; }

    public decimal Stake { get; set; }

    public DateTime BetDate { get; set; }

    public StatusEnum Status { get; private set; } = StatusEnum.Unfinished;

    public bool IsTaxIncluded { get; set; } = true;

    [NotMapped]
    public decimal? PotentialWin
    {
        get
        {
            if (TotalOdds != 0)
            {
                decimal win = Math.Round((decimal)(Stake * TotalOdds));
                return IsTaxIncluded ? win * 0.86M : win;
            }

            return 0;
        }
    }

    [NotMapped]
    public decimal? TotalOdds
    {
        get
        {
            if (EventsList.Equals(null))
            {
                return 0;
            }

            decimal totalOdds = 1M;

            foreach (var eventItem in EventsList)
            {
                totalOdds *= eventItem.Odds;
            }

            return totalOdds;
        }
    }

    public void UpdateBetStatus()
    {
        if (EventsList == null || !EventsList.Any())
        {
            Status = StatusEnum.Unfinished;
            return;
        }

        if (EventsList.Any(e => e.Status == StatusEnum.Lost))
        {
            Status = StatusEnum.Lost;
        }
        else if (EventsList.All(e => e.Status == StatusEnum.Won))
        {
            Status = StatusEnum.Won;
        }
        else
        {
            Status = StatusEnum.Unfinished;
        }
    }

    // Relationships

    public virtual ICollection<Event> EventsList { get; set; } = new List<Event>();

    public int? BookmakerId { get; set; }
    public virtual Bookmaker? Bookmaker { get; set; }
}