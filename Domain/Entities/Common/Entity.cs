namespace Domain.Entities.Common;

public abstract class Entity
{
    public DateTime CreatedOn { get; set; } = DateTime.UtcNow;
    public string? CreatedBy { get; set; } = "ADMIN";

    public DateTime? UpdatedOn { get; set; } = DateTime.UtcNow;
    public string? UpdatedBy { get; set; }
}