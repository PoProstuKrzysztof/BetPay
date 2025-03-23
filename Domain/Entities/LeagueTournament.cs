using Domain.Entities.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities;

public class LeagueTournament : Entity
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int LeagueTournamentId { get; set; }

    public int ApiId { get; set; }

    [Required]
    public string Name { get; set; } = string.Empty;

    public string Type { get; set; } = string.Empty;

    public string LogoUrl { get; set; } = string.Empty;

    [ForeignKey("CountryId")]
    public int CountryId { get; set; }

    public virtual Country Country { get; set; } = null!;

    public string CountryCode { get; set; } = string.Empty;

    [ForeignKey("CategoryId")]
    public int? CategoryId { get; set; }

    public virtual Category? Category { get; set; }

    public virtual ICollection<Event>? Events { get; set; }
}