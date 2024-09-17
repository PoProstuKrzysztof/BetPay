using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities;

public class Bookmaker
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public int BookmakerId { get; init; }

    public string? Name { get; set; }

    public string? ImagePath { get; set; }

    public virtual ICollection<Bet>? BetList { get; set; }
}