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

    public string? Bookmaker { get; set; }
    public StatusEnum Status { get; private set; } = StatusEnum.Unfinished;

    public bool IsTaxIncluded { get; set; } = true;

    [NotMapped]
    public decimal PotentialWin
    {
        get
        {
            decimal win = Math.Round(Stake * TotalOdds);
            return IsTaxIncluded ? win * 0.86M : win;
        }
    }

    [NotMapped]
    public decimal TotalOdds
    {
        get
        {
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

    public virtual ICollection<Event> EventsList { get; set; }
}