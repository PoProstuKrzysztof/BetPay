using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;

/// <summary>
/// Category and event type entity for event category type accumulation charts
/// </summary>
public class EventCategoryChart
{
    public EventCategoryChart(string? category, double percentage)
    {
        Category = category;
        Percentage = percentage;
    }
    public string? Category { get; set; }
    public double Percentage { get; set; }
}
