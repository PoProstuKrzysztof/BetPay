﻿using Domain.Enums;
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

    public LivePrematchEnum LivePrematch { get; set; }

    /// <summary>
    /// Check the status of the bet based on the event's statuses involved in this bet 
    /// </summary>
    public StatusEnum Status
    {
        get
        {
            if (EventsList == null || !EventsList.Any())
            {
                return StatusEnum.Pending;
            }

            if (EventsList.Any(e => e.Status == StatusEnum.Lost))
            {
                return StatusEnum.Lost;
            }
            else if (EventsList.All(e => e.Status == StatusEnum.Won))
            {
                return StatusEnum.Won;
            }

            return StatusEnum.Pending;
        }
    }

    public bool IsTaxIncluded { get; set; } = true;

    /// <summary>
    /// In Poland, the tax on betting is 14%. When above 2280 zł, an additional 10% is applied.
    /// </summary>
    [NotMapped]
    public decimal? PotentialWin
    {
        get
        {
            if (TotalOdds != 0)
            {
                decimal win = Math.Round((decimal)(Stake * TotalOdds), 2);

                // Apply 10% if above 2280
                if (win > 2280)
                {
                    win = win * 0.90M;
                }

                if (Bookmaker.Name.Equals("Fortuna") && !IsTaxIncluded)
                {
                    win = win * 0.14M;
                }

                //TO DO:
                //Fortuna applies additional 0.14% multiplier when playing live with 3 or more events

                // Apply tax if tax is included
                return IsTaxIncluded ? (win * 0.86M) : win;
            }

            return 0;
        }
    }

    /// <summary>
    /// Total odds of the bet calculated based on sum of related events odds.
    /// </summary>
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

            foreach (var @event in EventsList)
            {
                totalOdds *= @event.Odds;
            }

            return Math.Round(totalOdds,2);
        }
    }


    [NotMapped]

    // Relationships

    public virtual ICollection<Event> EventsList { get; set; } = new List<Event>();

    [CustomValidationsBookmakerId]
    public int BookmakerId { get; set; }

    public virtual Bookmaker? Bookmaker { get; set; }
}