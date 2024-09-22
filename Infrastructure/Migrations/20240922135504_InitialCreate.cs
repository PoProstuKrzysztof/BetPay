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
                name: "Events",
                columns: table => new
                {
                    EventId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Odds = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    EventTypeId = table.Column<int>(type: "int", nullable: false),
                    BetId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
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
                    { new Guid("08687ca2-81d0-4816-9f78-bdc1edb2d47d"), new DateTime(2023, 7, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, true, 2, 50m },
                    { new Guid("2abfae7d-ab21-471c-a37a-96f0df575054"), new DateTime(2023, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, true, 1, 150m },
                    { new Guid("37b0f247-f7a5-4aac-b14e-5ff3f103143c"), new DateTime(2023, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, true, 2, 100m },
                    { new Guid("b1651f09-ffbb-4397-8a96-2fbc75a4809c"), new DateTime(2023, 9, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, false, 1, 75m },
                    { new Guid("e2deaa39-424e-4b0b-89e7-cda15de0b25b"), new DateTime(2023, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, false, 2, 200m }
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
                table: "Events",
                columns: new[] { "EventId", "BetId", "CategoryId", "EventTypeId", "Odds", "Status" },
                values: new object[,]
                {
                    { new Guid("1110967a-1c71-44a7-a622-ae147926e1da"), new Guid("2abfae7d-ab21-471c-a37a-96f0df575054"), 1, 3, 1.9m, 1 },
                    { new Guid("19b3a016-e039-49be-bbb5-cfc095a7a24a"), new Guid("37b0f247-f7a5-4aac-b14e-5ff3f103143c"), 1, 4, 2.3m, 0 },
                    { new Guid("28ef59d5-28c1-4854-b610-9b86a63cf258"), new Guid("2abfae7d-ab21-471c-a37a-96f0df575054"), 3, 5, 1.5m, 2 },
                    { new Guid("2ab3b3af-36a2-42aa-a9a9-e64d119b0a60"), new Guid("b1651f09-ffbb-4397-8a96-2fbc75a4809c"), 3, 4, 2.0m, 0 },
                    { new Guid("3100856d-8f88-4c42-acdb-4087bffe548e"), new Guid("37b0f247-f7a5-4aac-b14e-5ff3f103143c"), 1, 6, 1.8m, 2 },
                    { new Guid("35b8614f-ceaf-4813-a614-b1fa0d88b9b1"), new Guid("e2deaa39-424e-4b0b-89e7-cda15de0b25b"), 1, 1, 1.7m, 0 },
                    { new Guid("37525da5-1c03-4cfb-93fb-ed57f507daf7"), new Guid("e2deaa39-424e-4b0b-89e7-cda15de0b25b"), 2, 3, 1.5m, 0 },
                    { new Guid("5b81ccb0-359b-4ded-8e03-8e6dc8d40959"), new Guid("08687ca2-81d0-4816-9f78-bdc1edb2d47d"), 1, 1, 1.5m, 0 },
                    { new Guid("5c403e6e-f4b7-47c3-a65c-732871264915"), new Guid("08687ca2-81d0-4816-9f78-bdc1edb2d47d"), 2, 2, 2.0m, 0 },
                    { new Guid("77d1367e-03a1-406a-a949-e610b3637768"), new Guid("b1651f09-ffbb-4397-8a96-2fbc75a4809c"), 2, 1, 1.6m, 0 },
                    { new Guid("823733d7-0f13-4a24-b03e-7bdd470d3451"), new Guid("08687ca2-81d0-4816-9f78-bdc1edb2d47d"), 3, 3, 1.7m, 0 },
                    { new Guid("b3728fd0-22e7-4b11-8dee-1b2766236697"), new Guid("e2deaa39-424e-4b0b-89e7-cda15de0b25b"), 1, 6, 2.5m, 1 },
                    { new Guid("bf4b8267-7d3a-4168-b96a-d6045c5653a6"), new Guid("e2deaa39-424e-4b0b-89e7-cda15de0b25b"), 3, 4, 2.4m, 0 },
                    { new Guid("bf805418-066e-4376-8d7f-cc5b5d108026"), new Guid("e2deaa39-424e-4b0b-89e7-cda15de0b25b"), 2, 5, 2.1m, 2 },
                    { new Guid("dae0e025-e800-47d5-aa24-f4bf3a18ea9f"), new Guid("37b0f247-f7a5-4aac-b14e-5ff3f103143c"), 2, 5, 2.1m, 0 },
                    { new Guid("e3c40e8d-2540-4fa5-b027-ecea630958e8"), new Guid("2abfae7d-ab21-471c-a37a-96f0df575054"), 2, 2, 2.2m, 0 },
                    { new Guid("fe4bb787-3f80-4521-a996-75d45e8923af"), new Guid("37b0f247-f7a5-4aac-b14e-5ff3f103143c"), 2, 1, 1.6m, 1 }
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
                name: "IX_EventTypes_CategoryId",
                table: "EventTypes",
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
                name: "Bookmakers");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
