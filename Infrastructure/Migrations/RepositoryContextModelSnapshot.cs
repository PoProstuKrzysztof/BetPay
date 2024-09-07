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

                    b.Property<int>("Month")
                        .HasColumnType("int");

                    b.Property<decimal>("Stake")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<decimal>("TotalOdds")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Year")
                        .HasColumnType("int");

                    b.HasKey("BetId");

                    b.ToTable("Bets");

                    b.HasData(
                        new
                        {
                            BetId = new Guid("b455677a-e621-4615-93ec-ac5a937c7864"),
                            BetDate = new DateTime(2024, 9, 2, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Bookmaker = "SUPERBET",
                            DayOfWeek = 3,
                            IsTaxIncluded = true,
                            Month = 9,
                            Stake = 50m,
                            Status = 0,
                            TotalOdds = 2.75m,
                            Year = 2024
                        },
                        new
                        {
                            BetId = new Guid("64a6ceee-8738-4a64-917f-0fa18f126821"),
                            BetDate = new DateTime(2024, 9, 2, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Bookmaker = "STS",
                            DayOfWeek = 3,
                            IsTaxIncluded = true,
                            Month = 9,
                            Stake = 100m,
                            Status = 1,
                            TotalOdds = 3.50m,
                            Year = 2024
                        },
                        new
                        {
                            BetId = new Guid("e0968625-7e04-46ae-bca6-4f911fd44abf"),
                            BetDate = new DateTime(2024, 9, 2, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Bookmaker = "FORTUNA",
                            DayOfWeek = 3,
                            IsTaxIncluded = true,
                            Month = 9,
                            Stake = 200m,
                            Status = 2,
                            TotalOdds = 4.00m,
                            Year = 2024
                        },
                        new
                        {
                            BetId = new Guid("12bdebae-b9cd-4e3a-a0ce-bd502fba039f"),
                            BetDate = new DateTime(2024, 9, 2, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Bookmaker = "BETCLIC",
                            DayOfWeek = 3,
                            IsTaxIncluded = false,
                            Month = 9,
                            Stake = 75m,
                            Status = 2,
                            TotalOdds = 1.90m,
                            Year = 2024
                        },
                        new
                        {
                            BetId = new Guid("c206d44e-fadd-4c21-aab4-3d76adb283b8"),
                            BetDate = new DateTime(2024, 9, 2, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Bookmaker = "BETFAN",
                            DayOfWeek = 3,
                            IsTaxIncluded = true,
                            Month = 9,
                            Stake = 150m,
                            Status = 0,
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

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("EventId");

                    b.HasIndex("BetId");

                    b.HasIndex("CategoryId");

                    b.HasIndex("EventTypeId");

                    b.ToTable("Events");

                    b.HasData(
                        new
                        {
                            EventId = new Guid("30b0d38f-84d2-4d9d-bcf5-66ca24168a89"),
                            BetId = new Guid("b455677a-e621-4615-93ec-ac5a937c7864"),
                            CategoryId = 1,
                            EventTypeId = 1,
                            Odds = 1.5,
                            Status = 0
                        },
                        new
                        {
                            EventId = new Guid("c322c407-fd42-42f4-acfd-bbd0ba241982"),
                            BetId = new Guid("b455677a-e621-4615-93ec-ac5a937c7864"),
                            CategoryId = 2,
                            EventTypeId = 2,
                            Odds = 2.0,
                            Status = 0
                        },
                        new
                        {
                            EventId = new Guid("60cfb78c-bdb3-47a7-b902-a08b3914233b"),
                            BetId = new Guid("64a6ceee-8738-4a64-917f-0fa18f126821"),
                            CategoryId = 1,
                            EventTypeId = 3,
                            Odds = 1.8,
                            Status = 0
                        },
                        new
                        {
                            EventId = new Guid("79c93190-f788-4949-841b-554e7264688b"),
                            BetId = new Guid("64a6ceee-8738-4a64-917f-0fa18f126821"),
                            CategoryId = 3,
                            EventTypeId = 4,
                            Odds = 2.2000000000000002,
                            Status = 1
                        },
                        new
                        {
                            EventId = new Guid("cb1c7ee1-f5c4-4cb3-b3f2-af763e766ec0"),
                            BetId = new Guid("e0968625-7e04-46ae-bca6-4f911fd44abf"),
                            CategoryId = 2,
                            EventTypeId = 1,
                            Odds = 1.6000000000000001,
                            Status = 2
                        },
                        new
                        {
                            EventId = new Guid("8d3cbeb2-3eef-4a1e-889c-d8c127fbb00e"),
                            BetId = new Guid("e0968625-7e04-46ae-bca6-4f911fd44abf"),
                            CategoryId = 1,
                            EventTypeId = 3,
                            Odds = 2.5,
                            Status = 2
                        },
                        new
                        {
                            EventId = new Guid("280f6147-a2ed-4c88-8923-d4dbb440e50a"),
                            BetId = new Guid("12bdebae-b9cd-4e3a-a0ce-bd502fba039f"),
                            CategoryId = 3,
                            EventTypeId = 4,
                            Odds = 2.0,
                            Status = 0
                        },
                        new
                        {
                            EventId = new Guid("27ba9b01-7b6d-4751-a389-3551ea0cd049"),
                            BetId = new Guid("12bdebae-b9cd-4e3a-a0ce-bd502fba039f"),
                            CategoryId = 2,
                            EventTypeId = 2,
                            Odds = 1.7,
                            Status = 2
                        },
                        new
                        {
                            EventId = new Guid("64cd3bce-96e8-41a1-9e34-6bfa6264ecf3"),
                            BetId = new Guid("c206d44e-fadd-4c21-aab4-3d76adb283b8"),
                            CategoryId = 1,
                            EventTypeId = 3,
                            Odds = 2.1000000000000001,
                            Status = 0
                        },
                        new
                        {
                            EventId = new Guid("51154ace-bea3-4fad-9788-35761a18f75d"),
                            BetId = new Guid("c206d44e-fadd-4c21-aab4-3d76adb283b8"),
                            CategoryId = 3,
                            EventTypeId = 4,
                            Odds = 2.2999999999999998,
                            Status = 0
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
