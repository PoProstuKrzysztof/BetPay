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
                name: "Bets",
                columns: table => new
                {
                    BetId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TotalOdds = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Stake = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    BetDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false),
                    Month = table.Column<int>(type: "int", nullable: false),
                    DayOfWeek = table.Column<int>(type: "int", nullable: false),
                    Bookmaker = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsWinning = table.Column<int>(type: "int", nullable: false),
                    IsTaxIncluded = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bets", x => x.BetId);
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
                name: "Events",
                columns: table => new
                {
                    EventId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Odds = table.Column<double>(type: "float", nullable: false),
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
                        principalColumn: "BetId");
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
                table: "Bets",
                columns: new[] { "BetId", "BetDate", "Bookmaker", "DayOfWeek", "IsTaxIncluded", "IsWinning", "Month", "Stake", "TotalOdds", "Year" },
                values: new object[,]
                {
                    { new Guid("0dd8c5b1-b17c-4f57-99af-b819e90fccf0"), new DateTime(2024, 9, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "BETCLIC", 1, false, 2, 9, 75m, 1.90m, 2024 },
                    { new Guid("6d7a3397-f570-4f02-b053-7898e4647b58"), new DateTime(2024, 9, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "FORTUNA", 1, true, 2, 9, 200m, 4.00m, 2024 },
                    { new Guid("79feede5-eadb-4d0d-a030-4ca0568640b7"), new DateTime(2024, 9, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "STS", 1, true, 1, 9, 100m, 3.50m, 2024 },
                    { new Guid("cf302192-7898-47c5-9ee1-0289d2111c2d"), new DateTime(2024, 9, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "BETFAN", 1, true, 0, 9, 150m, 2.25m, 2024 },
                    { new Guid("dbfdfd8c-309a-4a98-8848-c3cf38a935b3"), new DateTime(2024, 9, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "SUPERBET", 1, true, 0, 9, 50m, 2.75m, 2024 }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "Name" },
                values: new object[,]
                {
                    { 1, "Football" },
                    { 2, "Soccer" },
                    { 3, "Tennis" }
                });

            migrationBuilder.InsertData(
                table: "EventTypes",
                columns: new[] { "EventTypeId", "Name" },
                values: new object[,]
                {
                    { 1, "BTTS" },
                    { 2, "Statistical" },
                    { 3, "1X2" },
                    { 4, "Above/Under" }
                });

            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "EventId", "BetId", "CategoryId", "EventTypeId", "Odds" },
                values: new object[,]
                {
                    { new Guid("187844f8-a938-408f-abb7-53077806032d"), new Guid("6d7a3397-f570-4f02-b053-7898e4647b58"), 2, 1, 1.6000000000000001 },
                    { new Guid("4cabd9bc-61ea-48fd-a766-b4964906cfdc"), new Guid("dbfdfd8c-309a-4a98-8848-c3cf38a935b3"), 2, 2, 2.0 },
                    { new Guid("60946dec-527c-4cc2-88e4-96238e473214"), new Guid("cf302192-7898-47c5-9ee1-0289d2111c2d"), 1, 3, 2.1000000000000001 },
                    { new Guid("7530dd58-0215-4903-a27c-793134019262"), new Guid("6d7a3397-f570-4f02-b053-7898e4647b58"), 1, 3, 2.5 },
                    { new Guid("7a13758b-0fb1-4378-b9b5-a0f7b326f872"), new Guid("0dd8c5b1-b17c-4f57-99af-b819e90fccf0"), 3, 4, 2.0 },
                    { new Guid("7fa29635-9fff-4bb2-b88b-de4fdbef53f8"), new Guid("dbfdfd8c-309a-4a98-8848-c3cf38a935b3"), 1, 1, 1.5 },
                    { new Guid("851f2a42-46dd-4144-bbaa-b8d680395654"), new Guid("79feede5-eadb-4d0d-a030-4ca0568640b7"), 1, 3, 1.8 },
                    { new Guid("c3faff25-789c-47c5-9d8a-aea94d2cb8c3"), new Guid("cf302192-7898-47c5-9ee1-0289d2111c2d"), 3, 4, 2.2999999999999998 },
                    { new Guid("ddab1cf1-bed7-4e27-8228-951d95aba18e"), new Guid("0dd8c5b1-b17c-4f57-99af-b819e90fccf0"), 2, 2, 1.7 },
                    { new Guid("f189ac45-705f-4326-b0d7-c7064cd73071"), new Guid("79feede5-eadb-4d0d-a030-4ca0568640b7"), 3, 4, 2.2000000000000002 }
                });

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
        }
    }
}
