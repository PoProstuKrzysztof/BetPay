using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities;

public class EventType
{
    [Key]
    [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
    public int EventTypeId { get; init; }

    public string Name { get; set; }

    //Relationships

    public virtual ICollection<Event> Events { get; set; } = new List<Event>();
}