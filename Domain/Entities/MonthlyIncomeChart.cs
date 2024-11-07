using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Domain.Entities;

/// <summary>
/// Monthly income from bets for charts entity
/// </summary>
public class MonthlyIncomeChart
{
    public DateTime MonthDate { get; set; }
    public decimal NetIncome { get; set; }

    public MonthlyIncomeChart(int year, int month, decimal netIncome)
    {
        MonthDate = new DateTime(year, month, 1); 
        NetIncome = Math.Round(netIncome,2);
    }

 
}