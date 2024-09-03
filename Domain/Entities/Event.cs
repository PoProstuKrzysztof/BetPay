using BetPay.Entities;
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

    // Relationships
    public int CategoryId { get; set; }

    public Category Category { get; set; }

    public int EventTypeId { get; set; }
    public EventType EventType { get; set; }

    public Guid? BetId { get; set; }

    public Bet Bet { get; set; }
}