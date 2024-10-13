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
                    ImagePath = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryId);
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
                    BookmakerId = table.Column<int>(type: "int", nullable: false)
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
                    CategoryId = table.Column<int>(type: "int", nullable: false)
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
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LeagueTournaments", x => x.LeagueTournamentId);
                    table.ForeignKey(
                        name: "FK_LeagueTournaments_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "CategoryId",
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
                columns: new[] { "BookmakerId", "ImagePath", "Name" },
                values: new object[,]
                {
                    { 1, "/Images/Bookmakers/betclic.png", "Betclic" },
                    { 2, "/Images/Bookmakers/superbet.png", "Superbet" },
                    { 3, "/Images/Bookmakers/fortuna.png", "Fortuna" },
                    { 4, "/Images/Bookmakers/sts.png", "STS" },
                    { 5, "/Images/Bookmakers/betfan.png", "Betfan" },
                    { 6, "/Images/Bookmakers/fuksiarz.png", "Fuksiarz" },
                    { 7, "/Images/Bookmakers/lvbet.png", "LvBet" },
                    { 8, "/Images/Bookmakers/betters.png", "Betters" },
                    { 9, "/Images/Bookmakers/betcris.png", "Betcris" },
                    { 10, "/Images/Bookmakers/gobet.png", "GoBet" },
                    { 11, "/Images/Bookmakers/totalbet.png", "TotalBet" },
                    { 12, "/Images/Bookmakers/forbet.png", "ForBet" },
                    { 13, "/Images/Bookmakers/etoto.png", "Etoto" },
                    { 14, "/Images/Bookmakers/comeon.png", "ComeOn" },
                    { 15, "/Images/Bookmakers/pzbuk.png", "Pzbuk" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "Name" },
                values: new object[,]
                {
                    { 1, "Football" },
                    { 2, "Tennis" },
                    { 3, "Basketball" }
                });

            migrationBuilder.InsertData(
                table: "Bets",
                columns: new[] { "BetId", "BetDate", "BookmakerId", "IsTaxIncluded", "LivePrematch", "Stake" },
                values: new object[,]
                {
                    { new Guid("14636804-0b37-45d9-aa36-7d14a6f7507c"), new DateTime(2023, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, false, 2, 200m },
                    { new Guid("200172fa-bd84-4789-9226-557d8d68f49a"), new DateTime(2023, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, true, 1, 150m },
                    { new Guid("3a1585ea-4859-49c5-93c5-7a86c4422f7e"), new DateTime(2023, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, true, 2, 100m },
                    { new Guid("68f3a7a8-f820-407a-80a0-ee83e366d5e1"), new DateTime(2023, 7, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, true, 2, 50m },
                    { new Guid("80c93edd-1f3f-460b-9181-25800030f568"), new DateTime(2023, 9, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, false, 1, 75m }
                });

            migrationBuilder.InsertData(
                table: "EventTypes",
                columns: new[] { "EventTypeId", "CategoryId", "Name" },
                values: new object[,]
                {
                    { 1, 1, "BTTS" },
                    { 2, 1, "1X2" },
                    { 3, 1, "Over/Under Goals" },
                    { 4, 1, "Corners" },
                    { 5, 1, "Yellow Cards" },
                    { 6, 1, "Correct Score" },
                    { 7, 1, "Double Chance" },
                    { 8, 1, "First Goal Scorer" },
                    { 9, 1, "Last Goal Scorer" },
                    { 10, 1, "Player to Score Anytime" },
                    { 11, 1, "Clean Sheet" },
                    { 12, 1, "Team to Win Both Halves" },
                    { 13, 1, "Half-Time Result" },
                    { 14, 1, "Full-Time Result" },
                    { 15, 1, "Half-Time/Full-Time" },
                    { 16, 1, "Team to Score First" },
                    { 17, 1, "First Half Goals" },
                    { 18, 1, "Second Half Goals" },
                    { 19, 2, "Total Aces" },
                    { 20, 2, "Total Double Faults" },
                    { 21, 2, "Set Winner" },
                    { 22, 2, "Match Winner" },
                    { 23, 2, "First Set Winner" },
                    { 24, 2, "Total Games Over/Under" },
                    { 25, 3, "First Basket Scorer" },
                    { 26, 3, "Total Points Over/Under" },
                    { 27, 3, "Winning Margin" },
                    { 28, 3, "Most Assists" },
                    { 29, 3, "Total Rebounds" },
                    { 30, 3, "First Team to Score 20 Points" }
                });

            migrationBuilder.InsertData(
                table: "LeagueTournaments",
                columns: new[] { "LeagueTournamentId", "CategoryId", "Name" },
                values: new object[,]
                {
                    { 1, 1, "Premier League" },
                    { 2, 1, "La Liga" },
                    { 3, 1, "Serie A" },
                    { 4, 1, "Bundesliga" },
                    { 5, 1, "Ligue 1" },
                    { 6, 1, "UEFA Champions League" },
                    { 7, 1, "UEFA Europa League" },
                    { 8, 1, "Euro Cup" },
                    { 9, 1, "Copa America" },
                    { 10, 1, "FIFA World Cup" },
                    { 11, 2, "Wimbledon" },
                    { 12, 2, "Roland Garros" },
                    { 13, 2, "US Open" },
                    { 14, 2, "Australian Open" },
                    { 15, 2, "ATP Finals" },
                    { 16, 3, "NBA Finals" },
                    { 17, 3, "EuroLeague" },
                    { 18, 3, "FIBA World Cup" },
                    { 19, 3, "NCAA March Madness" },
                    { 20, 3, "Olympic Basketball Tournament" }
                });

            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "EventId", "BetId", "CategoryId", "EventTypeId", "LeagueTournamentId", "LeagueTournamentId1", "Odds", "Status" },
                values: new object[,]
                {
                    { new Guid("4b299938-1ea6-4593-a8e5-ae02ddb57b21"), new Guid("68f3a7a8-f820-407a-80a0-ee83e366d5e1"), 1, 1, 1, null, 1.5m, 0 },
                    { new Guid("70b9fd2c-7aa8-461f-a15f-5518a67c3f93"), new Guid("3a1585ea-4859-49c5-93c5-7a86c4422f7e"), 2, 1, 7, null, 1.6m, 1 },
                    { new Guid("9aecac05-e02b-4cad-9910-fbc5b399fc04"), new Guid("3a1585ea-4859-49c5-93c5-7a86c4422f7e"), 1, 6, 2, null, 1.8m, 2 },
                    { new Guid("a9d1e0da-021c-47ae-a6b9-45e57df93a7c"), new Guid("68f3a7a8-f820-407a-80a0-ee83e366d5e1"), 3, 3, 2, null, 1.7m, 0 },
                    { new Guid("ae364343-1aae-409e-969b-6941d2170466"), new Guid("3a1585ea-4859-49c5-93c5-7a86c4422f7e"), 2, 5, 10, null, 2.1m, 0 },
                    { new Guid("c2391e47-1e8b-4b2c-8232-787f3e93c4c9"), new Guid("68f3a7a8-f820-407a-80a0-ee83e366d5e1"), 2, 2, 8, null, 2.0m, 0 },
                    { new Guid("d39011eb-7f7d-4b2b-95c1-850c2815f356"), new Guid("3a1585ea-4859-49c5-93c5-7a86c4422f7e"), 1, 4, 6, null, 2.3m, 0 }
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
        }
    }
}
