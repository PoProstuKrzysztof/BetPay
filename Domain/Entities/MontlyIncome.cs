using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Domain.Entities;

/// <summary>
/// Entity for chart monthly income from bets
/// </summary>
public class MonthlyIncome
{
    public DateTime MonthDate { get; set; }
    public decimal NetIncome { get; set; }

    public MonthlyIncome(int year, int month, decimal netIncome)
    {
        MonthDate = new DateTime(year, month, 1); 
        NetIncome = Math.Round(netIncome,2);
    }

 
}