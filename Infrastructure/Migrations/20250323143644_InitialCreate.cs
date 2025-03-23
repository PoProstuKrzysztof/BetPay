using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Bookmakers",
                columns: table => new
                {
                    BookmakerId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImagePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bookmakers", x => x.BookmakerId);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    CountryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FlagUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.CountryId);
                });

            migrationBuilder.CreateTable(
                name: "Bets",
                columns: table => new
                {
                    BetId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Stake = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    BetDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LivePrematch = table.Column<int>(type: "int", nullable: false),
                    IsTaxIncluded = table.Column<bool>(type: "bit", nullable: false),
                    BookmakerId = table.Column<int>(type: "int", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bets", x => x.BetId);
                    table.ForeignKey(
                        name: "FK_Bets_Bookmakers_BookmakerId",
                        column: x => x.BookmakerId,
                        principalTable: "Bookmakers",
                        principalColumn: "BookmakerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EventTypes",
                columns: table => new
                {
                    EventTypeId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventTypes", x => x.EventTypeId);
                    table.ForeignKey(
                        name: "FK_EventTypes_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LeagueTournaments",
                columns: table => new
                {
                    LeagueTournamentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApiId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LogoUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CountryId = table.Column<int>(type: "int", nullable: false),
                    CountryCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LeagueTournaments", x => x.LeagueTournamentId);
                    table.ForeignKey(
                        name: "FK_LeagueTournaments_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "CategoryId");
                    table.ForeignKey(
                        name: "FK_LeagueTournaments_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "CountryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Events",
                columns: table => new
                {
                    EventId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Odds = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    EventTypeId = table.Column<int>(type: "int", nullable: false),
                    LeagueTournamentId = table.Column<int>(type: "int", nullable: false),
                    BetId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LeagueTournamentId1 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.EventId);
                    table.ForeignKey(
                        name: "FK_Events_Bets_BetId",
                        column: x => x.BetId,
                        principalTable: "Bets",
                        principalColumn: "BetId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Events_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Events_EventTypes_EventTypeId",
                        column: x => x.EventTypeId,
                        principalTable: "EventTypes",
                        principalColumn: "EventTypeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Events_LeagueTournaments_LeagueTournamentId",
                        column: x => x.LeagueTournamentId,
                        principalTable: "LeagueTournaments",
                        principalColumn: "LeagueTournamentId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Events_LeagueTournaments_LeagueTournamentId1",
                        column: x => x.LeagueTournamentId1,
                        principalTable: "LeagueTournaments",
                        principalColumn: "LeagueTournamentId");
                });

            migrationBuilder.InsertData(
                table: "Bookmakers",
                columns: new[] { "BookmakerId", "CreatedBy", "CreatedOn", "ImagePath", "Name", "UpdatedBy", "UpdatedOn" },
                values: new object[,]
                {
                    { 1, "ADMIN", new DateTime(2025, 3, 23, 14, 36, 44, 559, DateTimeKind.Utc).AddTicks(6815), "/Images/Bookmakers/betclic.png", "Betclic", null, new DateTime(2025, 3, 23, 14, 36, 44, 559, DateTimeKind.Utc).AddTicks(6815) },
                    { 2, "ADMIN", new DateTime(2025, 3, 23, 14, 36, 44, 559, DateTimeKind.Utc).AddTicks(6817), "/Images/Bookmakers/superbet.png", "Superbet", null, new DateTime(2025, 3, 23, 14, 36, 44, 559, DateTimeKind.Utc).AddTicks(6817) },
                    { 3, "ADMIN", new DateTime(2025, 3, 23, 14, 36, 44, 559, DateTimeKind.Utc).AddTicks(6818), "/Images/Bookmakers/fortuna.png", "Fortuna", null, new DateTime(2025, 3, 23, 14, 36, 44, 559, DateTimeKind.Utc).AddTicks(6818) },
                    { 4, "ADMIN", new DateTime(2025, 3, 23, 14, 36, 44, 559, DateTimeKind.Utc).AddTicks(6819), "/Images/Bookmakers/sts.png", "STS", null, new DateTime(2025, 3, 23, 14, 36, 44, 559, DateTimeKind.Utc).AddTicks(6819) },
                    { 5, "ADMIN", new DateTime(2025, 3, 23, 14, 36, 44, 559, DateTimeKind.Utc).AddTicks(6819), "/Images/Bookmakers/betfan.png", "Betfan", null, new DateTime(2025, 3, 23, 14, 36, 44, 559, DateTimeKind.Utc).AddTicks(6820) },
                    { 6, "ADMIN", new DateTime(2025, 3, 23, 14, 36, 44, 559, DateTimeKind.Utc).AddTicks(6820), "/Images/Bookmakers/fuksiarz.png", "Fuksiarz", null, new DateTime(2025, 3, 23, 14, 36, 44, 559, DateTimeKind.Utc).AddTicks(6820) },
                    { 7, "ADMIN", new DateTime(2025, 3, 23, 14, 36, 44, 559, DateTimeKind.Utc).AddTicks(6821), "/Images/Bookmakers/lvbet.png", "LvBet", null, new DateTime(2025, 3, 23, 14, 36, 44, 559, DateTimeKind.Utc).AddTicks(6821) },
                    { 8, "ADMIN", new DateTime(2025, 3, 23, 14, 36, 44, 559, DateTimeKind.Utc).AddTicks(6822), "/Images/Bookmakers/betters.png", "Betters", null, new DateTime(2025, 3, 23, 14, 36, 44, 559, DateTimeKind.Utc).AddTicks(6822) },
                    { 9, "ADMIN", new DateTime(2025, 3, 23, 14, 36, 44, 559, DateTimeKind.Utc).AddTicks(6822), "/Images/Bookmakers/betcris.png", "Betcris", null, new DateTime(2025, 3, 23, 14, 36, 44, 559, DateTimeKind.Utc).AddTicks(6823) },
                    { 10, "ADMIN", new DateTime(2025, 3, 23, 14, 36, 44, 559, DateTimeKind.Utc).AddTicks(6823), "/Images/Bookmakers/gobet.png", "GoBet", null, new DateTime(2025, 3, 23, 14, 36, 44, 559, DateTimeKind.Utc).AddTicks(6823) },
                    { 11, "ADMIN", new DateTime(2025, 3, 23, 14, 36, 44, 559, DateTimeKind.Utc).AddTicks(6824), "/Images/Bookmakers/totalbet.png", "TotalBet", null, new DateTime(2025, 3, 23, 14, 36, 44, 559, DateTimeKind.Utc).AddTicks(6824) },
                    { 12, "ADMIN", new DateTime(2025, 3, 23, 14, 36, 44, 559, DateTimeKind.Utc).AddTicks(6825), "/Images/Bookmakers/forbet.png", "ForBet", null, new DateTime(2025, 3, 23, 14, 36, 44, 559, DateTimeKind.Utc).AddTicks(6825) },
                    { 13, "ADMIN", new DateTime(2025, 3, 23, 14, 36, 44, 559, DateTimeKind.Utc).AddTicks(6825), "/Images/Bookmakers/etoto.png", "Etoto", null, new DateTime(2025, 3, 23, 14, 36, 44, 559, DateTimeKind.Utc).AddTicks(6826) },
                    { 14, "ADMIN", new DateTime(2025, 3, 23, 14, 36, 44, 559, DateTimeKind.Utc).AddTicks(6826), "/Images/Bookmakers/comeon.png", "ComeOn", null, new DateTime(2025, 3, 23, 14, 36, 44, 559, DateTimeKind.Utc).AddTicks(6826) },
                    { 15, "ADMIN", new DateTime(2025, 3, 23, 14, 36, 44, 559, DateTimeKind.Utc).AddTicks(6827), "/Images/Bookmakers/pzbuk.png", "Pzbuk", null, new DateTime(2025, 3, 23, 14, 36, 44, 559, DateTimeKind.Utc).AddTicks(6827) }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "CreatedBy", "CreatedOn", "Name", "UpdatedBy", "UpdatedOn" },
                values: new object[,]
                {
                    { 1, "ADMIN", new DateTime(2025, 3, 23, 14, 36, 44, 559, DateTimeKind.Utc).AddTicks(6583), "Football", null, new DateTime(2025, 3, 23, 14, 36, 44, 559, DateTimeKind.Utc).AddTicks(6584) },
                    { 2, "ADMIN", new DateTime(2025, 3, 23, 14, 36, 44, 559, DateTimeKind.Utc).AddTicks(6587), "Tennis", null, new DateTime(2025, 3, 23, 14, 36, 44, 559, DateTimeKind.Utc).AddTicks(6588) },
                    { 3, "ADMIN", new DateTime(2025, 3, 23, 14, 36, 44, 559, DateTimeKind.Utc).AddTicks(6588), "Basketball", null, new DateTime(2025, 3, 23, 14, 36, 44, 559, DateTimeKind.Utc).AddTicks(6588) }
                });

            migrationBuilder.InsertData(
                table: "EventTypes",
                columns: new[] { "EventTypeId", "CategoryId", "CreatedBy", "CreatedOn", "Name", "UpdatedBy", "UpdatedOn" },
                values: new object[,]
                {
                    { 1, 1, "ADMIN", new DateTime(2025, 3, 23, 14, 36, 44, 559, DateTimeKind.Utc).AddTicks(6714), "BTTS", null, new DateTime(2025, 3, 23, 14, 36, 44, 559, DateTimeKind.Utc).AddTicks(6714) },
                    { 2, 1, "ADMIN", new DateTime(2025, 3, 23, 14, 36, 44, 559, DateTimeKind.Utc).AddTicks(6743), "1X2", null, new DateTime(2025, 3, 23, 14, 36, 44, 559, DateTimeKind.Utc).AddTicks(6743) },
                    { 3, 1, "ADMIN", new DateTime(2025, 3, 23, 14, 36, 44, 559, DateTimeKind.Utc).AddTicks(6744), "Over/Under Goals", null, new DateTime(2025, 3, 23, 14, 36, 44, 559, DateTimeKind.Utc).AddTicks(6744) },
                    { 4, 1, "ADMIN", new DateTime(2025, 3, 23, 14, 36, 44, 559, DateTimeKind.Utc).AddTicks(6744), "Corners", null, new DateTime(2025, 3, 23, 14, 36, 44, 559, DateTimeKind.Utc).AddTicks(6745) },
                    { 5, 1, "ADMIN", new DateTime(2025, 3, 23, 14, 36, 44, 559, DateTimeKind.Utc).AddTicks(6745), "Yellow Cards", null, new DateTime(2025, 3, 23, 14, 36, 44, 559, DateTimeKind.Utc).AddTicks(6745) },
                    { 6, 1, "ADMIN", new DateTime(2025, 3, 23, 14, 36, 44, 559, DateTimeKind.Utc).AddTicks(6746), "Correct Score", null, new DateTime(2025, 3, 23, 14, 36, 44, 559, DateTimeKind.Utc).AddTicks(6746) },
                    { 7, 1, "ADMIN", new DateTime(2025, 3, 23, 14, 36, 44, 559, DateTimeKind.Utc).AddTicks(6747), "Double Chance", null, new DateTime(2025, 3, 23, 14, 36, 44, 559, DateTimeKind.Utc).AddTicks(6747) },
                    { 8, 1, "ADMIN", new DateTime(2025, 3, 23, 14, 36, 44, 559, DateTimeKind.Utc).AddTicks(6747), "First Goal Scorer", null, new DateTime(2025, 3, 23, 14, 36, 44, 559, DateTimeKind.Utc).AddTicks(6748) },
                    { 9, 1, "ADMIN", new DateTime(2025, 3, 23, 14, 36, 44, 559, DateTimeKind.Utc).AddTicks(6748), "Last Goal Scorer", null, new DateTime(2025, 3, 23, 14, 36, 44, 559, DateTimeKind.Utc).AddTicks(6748) },
                    { 10, 1, "ADMIN", new DateTime(2025, 3, 23, 14, 36, 44, 559, DateTimeKind.Utc).AddTicks(6749), "Player to Score Anytime", null, new DateTime(2025, 3, 23, 14, 36, 44, 559, DateTimeKind.Utc).AddTicks(6749) },
                    { 11, 1, "ADMIN", new DateTime(2025, 3, 23, 14, 36, 44, 559, DateTimeKind.Utc).AddTicks(6750), "Clean Sheet", null, new DateTime(2025, 3, 23, 14, 36, 44, 559, DateTimeKind.Utc).AddTicks(6750) },
                    { 12, 1, "ADMIN", new DateTime(2025, 3, 23, 14, 36, 44, 559, DateTimeKind.Utc).AddTicks(6750), "Team to Win Both Halves", null, new DateTime(2025, 3, 23, 14, 36, 44, 559, DateTimeKind.Utc).AddTicks(6751) },
                    { 13, 1, "ADMIN", new DateTime(2025, 3, 23, 14, 36, 44, 559, DateTimeKind.Utc).AddTicks(6751), "Half-Time Result", null, new DateTime(2025, 3, 23, 14, 36, 44, 559, DateTimeKind.Utc).AddTicks(6751) },
                    { 14, 1, "ADMIN", new DateTime(2025, 3, 23, 14, 36, 44, 559, DateTimeKind.Utc).AddTicks(6752), "Full-Time Result", null, new DateTime(2025, 3, 23, 14, 36, 44, 559, DateTimeKind.Utc).AddTicks(6752) },
                    { 15, 1, "ADMIN", new DateTime(2025, 3, 23, 14, 36, 44, 559, DateTimeKind.Utc).AddTicks(6753), "Half-Time/Full-Time", null, new DateTime(2025, 3, 23, 14, 36, 44, 559, DateTimeKind.Utc).AddTicks(6753) },
                    { 16, 1, "ADMIN", new DateTime(2025, 3, 23, 14, 36, 44, 559, DateTimeKind.Utc).AddTicks(6753), "Team to Score First", null, new DateTime(2025, 3, 23, 14, 36, 44, 559, DateTimeKind.Utc).AddTicks(6754) },
                    { 17, 1, "ADMIN", new DateTime(2025, 3, 23, 14, 36, 44, 559, DateTimeKind.Utc).AddTicks(6754), "First Half Goals", null, new DateTime(2025, 3, 23, 14, 36, 44, 559, DateTimeKind.Utc).AddTicks(6755) },
                    { 18, 1, "ADMIN", new DateTime(2025, 3, 23, 14, 36, 44, 559, DateTimeKind.Utc).AddTicks(6755), "Second Half Goals", null, new DateTime(2025, 3, 23, 14, 36, 44, 559, DateTimeKind.Utc).AddTicks(6755) },
                    { 19, 2, "ADMIN", new DateTime(2025, 3, 23, 14, 36, 44, 559, DateTimeKind.Utc).AddTicks(6756), "Total Aces", null, new DateTime(2025, 3, 23, 14, 36, 44, 559, DateTimeKind.Utc).AddTicks(6756) },
                    { 20, 2, "ADMIN", new DateTime(2025, 3, 23, 14, 36, 44, 559, DateTimeKind.Utc).AddTicks(6757), "Total Double Faults", null, new DateTime(2025, 3, 23, 14, 36, 44, 559, DateTimeKind.Utc).AddTicks(6757) },
                    { 21, 2, "ADMIN", new DateTime(2025, 3, 23, 14, 36, 44, 559, DateTimeKind.Utc).AddTicks(6757), "Set Winner", null, new DateTime(2025, 3, 23, 14, 36, 44, 559, DateTimeKind.Utc).AddTicks(6758) },
                    { 22, 2, "ADMIN", new DateTime(2025, 3, 23, 14, 36, 44, 559, DateTimeKind.Utc).AddTicks(6758), "Match Winner", null, new DateTime(2025, 3, 23, 14, 36, 44, 559, DateTimeKind.Utc).AddTicks(6758) },
                    { 23, 2, "ADMIN", new DateTime(2025, 3, 23, 14, 36, 44, 559, DateTimeKind.Utc).AddTicks(6759), "First Set Winner", null, new DateTime(2025, 3, 23, 14, 36, 44, 559, DateTimeKind.Utc).AddTicks(6759) },
                    { 24, 2, "ADMIN", new DateTime(2025, 3, 23, 14, 36, 44, 559, DateTimeKind.Utc).AddTicks(6760), "Total Games Over/Under", null, new DateTime(2025, 3, 23, 14, 36, 44, 559, DateTimeKind.Utc).AddTicks(6760) },
                    { 25, 3, "ADMIN", new DateTime(2025, 3, 23, 14, 36, 44, 559, DateTimeKind.Utc).AddTicks(6761), "First Basket Scorer", null, new DateTime(2025, 3, 23, 14, 36, 44, 559, DateTimeKind.Utc).AddTicks(6761) },
                    { 26, 3, "ADMIN", new DateTime(2025, 3, 23, 14, 36, 44, 559, DateTimeKind.Utc).AddTicks(6761), "Total Points Over/Under", null, new DateTime(2025, 3, 23, 14, 36, 44, 559, DateTimeKind.Utc).AddTicks(6762) },
                    { 27, 3, "ADMIN", new DateTime(2025, 3, 23, 14, 36, 44, 559, DateTimeKind.Utc).AddTicks(6762), "Winning Margin", null, new DateTime(2025, 3, 23, 14, 36, 44, 559, DateTimeKind.Utc).AddTicks(6762) },
                    { 28, 3, "ADMIN", new DateTime(2025, 3, 23, 14, 36, 44, 559, DateTimeKind.Utc).AddTicks(6763), "Most Assists", null, new DateTime(2025, 3, 23, 14, 36, 44, 559, DateTimeKind.Utc).AddTicks(6763) },
                    { 29, 3, "ADMIN", new DateTime(2025, 3, 23, 14, 36, 44, 559, DateTimeKind.Utc).AddTicks(6764), "Total Rebounds", null, new DateTime(2025, 3, 23, 14, 36, 44, 559, DateTimeKind.Utc).AddTicks(6764) },
                    { 30, 3, "ADMIN", new DateTime(2025, 3, 23, 14, 36, 44, 559, DateTimeKind.Utc).AddTicks(6764), "First Team to Score 20 Points", null, new DateTime(2025, 3, 23, 14, 36, 44, 559, DateTimeKind.Utc).AddTicks(6765) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bets_BookmakerId",
                table: "Bets",
                column: "BookmakerId");

            migrationBuilder.CreateIndex(
                name: "IX_Events_BetId",
                table: "Events",
                column: "BetId");

            migrationBuilder.CreateIndex(
                name: "IX_Events_CategoryId",
                table: "Events",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Events_EventTypeId",
                table: "Events",
                column: "EventTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Events_LeagueTournamentId",
                table: "Events",
                column: "LeagueTournamentId");

            migrationBuilder.CreateIndex(
                name: "IX_Events_LeagueTournamentId1",
                table: "Events",
                column: "LeagueTournamentId1");

            migrationBuilder.CreateIndex(
                name: "IX_EventTypes_CategoryId",
                table: "EventTypes",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_LeagueTournaments_CategoryId",
                table: "LeagueTournaments",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_LeagueTournaments_CountryId",
                table: "LeagueTournaments",
                column: "CountryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Events");

            migrationBuilder.DropTable(
                name: "Bets");

            migrationBuilder.DropTable(
                name: "EventTypes");

            migrationBuilder.DropTable(
                name: "LeagueTournaments");

            migrationBuilder.DropTable(
                name: "Bookmakers");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Countries");
        }
    }
}
