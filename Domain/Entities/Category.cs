using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities;

public class Category
{
    [Key]
    [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
    public int CategoryId { get; set; }

    public string Name { get; set; }

    // Relationships

    public virtual ICollection<Event> Events { get; set; }

    public virtual ICollection<EventType>? EventTypes { get; set; }
}