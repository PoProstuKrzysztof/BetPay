using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities;

public class EventType
{
    [Key]
    [DatabaseGeneratedAttribute(DatabaseGeneratedOption.None)]
    public int EventTypeId { get; set; }

    public string Name { get; set; }

    //Relationships
    public virtual ICollection<Event> Events { get; set; }

    public int CategoryId { get; set; }
    public virtual Category? Category { get; set; }
}