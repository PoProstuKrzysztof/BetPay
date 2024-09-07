using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

public class Category
{
    [Key]
    public int CategoryId { get; set; }

    public string Name { get; set; }

    // Relationships

    public virtual ICollection<Event> Events { get; set; }
}