using BetPay.Enums;
using Domain.Validators;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities;

public class Bet
{
    [Key]
    [DatabaseGeneratedAttribute(DatabaseGeneratedOption.None)]
    public Guid BetId { get; init; } = Guid.NewGuid();

    public decimal Stake { get; set; }

    public DateTime BetDate { get; set; }

    public StatusEnum? Status
    {
        get
        {
            if (EventsList == null || !EventsList.Any())
            {
                return StatusEnum.Unfinished;
            }

            if (EventsList.Any(e => e.Status == StatusEnum.Lost))
            {
                return StatusEnum.Lost;
            }
            else if (EventsList.All(e => e.Status == StatusEnum.Won))
            {
                return StatusEnum.Won;
            }

            return StatusEnum.Unfinished;
        }
    }

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
            if (EventsList == null || !EventsList.Any())
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

    // Relationships

    public virtual ICollection<Event> EventsList { get; set; } = new List<Event>();

    [CustomValidationsBookmakerId]
    public int BookmakerId { get; set; }

    public virtual Bookmaker? Bookmaker { get; set; }
}