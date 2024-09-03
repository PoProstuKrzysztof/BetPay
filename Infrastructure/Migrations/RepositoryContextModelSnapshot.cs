﻿// <auto-generated />
using System;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Infrastructure.Migrations
{
    [DbContext(typeof(RepositoryContext))]
    partial class RepositoryContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BetPay.Entities.Bet", b =>
                {
                    b.Property<Guid>("BetId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("BetDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Bookmaker")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("DayOfWeek")
                        .HasColumnType("int");

                    b.Property<bool>("IsTaxIncluded")
                        .HasColumnType("bit");

                    b.Property<int>("IsWinning")
                        .HasColumnType("int");

                    b.Property<int>("Month")
                        .HasColumnType("int");

                    b.Property<decimal>("Stake")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("TotalOdds")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Year")
                        .HasColumnType("int");

                    b.HasKey("BetId");

                    b.ToTable("Bets");

                    b.HasData(
                        new
                        {
                            BetId = new Guid("dbfdfd8c-309a-4a98-8848-c3cf38a935b3"),
                            BetDate = new DateTime(2024, 9, 2, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Bookmaker = "SUPERBET",
                            DayOfWeek = 1,
                            IsTaxIncluded = true,
                            IsWinning = 0,
                            Month = 9,
                            Stake = 50m,
                            TotalOdds = 2.75m,
                            Year = 2024
                        },
                        new
                        {
                            BetId = new Guid("79feede5-eadb-4d0d-a030-4ca0568640b7"),
                            BetDate = new DateTime(2024, 9, 2, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Bookmaker = "STS",
                            DayOfWeek = 1,
                            IsTaxIncluded = true,
                            IsWinning = 1,
                            Month = 9,
                            Stake = 100m,
                            TotalOdds = 3.50m,
                            Year = 2024
                        },
                        new
                        {
                            BetId = new Guid("6d7a3397-f570-4f02-b053-7898e4647b58"),
                            BetDate = new DateTime(2024, 9, 2, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Bookmaker = "FORTUNA",
                            DayOfWeek = 1,
                            IsTaxIncluded = true,
                            IsWinning = 2,
                            Month = 9,
                            Stake = 200m,
                            TotalOdds = 4.00m,
                            Year = 2024
                        },
                        new
                        {
                            BetId = new Guid("0dd8c5b1-b17c-4f57-99af-b819e90fccf0"),
                            BetDate = new DateTime(2024, 9, 2, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Bookmaker = "BETCLIC",
                            DayOfWeek = 1,
                            IsTaxIncluded = false,
                            IsWinning = 2,
                            Month = 9,
                            Stake = 75m,
                            TotalOdds = 1.90m,
                            Year = 2024
                        },
                        new
                        {
                            BetId = new Guid("cf302192-7898-47c5-9ee1-0289d2111c2d"),
                            BetDate = new DateTime(2024, 9, 2, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Bookmaker = "BETFAN",
                            DayOfWeek = 1,
                            IsTaxIncluded = true,
                            IsWinning = 0,
                            Month = 9,
                            Stake = 150m,
                            TotalOdds = 2.25m,
                            Year = 2024
                        });
                });

            modelBuilder.Entity("BetPay.Entities.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CategoryId"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CategoryId");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            CategoryId = 1,
                            Name = "Football"
                        },
                        new
                        {
                            CategoryId = 2,
                            Name = "Soccer"
                        },
                        new
                        {
                            CategoryId = 3,
                            Name = "Tennis"
                        });
                });

            modelBuilder.Entity("Domain.Entities.Event", b =>
                {
                    b.Property<Guid>("EventId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("BetId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<int>("EventTypeId")
                        .HasColumnType("int");

                    b.Property<double>("Odds")
                        .HasColumnType("float");

                    b.HasKey("EventId");

                    b.HasIndex("BetId");

                    b.HasIndex("CategoryId");

                    b.HasIndex("EventTypeId");

                    b.ToTable("Events");

                    b.HasData(
                        new
                        {
                            EventId = new Guid("7fa29635-9fff-4bb2-b88b-de4fdbef53f8"),
                            BetId = new Guid("dbfdfd8c-309a-4a98-8848-c3cf38a935b3"),
                            CategoryId = 1,
                            EventTypeId = 1,
                            Odds = 1.5
                        },
                        new
                        {
                            EventId = new Guid("4cabd9bc-61ea-48fd-a766-b4964906cfdc"),
                            BetId = new Guid("dbfdfd8c-309a-4a98-8848-c3cf38a935b3"),
                            CategoryId = 2,
                            EventTypeId = 2,
                            Odds = 2.0
                        },
                        new
                        {
                            EventId = new Guid("851f2a42-46dd-4144-bbaa-b8d680395654"),
                            BetId = new Guid("79feede5-eadb-4d0d-a030-4ca0568640b7"),
                            CategoryId = 1,
                            EventTypeId = 3,
                            Odds = 1.8
                        },
                        new
                        {
                            EventId = new Guid("f189ac45-705f-4326-b0d7-c7064cd73071"),
                            BetId = new Guid("79feede5-eadb-4d0d-a030-4ca0568640b7"),
                            CategoryId = 3,
                            EventTypeId = 4,
                            Odds = 2.2000000000000002
                        },
                        new
                        {
                            EventId = new Guid("187844f8-a938-408f-abb7-53077806032d"),
                            BetId = new Guid("6d7a3397-f570-4f02-b053-7898e4647b58"),
                            CategoryId = 2,
                            EventTypeId = 1,
                            Odds = 1.6000000000000001
                        },
                        new
                        {
                            EventId = new Guid("7530dd58-0215-4903-a27c-793134019262"),
                            BetId = new Guid("6d7a3397-f570-4f02-b053-7898e4647b58"),
                            CategoryId = 1,
                            EventTypeId = 3,
                            Odds = 2.5
                        },
                        new
                        {
                            EventId = new Guid("7a13758b-0fb1-4378-b9b5-a0f7b326f872"),
                            BetId = new Guid("0dd8c5b1-b17c-4f57-99af-b819e90fccf0"),
                            CategoryId = 3,
                            EventTypeId = 4,
                            Odds = 2.0
                        },
                        new
                        {
                            EventId = new Guid("ddab1cf1-bed7-4e27-8228-951d95aba18e"),
                            BetId = new Guid("0dd8c5b1-b17c-4f57-99af-b819e90fccf0"),
                            CategoryId = 2,
                            EventTypeId = 2,
                            Odds = 1.7
                        },
                        new
                        {
                            EventId = new Guid("60946dec-527c-4cc2-88e4-96238e473214"),
                            BetId = new Guid("cf302192-7898-47c5-9ee1-0289d2111c2d"),
                            CategoryId = 1,
                            EventTypeId = 3,
                            Odds = 2.1000000000000001
                        },
                        new
                        {
                            EventId = new Guid("c3faff25-789c-47c5-9d8a-aea94d2cb8c3"),
                            BetId = new Guid("cf302192-7898-47c5-9ee1-0289d2111c2d"),
                            CategoryId = 3,
                            EventTypeId = 4,
                            Odds = 2.2999999999999998
                        });
                });

            modelBuilder.Entity("Domain.Entities.EventType", b =>
                {
                    b.Property<int>("EventTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EventTypeId"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("EventTypeId");

                    b.ToTable("EventTypes");

                    b.HasData(
                        new
                        {
                            EventTypeId = 1,
                            Name = "BTTS"
                        },
                        new
                        {
                            EventTypeId = 2,
                            Name = "Statistical"
                        },
                        new
                        {
                            EventTypeId = 3,
                            Name = "1X2"
                        },
                        new
                        {
                            EventTypeId = 4,
                            Name = "Above/Under"
                        });
                });

            modelBuilder.Entity("Domain.Entities.Event", b =>
                {
                    b.HasOne("BetPay.Entities.Bet", "Bet")
                        .WithMany("EventsList")
                        .HasForeignKey("BetId");

                    b.HasOne("BetPay.Entities.Category", "Category")
                        .WithMany("Events")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.EventType", "EventType")
                        .WithMany("Events")
                        .HasForeignKey("EventTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Bet");

                    b.Navigation("Category");

                    b.Navigation("EventType");
                });

            modelBuilder.Entity("BetPay.Entities.Bet", b =>
                {
                    b.Navigation("EventsList");
                });

            modelBuilder.Entity("BetPay.Entities.Category", b =>
                {
                    b.Navigation("Events");
                });

            modelBuilder.Entity("Domain.Entities.EventType", b =>
                {
                    b.Navigation("Events");
                });
#pragma warning restore 612, 618
        }
    }
}
