using Domain.Entities.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities;

public class EventType : Entity
{
    [Key]
    [DatabaseGeneratedAttribute(DatabaseGeneratedOption.None)]
    public int EventTypeId { get; init; }

    public string Name { get; set; }

    public virtual ICollection<Event> Events { get; set; }

    [ForeignKey("CategoryId")]
    public int CategoryId { get; set; }

    public virtual Category? Category { get; set; }
}