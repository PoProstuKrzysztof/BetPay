using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

public class Bookmaker
{
    [Key]
    public int BookmakerId { get; init; }

    public string? Name { get; set; }

    public string? ImagePath { get; set; }

    public virtual ICollection<Bet>? BetList { get; set; }
}