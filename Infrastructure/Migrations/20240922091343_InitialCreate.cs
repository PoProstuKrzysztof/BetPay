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
                    { 1, "/Images/Bookmakers/betclic-icon.jpg", "Betclic" },
                    { 2, "/Images/Bookmakers/superbet-icon.jpg", "Superbet" },
                    { 3, "/Images/Bookmakers/fortuna-icon.jpg", "Fortuna" },
                    { 4, "/Images/Bookmakers/sts-icon.jpg", "STS" },
                    { 5, "/Images/Bookmakers/betfan-icon.jpg", "Betfan" },
                    { 6, "/Images/Bookmakers/fuksiarz-icon.jpg", "Fuksiarz" },
                    { 7, "/Images/Bookmakers/lvbet-icon.jpg", "LvBet" },
                    { 8, "/Images/Bookmakers/betters-icon.jpg", "Betters" },
                    { 9, "/Images/Bookmakers/betcris-icon.jpg", "Betcris" },
                    { 10, "/Images/Bookmakers/gobet-icon.jpg", "GoBet" },
                    { 11, "/Images/Bookmakers/totalbet-icon.jpg", "TotalBet" },
                    { 12, "/Images/Bookmakers/forbet-icon.jpg", "ForBet" },
                    { 13, "/Images/Bookmakers/etoto-icon.jpg", "Etoto" },
                    { 14, "/Images/Bookmakers/ComeOn-icon.jpg", "ComeOn" }
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
                    { new Guid("01418e64-446a-42c9-9a88-fec52649f3f0"), new DateTime(2023, 9, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, false, 1, 75m },
                    { new Guid("0a50eda4-ce05-4c73-914e-e35f37227d27"), new DateTime(2023, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, true, 2, 100m },
                    { new Guid("1fe6ad59-16e3-465e-bfc4-ba99030a5f9d"), new DateTime(2023, 7, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, true, 2, 50m },
                    { new Guid("5f150559-7a21-489f-ae6c-673ed010918a"), new DateTime(2023, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, true, 1, 150m },
                    { new Guid("71cc4ab8-9fe0-4925-8c8b-e0acc8c7ef2c"), new DateTime(2023, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, false, 2, 200m }
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
                    { new Guid("1bf6661c-eee1-4717-86b9-2a9047984e6d"), new Guid("5f150559-7a21-489f-ae6c-673ed010918a"), 3, 5, 1.5m, 2 },
                    { new Guid("1e6ef780-82b4-4c16-b00f-352e3310010e"), new Guid("71cc4ab8-9fe0-4925-8c8b-e0acc8c7ef2c"), 2, 3, 1.5m, 0 },
                    { new Guid("357614f0-6ed2-48ab-ab18-3eeb6a39d793"), new Guid("0a50eda4-ce05-4c73-914e-e35f37227d27"), 2, 1, 1.6m, 1 },
                    { new Guid("3cd1f025-ffaa-4b4f-8f67-f42d15d6fe0d"), new Guid("1fe6ad59-16e3-465e-bfc4-ba99030a5f9d"), 2, 2, 2.0m, 0 },
                    { new Guid("4e48c07a-1b43-4750-ac5e-bfa5f864061e"), new Guid("5f150559-7a21-489f-ae6c-673ed010918a"), 2, 2, 2.2m, 0 },
                    { new Guid("5116eef5-1d1e-427d-a069-a0507f37e545"), new Guid("0a50eda4-ce05-4c73-914e-e35f37227d27"), 2, 5, 2.1m, 0 },
                    { new Guid("54e8adb7-616a-45b7-8b09-8815137c07d0"), new Guid("1fe6ad59-16e3-465e-bfc4-ba99030a5f9d"), 3, 3, 1.7m, 0 },
                    { new Guid("563bc69f-122b-4ba6-b542-58bb6f51381c"), new Guid("71cc4ab8-9fe0-4925-8c8b-e0acc8c7ef2c"), 2, 5, 2.1m, 2 },
                    { new Guid("7e74b77f-8cce-4eb5-94fb-ea1971c680af"), new Guid("71cc4ab8-9fe0-4925-8c8b-e0acc8c7ef2c"), 1, 6, 2.5m, 1 },
                    { new Guid("81130f25-3d3b-4a95-820f-7352607cd045"), new Guid("1fe6ad59-16e3-465e-bfc4-ba99030a5f9d"), 1, 1, 1.5m, 0 },
                    { new Guid("924848d6-691e-4f5a-a6e2-276cbc333a7c"), new Guid("01418e64-446a-42c9-9a88-fec52649f3f0"), 3, 4, 2.0m, 0 },
                    { new Guid("b8a16683-03a5-452f-84c4-2a95b25d0a19"), new Guid("0a50eda4-ce05-4c73-914e-e35f37227d27"), 1, 6, 1.8m, 2 },
                    { new Guid("d3581729-8c26-4b07-a337-5688879070de"), new Guid("71cc4ab8-9fe0-4925-8c8b-e0acc8c7ef2c"), 3, 4, 2.4m, 0 },
                    { new Guid("e06d5ff0-b4e8-4c1b-b7e8-90828a9c9809"), new Guid("0a50eda4-ce05-4c73-914e-e35f37227d27"), 1, 4, 2.3m, 0 },
                    { new Guid("ec5524e1-da64-4242-a704-45f61640dcb2"), new Guid("71cc4ab8-9fe0-4925-8c8b-e0acc8c7ef2c"), 1, 1, 1.7m, 0 },
                    { new Guid("f132f339-0b45-40d2-80af-ad63e2c293b4"), new Guid("5f150559-7a21-489f-ae6c-673ed010918a"), 1, 3, 1.9m, 1 },
                    { new Guid("f75588f9-1919-4284-b15b-18d5b1c088b1"), new Guid("01418e64-446a-42c9-9a88-fec52649f3f0"), 2, 1, 1.6m, 0 }
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
