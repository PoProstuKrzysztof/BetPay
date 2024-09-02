using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

public class EventType
{
    [Key]
    public int EventTypeId { get; init; }

    public string Name { get; set; }
}