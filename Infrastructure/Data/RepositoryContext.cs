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
        var betId6 = Guid.NewGuid();
        var betId7 = Guid.NewGuid();
        var betId8 = Guid.NewGuid();
        var betId9 = Guid.NewGuid();
        var betId10 = Guid.NewGuid();
        var betId11 = Guid.NewGuid();
        var betId12 = Guid.NewGuid();
        var betId13 = Guid.NewGuid();
        var betId14 = Guid.NewGuid();
        var betId15 = Guid.NewGuid();
        var betId16 = Guid.NewGuid();
        var betId17 = Guid.NewGuid();
        var betId18 = Guid.NewGuid();
        var betId19 = Guid.NewGuid();
        var betId20 = Guid.NewGuid();

        modelBuilder.Entity<Bookmaker>().HasData(
            new Bookmaker { BookmakerId = 1, Name = "Betclic", ImagePath = "/Images/Bookmakers/betclic-icon.jpg" },
            new Bookmaker { BookmakerId = 2, Name = "Superbet", ImagePath = "/Images/Bookmakers/superbet-icon.jpg" },
            new Bookmaker { BookmakerId = 3, Name = "Fortuna", ImagePath = "/Images/Bookmakers/fortuna-icon.jpg" },
            new Bookmaker { BookmakerId = 4, Name = "STS", ImagePath = "/Images/Bookmakers/sts-icon.jpg" },
            new Bookmaker { BookmakerId = 5, Name = "Betfan", ImagePath = "/Images/Bookmakers/betfan-icon.jpg" },
            new Bookmaker { BookmakerId = 6, Name = "Fuksiarz", ImagePath = "/Images/Bookmakers/fuksiarz-icon.jpg" },
            new Bookmaker { BookmakerId = 7, Name = "LvBet", ImagePath = "/Images/Bookmakers/lvbet-icon.jpg" },
            new Bookmaker { BookmakerId = 8, Name = "Betters", ImagePath = "/Images/Bookmakers/betters-icon.jpg" },
            new Bookmaker { BookmakerId = 9, Name = "Betcris", ImagePath = "/Images/Bookmakers/betcris-icon.jpg" },
            new Bookmaker { BookmakerId = 10, Name = "GoBet", ImagePath = "/Images/Bookmakers/gobet-icon.jpg" },
            new Bookmaker { BookmakerId = 11, Name = "TotalBet", ImagePath = "/Images/Bookmakers/totalbet-icon.jpg" },
            new Bookmaker { BookmakerId = 12, Name = "ForBet", ImagePath = "/Images/Bookmakers/forbet-icon.jpg" },
            new Bookmaker { BookmakerId = 13, Name = "Etoto", ImagePath = "/Images/Bookmakers/etoto-icon.jpg" },
            new Bookmaker { BookmakerId = 14, Name = "ComeOn", ImagePath = "/Images/Bookmakers/ComeOn-icon.jpg" }

            );

        modelBuilder.Entity<Bet>()
        .HasMany(b => b.EventsList)
        .WithOne(e => e.Bet)
        .HasForeignKey(e => e.BetId)
        .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Bet>().HasData(
        new Bet { BetId = betId1, Stake = 50m, BetDate = new DateTime(2023, 7, 2), IsTaxIncluded = true, BookmakerId = 2 },
        new Bet { BetId = betId2, Stake = 100m, BetDate = new DateTime(2023, 5, 10), IsTaxIncluded = true, BookmakerId = 3 },
        new Bet { BetId = betId3, Stake = 200m, BetDate = new DateTime(2023, 8, 15), IsTaxIncluded = false, BookmakerId = 1 },
        new Bet { BetId = betId4, Stake = 75m, BetDate = new DateTime(2023, 9, 2), IsTaxIncluded = false, BookmakerId = 4 },
        new Bet { BetId = betId5, Stake = 150m, BetDate = new DateTime(2023, 12, 1), BookmakerId = 11 },

        // Zakłady z bieżącego roku
        new Bet { BetId = betId6, Stake = 120m, BetDate = new DateTime(2024, 3, 14), BookmakerId = 5 },
        new Bet { BetId = betId7, Stake = 90m, BetDate = new DateTime(2024, 4, 20), BookmakerId = 13 },
        new Bet { BetId = betId8, Stake = 60m, BetDate = new DateTime(2024, 2, 5), BookmakerId = 10 },
        new Bet { BetId = betId9, Stake = 40m, BetDate = new DateTime(2024, 6, 30), BookmakerId = 1 },
        new Bet { BetId = betId10, Stake = 80m, BetDate = new DateTime(2024, 7, 15), BookmakerId = 7 },

        new Bet { BetId = betId11, Stake = 110m, BetDate = new DateTime(2024, 8, 18), BookmakerId = 4 },
        new Bet { BetId = betId12, Stake = 70m, BetDate = new DateTime(2024, 9, 2), BookmakerId = 2 },
        new Bet { BetId = betId13, Stake = 95m, BetDate = new DateTime(2024, 9, 5), BookmakerId = 3 },
        new Bet { BetId = betId14, Stake = 105m, BetDate = new DateTime(2024, 9, 8), BookmakerId = 13 },
        new Bet { BetId = betId15, Stake = 130m, BetDate = new DateTime(2024, 10, 10), BookmakerId = 5 },

        new Bet { BetId = betId16, Stake = 85m, BetDate = new DateTime(2024, 10, 15), BookmakerId = 11 },
        new Bet { BetId = betId17, Stake = 45m, BetDate = new DateTime(2024, 10, 20), BookmakerId = 10 },
        new Bet { BetId = betId18, Stake = 65m, BetDate = new DateTime(2024, 11, 2), BookmakerId = 1 },
        new Bet { BetId = betId19, Stake = 150m, BetDate = new DateTime(2024, 12, 1), BookmakerId = 7 }
    );

        // Zdarzenia
        modelBuilder.Entity<Event>().HasData(
            // Zakład 1 - 3 zdarzenia
            new Event { EventId = Guid.NewGuid(), Odds = 1.5m, CategoryId = 1, EventTypeId = 1, BetId = betId1, Status = StatusEnum.Won },
            new Event { EventId = Guid.NewGuid(), Odds = 2.0m, CategoryId = 2, EventTypeId = 2, BetId = betId1, Status = StatusEnum.Won },
            new Event { EventId = Guid.NewGuid(), Odds = 1.7m, CategoryId = 3, EventTypeId = 3, BetId = betId1, Status = StatusEnum.Won },

            // Zakład 2 - 4 zdarzenia
            new Event { EventId = Guid.NewGuid(), Odds = 1.6m, CategoryId = 2, EventTypeId = 1, BetId = betId2, Status = StatusEnum.Lost },
            new Event { EventId = Guid.NewGuid(), Odds = 2.3m, CategoryId = 1, EventTypeId = 4, BetId = betId2, Status = StatusEnum.Won },
            new Event { EventId = Guid.NewGuid(), Odds = 2.1m, CategoryId = 2, EventTypeId = 5, BetId = betId2, Status = StatusEnum.Won },
            new Event { EventId = Guid.NewGuid(), Odds = 1.8m, CategoryId = 1, EventTypeId = 6, BetId = betId2, Status = StatusEnum.Unfinished },

            // Zakład 3 - 5 zdarzenia
            new Event { EventId = Guid.NewGuid(), Odds = 1.5m, CategoryId = 2, EventTypeId = 3, BetId = betId3, Status = StatusEnum.Won },
            new Event { EventId = Guid.NewGuid(), Odds = 1.7m, CategoryId = 1, EventTypeId = 1, BetId = betId3, Status = StatusEnum.Won },
            new Event { EventId = Guid.NewGuid(), Odds = 2.4m, CategoryId = 3, EventTypeId = 4, BetId = betId3, Status = StatusEnum.Won },
            new Event { EventId = Guid.NewGuid(), Odds = 2.1m, CategoryId = 2, EventTypeId = 5, BetId = betId3, Status = StatusEnum.Unfinished },
            new Event { EventId = Guid.NewGuid(), Odds = 2.5m, CategoryId = 1, EventTypeId = 6, BetId = betId3, Status = StatusEnum.Lost },

            // Zakład 4 - 2 zdarzenia
            new Event { EventId = Guid.NewGuid(), Odds = 2.0m, CategoryId = 3, EventTypeId = 4, BetId = betId4, Status = StatusEnum.Won },
            new Event { EventId = Guid.NewGuid(), Odds = 1.6m, CategoryId = 2, EventTypeId = 1, BetId = betId4, Status = StatusEnum.Won },

            // Zakład 5 - 3 zdarzenia
            new Event { EventId = Guid.NewGuid(), Odds = 1.9m, CategoryId = 1, EventTypeId = 3, BetId = betId5, Status = StatusEnum.Lost },
            new Event { EventId = Guid.NewGuid(), Odds = 2.2m, CategoryId = 2, EventTypeId = 2, BetId = betId5, Status = StatusEnum.Won },
            new Event { EventId = Guid.NewGuid(), Odds = 1.5m, CategoryId = 3, EventTypeId = 5, BetId = betId5, Status = StatusEnum.Unfinished }
        );
    }
}