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
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                    { new Guid("3456b480-cae4-4f7c-8ea7-0eb2b59f3729"), new DateTime(2024, 9, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, true, 50m, 2 },
                    { new Guid("79c7f426-642a-485d-a336-d0b7c4a16221"), new DateTime(2024, 9, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, true, 150m, 2 },
                    { new Guid("9c98dfb8-a1d8-4c1c-9578-b5be275e91c1"), new DateTime(2024, 9, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, true, 200m, 2 },
                    { new Guid("9de8a868-a069-4ed8-8509-8e14e344922b"), new DateTime(2024, 9, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, false, 75m, 2 },
                    { new Guid("d02d02a6-7675-487e-82d1-f88957f40b73"), new DateTime(2024, 9, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, true, 100m, 2 }
                });

            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "EventId", "BetId", "CategoryId", "EventTypeId", "Odds", "Status" },
                values: new object[,]
                {
                    { new Guid("071580ce-a269-4d5d-82f2-9f4a3be58e23"), new Guid("79c7f426-642a-485d-a336-d0b7c4a16221"), 1, 3, 2.1m, 0 },
                    { new Guid("10b2bc74-2349-4c65-9742-4a7b35f78f19"), new Guid("9de8a868-a069-4ed8-8509-8e14e344922b"), 2, 2, 1.7m, 2 },
                    { new Guid("2a9a7536-e881-4c16-bf25-a7bf0259b6c8"), new Guid("9de8a868-a069-4ed8-8509-8e14e344922b"), 3, 4, 2.0m, 0 },
                    { new Guid("3497dddd-1d2f-49f0-88e2-bbe02af4fb07"), new Guid("3456b480-cae4-4f7c-8ea7-0eb2b59f3729"), 2, 2, 2.0m, 0 },
                    { new Guid("8a0f3d52-78ce-4669-a2a2-525ccd18cff7"), new Guid("3456b480-cae4-4f7c-8ea7-0eb2b59f3729"), 1, 1, 1.5m, 0 },
                    { new Guid("953ef1be-60d0-4aa4-94e0-383cb6cb2378"), new Guid("d02d02a6-7675-487e-82d1-f88957f40b73"), 3, 4, 2.2m, 1 },
                    { new Guid("9f56b533-8578-4a3b-a5be-57db33445653"), new Guid("9c98dfb8-a1d8-4c1c-9578-b5be275e91c1"), 1, 3, 2.5m, 2 },
                    { new Guid("a4db33e8-c219-42ac-8149-5e5e72549215"), new Guid("79c7f426-642a-485d-a336-d0b7c4a16221"), 3, 4, 2.3m, 0 },
                    { new Guid("db9abc7c-8fbf-40b4-9770-cd1c70d665b0"), new Guid("9c98dfb8-a1d8-4c1c-9578-b5be275e91c1"), 2, 1, 1.6m, 2 },
                    { new Guid("ef60c06e-ed3b-42c2-b8f7-2c01c875a6c5"), new Guid("d02d02a6-7675-487e-82d1-f88957f40b73"), 1, 3, 1.8m, 0 }
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
