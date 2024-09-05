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
                    Status = table.Column<int>(type: "int", nullable: false),
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
                columns: new[] { "BetId", "BetDate", "Bookmaker", "DayOfWeek", "IsTaxIncluded", "Month", "Stake", "Status", "TotalOdds", "Year" },
                values: new object[,]
                {
                    { new Guid("12bdebae-b9cd-4e3a-a0ce-bd502fba039f"), new DateTime(2024, 9, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "BETCLIC", 3, false, 9, 75m, 2, 1.90m, 2024 },
                    { new Guid("64a6ceee-8738-4a64-917f-0fa18f126821"), new DateTime(2024, 9, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "STS", 3, true, 9, 100m, 1, 3.50m, 2024 },
                    { new Guid("b455677a-e621-4615-93ec-ac5a937c7864"), new DateTime(2024, 9, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "SUPERBET", 3, true, 9, 50m, 0, 2.75m, 2024 },
                    { new Guid("c206d44e-fadd-4c21-aab4-3d76adb283b8"), new DateTime(2024, 9, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "BETFAN", 3, true, 9, 150m, 0, 2.25m, 2024 },
                    { new Guid("e0968625-7e04-46ae-bca6-4f911fd44abf"), new DateTime(2024, 9, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "FORTUNA", 3, true, 9, 200m, 2, 4.00m, 2024 }
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
                columns: new[] { "EventId", "BetId", "CategoryId", "EventTypeId", "Odds", "Status" },
                values: new object[,]
                {
                    { new Guid("27ba9b01-7b6d-4751-a389-3551ea0cd049"), new Guid("12bdebae-b9cd-4e3a-a0ce-bd502fba039f"), 2, 2, 1.7, 2 },
                    { new Guid("280f6147-a2ed-4c88-8923-d4dbb440e50a"), new Guid("12bdebae-b9cd-4e3a-a0ce-bd502fba039f"), 3, 4, 2.0, 0 },
                    { new Guid("30b0d38f-84d2-4d9d-bcf5-66ca24168a89"), new Guid("b455677a-e621-4615-93ec-ac5a937c7864"), 1, 1, 1.5, 0 },
                    { new Guid("51154ace-bea3-4fad-9788-35761a18f75d"), new Guid("c206d44e-fadd-4c21-aab4-3d76adb283b8"), 3, 4, 2.2999999999999998, 0 },
                    { new Guid("60cfb78c-bdb3-47a7-b902-a08b3914233b"), new Guid("64a6ceee-8738-4a64-917f-0fa18f126821"), 1, 3, 1.8, 0 },
                    { new Guid("64cd3bce-96e8-41a1-9e34-6bfa6264ecf3"), new Guid("c206d44e-fadd-4c21-aab4-3d76adb283b8"), 1, 3, 2.1000000000000001, 0 },
                    { new Guid("79c93190-f788-4949-841b-554e7264688b"), new Guid("64a6ceee-8738-4a64-917f-0fa18f126821"), 3, 4, 2.2000000000000002, 1 },
                    { new Guid("8d3cbeb2-3eef-4a1e-889c-d8c127fbb00e"), new Guid("e0968625-7e04-46ae-bca6-4f911fd44abf"), 1, 3, 2.5, 2 },
                    { new Guid("c322c407-fd42-42f4-acfd-bbd0ba241982"), new Guid("b455677a-e621-4615-93ec-ac5a937c7864"), 2, 2, 2.0, 0 },
                    { new Guid("cb1c7ee1-f5c4-4cb3-b3f2-af763e766ec0"), new Guid("e0968625-7e04-46ae-bca6-4f911fd44abf"), 2, 1, 1.6000000000000001, 2 }
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
