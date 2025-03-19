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
                name: "Countries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FlagUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.Id);
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
                    { new Guid("50bce28b-e41a-4176-9064-68132b01a1bf"), new DateTime(2023, 9, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, false, 1, 75m },
                    { new Guid("84eacbf1-abda-41bf-a071-1c910bc2473d"), new DateTime(2023, 7, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, true, 2, 50m },
                    { new Guid("a78e4e22-2477-46ef-bbc6-a1e0a04665e5"), new DateTime(2023, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, false, 2, 200m },
                    { new Guid("ef724ccf-5f6c-4ed5-967a-655a635cc3e4"), new DateTime(2023, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, true, 1, 150m },
                    { new Guid("f7c02600-ecc6-4c5e-9e87-07d91bf26316"), new DateTime(2023, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, true, 2, 100m }
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
                    { new Guid("1ccc000b-ae40-417a-98a6-ae10151e2bc6"), new Guid("f7c02600-ecc6-4c5e-9e87-07d91bf26316"), 2, 1, 7, null, 1.6m, 1 },
                    { new Guid("2ddc0261-3ce4-47a9-8d32-78e0edf9f48a"), new Guid("f7c02600-ecc6-4c5e-9e87-07d91bf26316"), 1, 4, 6, null, 2.3m, 0 },
                    { new Guid("72b9e653-db70-4d26-9486-c0cc24577173"), new Guid("f7c02600-ecc6-4c5e-9e87-07d91bf26316"), 2, 5, 10, null, 2.1m, 0 },
                    { new Guid("92be7b44-4d50-480e-987e-524d35b825c9"), new Guid("84eacbf1-abda-41bf-a071-1c910bc2473d"), 1, 1, 1, null, 1.5m, 0 },
                    { new Guid("ba1e87ad-0f14-42b0-9e54-f3081a116928"), new Guid("84eacbf1-abda-41bf-a071-1c910bc2473d"), 2, 2, 8, null, 2.0m, 0 },
                    { new Guid("e71b68a6-35e3-41aa-acb9-28f2503316b7"), new Guid("84eacbf1-abda-41bf-a071-1c910bc2473d"), 3, 3, 2, null, 1.7m, 0 },
                    { new Guid("f6863a09-9e0e-476f-bb9e-a119cb115d8b"), new Guid("f7c02600-ecc6-4c5e-9e87-07d91bf26316"), 1, 6, 2, null, 1.8m, 2 }
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
                name: "Countries");

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
