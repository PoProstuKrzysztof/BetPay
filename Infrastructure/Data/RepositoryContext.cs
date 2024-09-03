using BetPay.Entities;
using BetPay.Enums;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data;

public class RepositoryContext : DbContext
{
    public RepositoryContext(DbContextOptions<RepositoryContext> options) : base(options)
    {
    }

    public virtual DbSet<Bet> Bets { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Event> Events { get; set; }

    public virtual DbSet<EventType> EventTypes { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Category>().HasData(
            new Category { CategoryId = 1, Name = "Football" },
            new Category { CategoryId = 2, Name = "Soccer" },
            new Category { CategoryId = 3, Name = "Tennis" }
        );

        modelBuilder.Entity<EventType>().HasData(
            new EventType { EventTypeId = 1, Name = "BTTS" },
            new EventType { EventTypeId = 2, Name = "Statistical" },
            new EventType { EventTypeId = 3, Name = "1X2" },
            new EventType { EventTypeId = 4, Name = "Above/Under" }
        );

        var betId1 = Guid.NewGuid();
        var betId2 = Guid.NewGuid();
        var betId3 = Guid.NewGuid();
        var betId4 = Guid.NewGuid();
        var betId5 = Guid.NewGuid();

        modelBuilder.Entity<Bet>().HasData(
            new Bet { BetId = betId1, TotalOdds = 2.75m, Stake = 50m, BetDate = new DateTime(2024, 9, 2), Year = 2024, Month = 9, DayOfWeek = (int)DateTime.Now.DayOfWeek, IsWinning = BetStatusEnum.Won, IsTaxIncluded = true, Bookmaker = "SUPERBET" },
            new Bet { BetId = betId2, TotalOdds = 3.50m, Stake = 100m, BetDate = new DateTime(2024, 9, 2), Year = 2024, Month = 9, DayOfWeek = (int)DateTime.Now.DayOfWeek, IsWinning = BetStatusEnum.Lost, IsTaxIncluded = true, Bookmaker = "STS" },
            new Bet { BetId = betId3, TotalOdds = 4.00m, Stake = 200m, BetDate = new DateTime(2024, 9, 2), Year = 2024, Month = 9, DayOfWeek = (int)DateTime.Now.DayOfWeek, IsWinning = BetStatusEnum.Unfinished, IsTaxIncluded = true, Bookmaker = "FORTUNA" },
            new Bet { BetId = betId4, TotalOdds = 1.90m, Stake = 75m, BetDate = new DateTime(2024, 9, 2), Year = 2024, Month = 9, DayOfWeek = (int)DateTime.Now.DayOfWeek, IsWinning = BetStatusEnum.Unfinished, IsTaxIncluded = false, Bookmaker = "BETCLIC" },
            new Bet { BetId = betId5, TotalOdds = 2.25m, Stake = 150m, BetDate = new DateTime(2024, 9, 2), Year = 2024, Month = 9, DayOfWeek = (int)DateTime.Now.DayOfWeek, IsWinning = BetStatusEnum.Won, IsTaxIncluded = true, Bookmaker = "BETFAN" }
        );

        modelBuilder.Entity<Event>().HasData(

            new Event { EventId = Guid.NewGuid(), Odds = 1.5, CategoryId = 1, EventTypeId = 1, BetId = betId1 },
            new Event { EventId = Guid.NewGuid(), Odds = 2.0, CategoryId = 2, EventTypeId = 2, BetId = betId1 },

            new Event { EventId = Guid.NewGuid(), Odds = 1.8, CategoryId = 1, EventTypeId = 3, BetId = betId2 },
            new Event { EventId = Guid.NewGuid(), Odds = 2.2, CategoryId = 3, EventTypeId = 4, BetId = betId2 },

            new Event { EventId = Guid.NewGuid(), Odds = 1.6, CategoryId = 2, EventTypeId = 1, BetId = betId3 },
            new Event { EventId = Guid.NewGuid(), Odds = 2.5, CategoryId = 1, EventTypeId = 3, BetId = betId3 },

            new Event { EventId = Guid.NewGuid(), Odds = 2.0, CategoryId = 3, EventTypeId = 4, BetId = betId4 },
            new Event { EventId = Guid.NewGuid(), Odds = 1.7, CategoryId = 2, EventTypeId = 2, BetId = betId4 },

            new Event { EventId = Guid.NewGuid(), Odds = 2.1, CategoryId = 1, EventTypeId = 3, BetId = betId5 },
            new Event { EventId = Guid.NewGuid(), Odds = 2.3, CategoryId = 3, EventTypeId = 4, BetId = betId5 }
        );
    }
}