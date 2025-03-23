using Domain.Entities.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities;

public class Category : Entity
{
    [Key]
    [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
    public int CategoryId { get; init; }

    public string Name { get; set; }

    public virtual ICollection<Event> Events { get; set; }

    public virtual ICollection<EventType>? EventTypes { get; set; }
}