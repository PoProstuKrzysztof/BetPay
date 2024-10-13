using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities;

public class LeagueTournament
{
    [Key]
    [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
    public int LeagueTournamentId { get; set; }

    public string? Name { get; set; }

    //Relationships
    public int CategoryId { get; set; }

    public virtual Category Category { get; set; }

    public virtual ICollection<Event>? Events { get; set; }
}