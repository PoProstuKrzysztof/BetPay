using Domain.Entities;
using Domain.Enums;
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

    public virtual DbSet<LeagueTournament> LeagueTournaments { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Category>().HasData(
            new Category { CategoryId = 1, Name = "Football" },
            new Category { CategoryId = 2, Name = "Tennis" },
             new Category { CategoryId = 3, Name = "Basketball" }
        );

        modelBuilder.Entity<EventType>().HasData(
     new EventType { EventTypeId = 1, Name = "BTTS", CategoryId = 1 },
     new EventType { EventTypeId = 2, Name = "1X2", CategoryId = 1 },
     new EventType { EventTypeId = 3, Name = "Over/Under Goals", CategoryId = 1 },
     new EventType { EventTypeId = 4, Name = "Corners", CategoryId = 1 },
     new EventType { EventTypeId = 5, Name = "Yellow Cards", CategoryId = 1 },
     new EventType { EventTypeId = 6, Name = "Correct Score", CategoryId = 1 },
     new EventType { EventTypeId = 7, Name = "Double Chance", CategoryId = 1 },
     new EventType { EventTypeId = 8, Name = "First Goal Scorer", CategoryId = 1 },
     new EventType { EventTypeId = 9, Name = "Last Goal Scorer", CategoryId = 1 },
     new EventType { EventTypeId = 10, Name = "Player to Score Anytime", CategoryId = 1 },
     new EventType { EventTypeId = 11, Name = "Clean Sheet", CategoryId = 1 },
     new EventType { EventTypeId = 12, Name = "Team to Win Both Halves", CategoryId = 1 },
     new EventType { EventTypeId = 13, Name = "Half-Time Result", CategoryId = 1 },
     new EventType { EventTypeId = 14, Name = "Full-Time Result", CategoryId = 1 },
     new EventType { EventTypeId = 15, Name = "Half-Time/Full-Time", CategoryId = 1 },
     new EventType { EventTypeId = 16, Name = "Team to Score First", CategoryId = 1 },
     new EventType { EventTypeId = 17, Name = "First Half Goals", CategoryId = 1 },
     new EventType { EventTypeId = 18, Name = "Second Half Goals", CategoryId = 1 },
     new EventType { EventTypeId = 19, Name = "Total Aces", CategoryId = 2 },
    new EventType { EventTypeId = 20, Name = "Total Double Faults", CategoryId = 2 },
    new EventType { EventTypeId = 21, Name = "Set Winner", CategoryId = 2 },
    new EventType { EventTypeId = 22, Name = "Match Winner", CategoryId = 2 },
    new EventType { EventTypeId = 23, Name = "First Set Winner", CategoryId = 2 },
    new EventType { EventTypeId = 24, Name = "Total Games Over/Under", CategoryId = 2 },
     new EventType { EventTypeId = 25, Name = "First Basket Scorer", CategoryId = 3 },
    new EventType { EventTypeId = 26, Name = "Total Points Over/Under", CategoryId = 3 },
    new EventType { EventTypeId = 27, Name = "Winning Margin", CategoryId = 3 },
    new EventType { EventTypeId = 28, Name = "Most Assists", CategoryId = 3 },
    new EventType { EventTypeId = 29, Name = "Total Rebounds", CategoryId = 3 },
    new EventType { EventTypeId = 30, Name = "First Team to Score 20 Points", CategoryId = 3 }
 );

        var betId1 = Guid.NewGuid();
        var betId2 = Guid.NewGuid();
        var betId3 = Guid.NewGuid();
        var betId4 = Guid.NewGuid();
        var betId5 = Guid.NewGuid();

        modelBuilder.Entity<Bookmaker>().HasData(
            new Bookmaker { BookmakerId = 1, Name = "Betclic", ImagePath = "/Images/Bookmakers/betclic.png" },
            new Bookmaker { BookmakerId = 2, Name = "Superbet", ImagePath = "/Images/Bookmakers/superbet.png" },
            new Bookmaker { BookmakerId = 3, Name = "Fortuna", ImagePath = "/Images/Bookmakers/fortuna.png" },
            new Bookmaker { BookmakerId = 4, Name = "STS", ImagePath = "/Images/Bookmakers/sts.png" },
            new Bookmaker { BookmakerId = 5, Name = "Betfan", ImagePath = "/Images/Bookmakers/betfan.png" },
            new Bookmaker { BookmakerId = 6, Name = "Fuksiarz", ImagePath = "/Images/Bookmakers/fuksiarz.png" },
            new Bookmaker { BookmakerId = 7, Name = "LvBet", ImagePath = "/Images/Bookmakers/lvbet.png" },
            new Bookmaker { BookmakerId = 8, Name = "Betters", ImagePath = "/Images/Bookmakers/betters.png" },
            new Bookmaker { BookmakerId = 9, Name = "Betcris", ImagePath = "/Images/Bookmakers/betcris.png" },
            new Bookmaker { BookmakerId = 10, Name = "GoBet", ImagePath = "/Images/Bookmakers/gobet.png" },
            new Bookmaker { BookmakerId = 11, Name = "TotalBet", ImagePath = "/Images/Bookmakers/totalbet.png" },
            new Bookmaker { BookmakerId = 12, Name = "ForBet", ImagePath = "/Images/Bookmakers/forbet.png" },
            new Bookmaker { BookmakerId = 13, Name = "Etoto", ImagePath = "/Images/Bookmakers/etoto.png" },
            new Bookmaker { BookmakerId = 14, Name = "ComeOn", ImagePath = "/Images/Bookmakers/comeon.png" },
            new Bookmaker { BookmakerId = 15, Name = "Pzbuk", ImagePath = "/Images/Bookmakers/pzbuk.png" }

            );

        modelBuilder.Entity<Bet>().HasData(
        new Bet { BetId = betId1, Stake = 50m, BetDate = new DateTime(2023, 7, 2), IsTaxIncluded = true, BookmakerId = 2, LivePrematch = LivePrematchEnum.Prematch },
        new Bet { BetId = betId2, Stake = 100m, BetDate = new DateTime(2023, 5, 10), IsTaxIncluded = true, BookmakerId = 3, LivePrematch = LivePrematchEnum.Prematch },
        new Bet { BetId = betId3, Stake = 200m, BetDate = new DateTime(2023, 8, 15), IsTaxIncluded = false, BookmakerId = 1, LivePrematch = LivePrematchEnum.Prematch },
        new Bet { BetId = betId4, Stake = 75m, BetDate = new DateTime(2023, 9, 2), IsTaxIncluded = false, BookmakerId = 1, LivePrematch = LivePrematchEnum.Live },
        new Bet { BetId = betId5, Stake = 150m, BetDate = new DateTime(2023, 12, 1), IsTaxIncluded = true, BookmakerId = 5, LivePrematch = LivePrematchEnum.Live }

    );

        modelBuilder.Entity<LeagueTournament>().HasData(
     new LeagueTournament { LeagueTournamentId = 1, Name = "Premier League", CategoryId = 1 },
     new LeagueTournament { LeagueTournamentId = 2, Name = "La Liga", CategoryId = 1 },
     new LeagueTournament { LeagueTournamentId = 3, Name = "Serie A", CategoryId = 1 },
     new LeagueTournament { LeagueTournamentId = 4, Name = "Bundesliga", CategoryId = 1 },
     new LeagueTournament { LeagueTournamentId = 5, Name = "Ligue 1", CategoryId = 1 },
     new LeagueTournament { LeagueTournamentId = 6, Name = "UEFA Champions League", CategoryId = 1 },
     new LeagueTournament { LeagueTournamentId = 7, Name = "UEFA Europa League", CategoryId = 1 },
     new LeagueTournament { LeagueTournamentId = 8, Name = "Euro Cup", CategoryId = 1 },
     new LeagueTournament { LeagueTournamentId = 9, Name = "Copa America", CategoryId = 1 },
     new LeagueTournament { LeagueTournamentId = 10, Name = "FIFA World Cup", CategoryId = 1 },

     new LeagueTournament { LeagueTournamentId = 11, Name = "Wimbledon", CategoryId = 2 },
    new LeagueTournament { LeagueTournamentId = 12, Name = "Roland Garros", CategoryId = 2 },
    new LeagueTournament { LeagueTournamentId = 13, Name = "US Open", CategoryId = 2 },
    new LeagueTournament { LeagueTournamentId = 14, Name = "Australian Open", CategoryId = 2 },
    new LeagueTournament { LeagueTournamentId = 15, Name = "ATP Finals", CategoryId = 2 },

    new LeagueTournament { LeagueTournamentId = 16, Name = "NBA Finals", CategoryId = 3 },
    new LeagueTournament { LeagueTournamentId = 17, Name = "EuroLeague", CategoryId = 3 },
    new LeagueTournament { LeagueTournamentId = 18, Name = "FIBA World Cup", CategoryId = 3 },
    new LeagueTournament { LeagueTournamentId = 19, Name = "NCAA March Madness", CategoryId = 3 },
    new LeagueTournament { LeagueTournamentId = 20, Name = "Olympic Basketball Tournament", CategoryId = 3 }
 );

        modelBuilder.Entity<Event>().HasData(
       new Event { EventId = Guid.NewGuid(), Odds = 1.5m, CategoryId = 1, EventTypeId = 1, BetId = betId1, Status = StatusEnum.Won, LeagueTournamentId = 1 },
       new Event { EventId = Guid.NewGuid(), Odds = 2.0m, CategoryId = 2, EventTypeId = 2, BetId = betId1, Status = StatusEnum.Won, LeagueTournamentId = 8 },
       new Event { EventId = Guid.NewGuid(), Odds = 1.7m, CategoryId = 3, EventTypeId = 3, BetId = betId1, Status = StatusEnum.Won, LeagueTournamentId = 2 },

       new Event { EventId = Guid.NewGuid(), Odds = 1.6m, CategoryId = 2, EventTypeId = 1, BetId = betId2, Status = StatusEnum.Lost, LeagueTournamentId = 7 },
       new Event { EventId = Guid.NewGuid(), Odds = 2.3m, CategoryId = 1, EventTypeId = 4, BetId = betId2, Status = StatusEnum.Won, LeagueTournamentId = 6 },
       new Event { EventId = Guid.NewGuid(), Odds = 2.1m, CategoryId = 2, EventTypeId = 5, BetId = betId2, Status = StatusEnum.Won, LeagueTournamentId = 10 },
       new Event { EventId = Guid.NewGuid(), Odds = 1.8m, CategoryId = 1, EventTypeId = 6, BetId = betId2, Status = StatusEnum.Unfinished, LeagueTournamentId = 2 }
   );

        modelBuilder.Entity<Bet>()
       .HasMany(b => b.EventsList)
       .WithOne(e => e.Bet)
       .HasForeignKey(e => e.BetId)
       .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Event>()
        .HasOne(e => e.Category)
        .WithMany(c => c.Events)
        .HasForeignKey(e => e.CategoryId)
        .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Event>()
        .HasOne(e => e.EventType)
        .WithMany(et => et.Events)
        .HasForeignKey(e => e.EventTypeId)
        .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Event>()
       .HasOne(e => e.LeagueTournament)
       .WithMany()
       .HasForeignKey(e => e.LeagueTournamentId)
       .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<EventType>()
        .HasOne(et => et.Category)
        .WithMany(c => c.EventTypes)
        .HasForeignKey(et => et.CategoryId)
        .OnDelete(DeleteBehavior.Restrict);
    }
}