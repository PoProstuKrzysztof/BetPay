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
                    Status = table.Column<int>(type: "int", nullable: false),
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
                table: "Bets",
                columns: new[] { "BetId", "BetDate", "BookmakerId", "IsTaxIncluded", "Stake", "Status" },
                values: new object[,]
                {
                    { new Guid("5a768bea-7dc5-4bbe-b445-fab4828a79c3"), new DateTime(2024, 9, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, false, 75m, 2 },
                    { new Guid("75c2704b-9fd8-48fa-b01d-ee19638cea39"), new DateTime(2024, 9, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, true, 50m, 2 },
                    { new Guid("b3717315-0d53-4b88-be01-e51996270074"), new DateTime(2024, 9, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, true, 200m, 2 },
                    { new Guid("f787d8aa-a9ec-4aa9-96c6-851a12763b65"), new DateTime(2024, 9, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, true, 100m, 2 },
                    { new Guid("fb8088cc-2d10-4751-b8b2-d3740ac63c5c"), new DateTime(2024, 9, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, true, 150m, 2 }
                });

            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "EventId", "BetId", "CategoryId", "EventTypeId", "Odds", "Status" },
                values: new object[,]
                {
                    { new Guid("01195be5-7f3e-4be4-9945-15a88f03f066"), new Guid("fb8088cc-2d10-4751-b8b2-d3740ac63c5c"), 3, 4, 2.3m, 0 },
                    { new Guid("057c0ab4-bfea-425d-97dd-f2479fb3ec64"), new Guid("5a768bea-7dc5-4bbe-b445-fab4828a79c3"), 2, 2, 1.7m, 2 },
                    { new Guid("5d8368f1-6358-4b6c-91cd-2eafa01a3be6"), new Guid("b3717315-0d53-4b88-be01-e51996270074"), 2, 1, 1.6m, 2 },
                    { new Guid("8811255d-aaaf-4477-ab9d-e692f0db017e"), new Guid("fb8088cc-2d10-4751-b8b2-d3740ac63c5c"), 1, 3, 2.1m, 0 },
                    { new Guid("8d26049f-da69-478b-8a12-eb2faaaeda85"), new Guid("75c2704b-9fd8-48fa-b01d-ee19638cea39"), 2, 2, 2.0m, 0 },
                    { new Guid("9b400e87-692b-4759-a767-b77f3f4732b7"), new Guid("f787d8aa-a9ec-4aa9-96c6-851a12763b65"), 3, 4, 2.2m, 1 },
                    { new Guid("9e0c814e-51b4-4fbf-bc42-cbf39d56077b"), new Guid("f787d8aa-a9ec-4aa9-96c6-851a12763b65"), 1, 3, 1.8m, 0 },
                    { new Guid("d71e7dd1-9d2e-4444-84de-05dab9feb2d2"), new Guid("75c2704b-9fd8-48fa-b01d-ee19638cea39"), 1, 1, 1.5m, 0 },
                    { new Guid("f32ba145-6707-4eee-b494-a4916797ec21"), new Guid("5a768bea-7dc5-4bbe-b445-fab4828a79c3"), 3, 4, 2.0m, 0 },
                    { new Guid("f637ed41-7131-438f-a3c7-3af918b9f55c"), new Guid("b3717315-0d53-4b88-be01-e51996270074"), 1, 3, 2.5m, 2 }
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
