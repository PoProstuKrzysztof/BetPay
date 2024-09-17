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

    public virtual DbSet<Bookmaker> Bookmakers { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Category>().HasData(
            new Category { CategoryId = 1, Name = "Football" },
            new Category { CategoryId = 2, Name = "Soccer" },
            new Category { CategoryId = 3, Name = "Tennis" },
             new Category { CategoryId = 4, Name = "Basketball" }
        );

        modelBuilder.Entity<EventType>().HasData(
            new EventType { EventTypeId = 1, Name = "BTTS" },
            new EventType { EventTypeId = 2, Name = "1X2" },
            new EventType { EventTypeId = 3, Name = "Over/Under Goals" },
            new EventType { EventTypeId = 4, Name = "Corners" },
            new EventType { EventTypeId = 5, Name = "Yellow Cards" },
            new EventType { EventTypeId = 6, Name = "Correct Score" },
            new EventType { EventTypeId = 7, Name = "Double Chance" },
            new EventType { EventTypeId = 8, Name = "First Goal Scorer" },
            new EventType { EventTypeId = 9, Name = "Last Goal Scorer" },
            new EventType { EventTypeId = 10, Name = "Player to Score Anytime" },
            new EventType { EventTypeId = 11, Name = "Clean Sheet" },
            new EventType { EventTypeId = 12, Name = "Team to Win Both Halves" },
            new EventType { EventTypeId = 13, Name = "Half-Time Result" },
            new EventType { EventTypeId = 14, Name = "Full-Time Result" },
            new EventType { EventTypeId = 15, Name = "Half-Time/Full-Time" },
            new EventType { EventTypeId = 16, Name = "Team to Score First" },
            new EventType { EventTypeId = 17, Name = "First Half Goals" },
            new EventType { EventTypeId = 18, Name = "Second Half Goals" }
        );

        var betId1 = Guid.NewGuid();
        var betId2 = Guid.NewGuid();
        var betId3 = Guid.NewGuid();
        var betId4 = Guid.NewGuid();
        var betId5 = Guid.NewGuid();

        modelBuilder.Entity<Bookmaker>().HasData(
            new Bookmaker { BookmakerId = 1, Name = "Betclic", ImagePath = "/Images/Bookmakers/betclic-icon.jpg" },
            new Bookmaker { BookmakerId = 2, Name = "Superbet" },
            new Bookmaker { BookmakerId = 3, Name = "Fortuna" },
            new Bookmaker { BookmakerId = 4, Name = "STS" },
            new Bookmaker { BookmakerId = 5, Name = "Betfan" },
            new Bookmaker { BookmakerId = 6, Name = "Fuksiarz" },
            new Bookmaker { BookmakerId = 7, Name = "LvBet" },
            new Bookmaker { BookmakerId = 8, Name = "Betters" },
            new Bookmaker { BookmakerId = 9, Name = "Betcris" },
            new Bookmaker { BookmakerId = 10, Name = "GoBet" },
            new Bookmaker { BookmakerId = 11, Name = "TotalBet" },
            new Bookmaker { BookmakerId = 12, Name = "ForBet" },
            new Bookmaker { BookmakerId = 13, Name = "Etoto" },
            new Bookmaker { BookmakerId = 14, Name = "ComeOn" }

            );

        modelBuilder.Entity<Bet>()
        .HasMany(b => b.EventsList)
        .WithOne(e => e.Bet)
        .HasForeignKey(e => e.BetId)
        .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Bet>().HasData(
            new Bet { BetId = betId1, Stake = 50m, BetDate = new DateTime(2024, 9, 2), IsTaxIncluded = true, BookmakerId = 2 },
            new Bet { BetId = betId2, Stake = 100m, BetDate = new DateTime(2024, 9, 2), IsTaxIncluded = true, BookmakerId = 3 },
            new Bet { BetId = betId3, Stake = 200m, BetDate = new DateTime(2024, 9, 2), IsTaxIncluded = true, BookmakerId = 2 },
            new Bet { BetId = betId4, Stake = 75m, BetDate = new DateTime(2024, 9, 2), IsTaxIncluded = false, BookmakerId = 1 },
            new Bet { BetId = betId5, Stake = 150m, BetDate = new DateTime(2024, 9, 2), BookmakerId = 4 }
        );

        modelBuilder.Entity<Event>().HasData(

            new Event { EventId = Guid.NewGuid(), Odds = 1.5m, CategoryId = 1, EventTypeId = 1, BetId = betId1, Status = StatusEnum.Won },
            new Event { EventId = Guid.NewGuid(), Odds = 2.0m, CategoryId = 2, EventTypeId = 2, BetId = betId1, Status = StatusEnum.Won },

            new Event { EventId = Guid.NewGuid(), Odds = 1.8m, CategoryId = 1, EventTypeId = 3, BetId = betId2, Status = StatusEnum.Won },
            new Event { EventId = Guid.NewGuid(), Odds = 2.2m, CategoryId = 3, EventTypeId = 4, BetId = betId2, Status = StatusEnum.Lost },

            new Event { EventId = Guid.NewGuid(), Odds = 1.6m, CategoryId = 2, EventTypeId = 1, BetId = betId3, Status = StatusEnum.Unfinished },
            new Event { EventId = Guid.NewGuid(), Odds = 2.5m, CategoryId = 1, EventTypeId = 3, BetId = betId3, Status = StatusEnum.Unfinished },

            new Event { EventId = Guid.NewGuid(), Odds = 2.0m, CategoryId = 3, EventTypeId = 4, BetId = betId4, Status = StatusEnum.Won },
            new Event { EventId = Guid.NewGuid(), Odds = 1.7m, CategoryId = 2, EventTypeId = 2, BetId = betId4, Status = StatusEnum.Unfinished },

            new Event { EventId = Guid.NewGuid(), Odds = 2.1m, CategoryId = 1, EventTypeId = 3, BetId = betId5, Status = StatusEnum.Won },
            new Event { EventId = Guid.NewGuid(), Odds = 2.3m, CategoryId = 3, EventTypeId = 4, BetId = betId5, Status = StatusEnum.Won }
        );
    }
}