namespace Domain.Entities;

/// <summary>
/// Monthly income from bets for charts entity
/// </summary>
public class MonthlyBalance
{
    public DateTime MonthDate { get; set; }
    public decimal Balance { get; set; }

    public MonthlyBalance(int year, int month, decimal balance)
    {
        MonthDate = new DateTime(year, month, 1);
        Balance = Math.Round(balance, 2);
    }
}