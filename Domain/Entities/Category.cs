using Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace BetPay.Entities;

public class Category
{
    [Key]
    public int CategoryId { get; set; }

    public string Name { get; set; }

    // Relationships

    public ICollection<Event> Events { get; set; }
}