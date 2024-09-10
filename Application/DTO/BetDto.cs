using BetPay.Enums;
using System.ComponentModel.DataAnnotations;

namespace Application.DTO;
public record BetDto
{
    [Required(ErrorMessage = "Stake is required")]
    [Range(0.1, double.MaxValue, ErrorMessage = "Stake must be a positive value")]
    public decimal Stake { get; set; }

    public DateTime BetDate { get; set; }

    public int Month { get; set; }

    public int DayOfWeek { get; set; }

    public string? Bookmaker { get; set; }

    [Required(ErrorMessage = "Status is required")]
    public StatusEnum Status { get; set; }

    [Required(ErrorMessage = "Tax information is required")]
    public bool IsTaxIncluded { get; set; }

    [Required]
    [Range(0.01, double.MaxValue, ErrorMessage = "Potential win must be greater than 0")]
    public decimal PotentialWin { get; set; }
}