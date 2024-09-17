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
                    { 1, "/Images/Bookmakers/betclic-icon.jpg", "Betclic" },
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
                    { new Guid("119d366d-790d-4c6e-a314-3ab01bb479d1"), new DateTime(2024, 9, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, true, 200m },
                    { new Guid("3196411c-96e9-4801-82db-d71a4e15898a"), new DateTime(2024, 9, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, true, 150m },
                    { new Guid("4b3a30ec-31f9-49c2-afdd-b0e4d9b07c9a"), new DateTime(2024, 9, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, false, 75m },
                    { new Guid("8477d938-3269-4c5c-a9ab-7fd8d1031428"), new DateTime(2024, 9, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, true, 100m },
                    { new Guid("88992eca-f894-4176-8c67-55c6ac5ae202"), new DateTime(2024, 9, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, true, 50m }
                });

            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "EventId", "BetId", "CategoryId", "EventTypeId", "Odds", "Status" },
                values: new object[,]
                {
                    { new Guid("0e5619ae-5944-495c-93e4-8e799f87e7d8"), new Guid("119d366d-790d-4c6e-a314-3ab01bb479d1"), 2, 1, 1.6m, 2 },
                    { new Guid("467df1db-38ba-4d23-b348-f2e497ac249d"), new Guid("4b3a30ec-31f9-49c2-afdd-b0e4d9b07c9a"), 3, 4, 2.0m, 0 },
                    { new Guid("5ee05351-240c-45f5-8bb1-eaeba3d95f26"), new Guid("8477d938-3269-4c5c-a9ab-7fd8d1031428"), 1, 3, 1.8m, 0 },
                    { new Guid("77fef067-022f-4399-9e34-67bbf8668d6b"), new Guid("88992eca-f894-4176-8c67-55c6ac5ae202"), 2, 2, 2.0m, 0 },
                    { new Guid("82b8818b-39d5-4630-be91-57bdede8dcce"), new Guid("88992eca-f894-4176-8c67-55c6ac5ae202"), 1, 1, 1.5m, 0 },
                    { new Guid("976e7541-2219-4d26-bf7c-2bc9eb3310cc"), new Guid("8477d938-3269-4c5c-a9ab-7fd8d1031428"), 3, 4, 2.2m, 1 },
                    { new Guid("b414e518-0500-4688-9d28-06c80d13f58a"), new Guid("4b3a30ec-31f9-49c2-afdd-b0e4d9b07c9a"), 2, 2, 1.7m, 2 },
                    { new Guid("b618d659-9482-41a2-b1f8-37d1d830c6db"), new Guid("119d366d-790d-4c6e-a314-3ab01bb479d1"), 1, 3, 2.5m, 2 },
                    { new Guid("c89b8292-0e03-4c45-bc51-95b202783508"), new Guid("3196411c-96e9-4801-82db-d71a4e15898a"), 1, 3, 2.1m, 0 },
                    { new Guid("fe70ff17-cdef-432f-a15c-3c3ba9d02f2e"), new Guid("3196411c-96e9-4801-82db-d71a4e15898a"), 3, 4, 2.3m, 0 }
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
