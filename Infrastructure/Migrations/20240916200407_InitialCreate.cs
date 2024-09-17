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
                    BookmakerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
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
                name: "EventTypes",
                columns: table => new
                {
                    EventTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventTypes", x => x.EventTypeId);
                });

            migrationBuilder.CreateTable(
                name: "Bets",
                columns: table => new
                {
                    BetId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Stake = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    BetDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsTaxIncluded = table.Column<bool>(type: "bit", nullable: false),
                    BookmakerId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bets", x => x.BetId);
                    table.ForeignKey(
                        name: "FK_Bets_Bookmakers_BookmakerId",
                        column: x => x.BookmakerId,
                        principalTable: "Bookmakers",
                        principalColumn: "BookmakerId");
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
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Events_EventTypes_EventTypeId",
                        column: x => x.EventTypeId,
                        principalTable: "EventTypes",
                        principalColumn: "EventTypeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Bookmakers",
                columns: new[] { "BookmakerId", "ImagePath", "Name" },
                values: new object[,]
                {
                    { 1, null, "Betclic" },
                    { 2, null, "Superbet" },
                    { 3, null, "Fortuna" },
                    { 4, null, "STS" },
                    { 5, null, "Betfan" },
                    { 6, null, "Fuksiarz" },
                    { 7, null, "LvBet" },
                    { 8, null, "Betters" },
                    { 9, null, "Betcris" },
                    { 10, null, "GoBet" },
                    { 11, null, "TotalBet" },
                    { 12, null, "ForBet" },
                    { 13, null, "Etoto" },
                    { 14, null, "ComeOn" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "Name" },
                values: new object[,]
                {
                    { 1, "Football" },
                    { 2, "Soccer" },
                    { 3, "Tennis" },
                    { 4, "Basketball" }
                });

            migrationBuilder.InsertData(
                table: "EventTypes",
                columns: new[] { "EventTypeId", "Name" },
                values: new object[,]
                {
                    { 1, "BTTS" },
                    { 2, "1X2" },
                    { 3, "Over/Under Goals" },
                    { 4, "Corners" },
                    { 5, "Yellow Cards" },
                    { 6, "Correct Score" },
                    { 7, "Double Chance" },
                    { 8, "First Goal Scorer" },
                    { 9, "Last Goal Scorer" },
                    { 10, "Player to Score Anytime" },
                    { 11, "Clean Sheet" },
                    { 12, "Team to Win Both Halves" },
                    { 13, "Half-Time Result" },
                    { 14, "Full-Time Result" },
                    { 15, "Half-Time/Full-Time" },
                    { 16, "Team to Score First" },
                    { 17, "First Half Goals" },
                    { 18, "Second Half Goals" }
                });

            migrationBuilder.InsertData(
                table: "Bets",
                columns: new[] { "BetId", "BetDate", "BookmakerId", "IsTaxIncluded", "Stake" },
                values: new object[,]
                {
                    { new Guid("4abdf2b3-cfc4-4176-b657-c2662b115f68"), new DateTime(2024, 9, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, true, 200m },
                    { new Guid("87b931e3-d6e8-4d42-805d-c93f09a402e7"), new DateTime(2024, 9, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, true, 50m },
                    { new Guid("a08555be-3662-449a-8da7-f425e8c20a2f"), new DateTime(2024, 9, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, true, 100m },
                    { new Guid("a528195f-1109-4cde-8a0a-4e1d2999e062"), new DateTime(2024, 9, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, true, 150m },
                    { new Guid("bc1efdec-83b8-4057-820a-45d387c19767"), new DateTime(2024, 9, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, false, 75m }
                });

            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "EventId", "BetId", "CategoryId", "EventTypeId", "Odds", "Status" },
                values: new object[,]
                {
                    { new Guid("09a37797-8d97-49e5-b437-2be10d0d8e46"), new Guid("87b931e3-d6e8-4d42-805d-c93f09a402e7"), 2, 2, 2.0m, 0 },
                    { new Guid("0a684c8e-d330-46e6-b9ed-95457deea601"), new Guid("4abdf2b3-cfc4-4176-b657-c2662b115f68"), 2, 1, 1.6m, 2 },
                    { new Guid("0d848284-ee55-419a-aca9-da94199f77dc"), new Guid("a08555be-3662-449a-8da7-f425e8c20a2f"), 1, 3, 1.8m, 0 },
                    { new Guid("18813c61-5019-4064-960f-47cbf5cba8b3"), new Guid("bc1efdec-83b8-4057-820a-45d387c19767"), 2, 2, 1.7m, 2 },
                    { new Guid("2e78c8e2-5941-4914-9982-001f3f365911"), new Guid("a528195f-1109-4cde-8a0a-4e1d2999e062"), 3, 4, 2.3m, 0 },
                    { new Guid("34a02abf-d4f4-49cb-b8ad-414199c7ccd7"), new Guid("a528195f-1109-4cde-8a0a-4e1d2999e062"), 1, 3, 2.1m, 0 },
                    { new Guid("5952c675-5f10-4844-999d-ea136f7eee4d"), new Guid("87b931e3-d6e8-4d42-805d-c93f09a402e7"), 1, 1, 1.5m, 0 },
                    { new Guid("730b937c-5de5-47fa-a30c-1a5d07f5b812"), new Guid("4abdf2b3-cfc4-4176-b657-c2662b115f68"), 1, 3, 2.5m, 2 },
                    { new Guid("982cdbee-d9e7-41d4-ac04-a9e5867b9599"), new Guid("a08555be-3662-449a-8da7-f425e8c20a2f"), 3, 4, 2.2m, 1 },
                    { new Guid("cd1799aa-768f-45fb-9c97-11ddeac23f50"), new Guid("bc1efdec-83b8-4057-820a-45d387c19767"), 3, 4, 2.0m, 0 }
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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Events");

            migrationBuilder.DropTable(
                name: "Bets");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "EventTypes");

            migrationBuilder.DropTable(
                name: "Bookmakers");
        }
    }
}
