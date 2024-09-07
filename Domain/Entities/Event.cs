using BetPay.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities;

public class Event
{
    [Key]
    [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
    public Guid EventId { get; init; }

    [Required]
    public double Odds { get; set; }


    public BetStatusEnum Status { get; set; } = BetStatusEnum.Unfinished;

    // Relationships
    public int CategoryId { get; set; }

    public virtual Category Category { get; set; }

    public int EventTypeId { get; set; }
    public virtual EventType EventType { get; set; }

    public Guid? BetId { get; set; }

    public virtual Bet Bet { get; set; }
}