using Domain.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities;

public class Event
{
    [Key]
    [DatabaseGeneratedAttribute(DatabaseGeneratedOption.None)]
    public Guid EventId { get; init; } = Guid.NewGuid();

    public decimal Odds { get; set; }

    public StatusEnum Status { get; set; } = StatusEnum.Pending;

    // Relationships
    public int CategoryId { get; set; }

    public virtual Category Category { get; set; }

    public int EventTypeId { get; set; }
    public virtual EventType EventType { get; set; }

    public int LeagueTournamentId { get; set; }

    public virtual LeagueTournament LeagueTournament { get; set; }

    public Guid? BetId { get; set; }

    public virtual Bet? Bet { get; set; }
}