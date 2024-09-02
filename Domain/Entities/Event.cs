using BetPay.Entities;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

public class Event
{
    public Event()
    {
        EventId = Guid.NewGuid();
    }

    [Key]
    public Guid EventId { get; init; }

    [Required]
    public double Odds { get; set; }

    public Category Category { get; set; }
}