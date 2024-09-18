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
                    { 2, "/Images/Bookmakers/superbet-icon.jpg", "Superbet" },
                    { 3, "/Images/Bookmakers/fortuna-icon.jpg", "Fortuna" },
                    { 4, "/Images/Bookmakers/sts-icon.jpg", "STS" },
                    { 5, "/Images/Bookmakers/betfan-icon.jpg", "Betfan" },
                    { 6, null, "Fuksiarz" },
                    { 7, "/Images/Bookmakers/lvbet-icon.jpg", "LvBet" },
                    { 8, null, "Betters" },
                    { 9, null, "Betcris" },
                    { 10, "/Images/Bookmakers/gobet-icon.jpg", "GoBet" },
                    { 11, "/Images/Bookmakers/totalbet-icon.jpg", "TotalBet" },
                    { 12, null, "ForBet" },
                    { 13, "/Images/Bookmakers/etoto-icon.jpg", "Etoto" },
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
                    { new Guid("010a8681-e495-4db5-a798-80f74e65a72f"), new DateTime(2024, 10, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 10, true, 45m },
                    { new Guid("054fe7b7-27f9-493f-9133-df2e8bcf5894"), new DateTime(2023, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, true, 100m },
                    { new Guid("20856cdf-d0d2-434d-952a-095f35f56adf"), new DateTime(2024, 4, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 13, true, 90m },
                    { new Guid("2b145187-99ca-4311-845c-31ab4b92804e"), new DateTime(2024, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 10, true, 60m },
                    { new Guid("3eac28ae-3c55-4819-8e4e-e5bbe160309a"), new DateTime(2024, 8, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, true, 110m },
                    { new Guid("46f1ab93-bc71-4fb9-a1d8-38df79356619"), new DateTime(2024, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, true, 40m },
                    { new Guid("4a109156-7bd6-44ee-9f14-b5d3f570b6ff"), new DateTime(2024, 9, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 13, true, 105m },
                    { new Guid("4ae85ac0-c731-4725-8ec6-ceab35450376"), new DateTime(2024, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 7, true, 150m },
                    { new Guid("56606df7-634e-488a-a66a-ab3ed1340404"), new DateTime(2023, 7, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, true, 50m },
                    { new Guid("59dffedb-dd1d-448b-aa78-c904d710da1d"), new DateTime(2024, 11, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, true, 65m },
                    { new Guid("5c7173da-2bcf-4477-8239-b6e5bd75b26f"), new DateTime(2024, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 11, true, 85m },
                    { new Guid("62a473e9-5b1f-4176-b61a-089b5dc0e9e0"), new DateTime(2024, 9, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, true, 70m },
                    { new Guid("62f5c2af-4375-4499-98cf-572749a51b5f"), new DateTime(2023, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, false, 200m },
                    { new Guid("8e026f46-4d89-4ea4-8807-b2a7c77ba13b"), new DateTime(2024, 3, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, true, 120m },
                    { new Guid("9bdee23b-918f-4e5e-b353-1558706087b2"), new DateTime(2024, 9, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, true, 95m },
                    { new Guid("aa6daec8-dbc3-4eaa-8ad0-92b10894e53e"), new DateTime(2024, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, true, 130m },
                    { new Guid("e439a252-b890-41ee-ab00-a02c15a7cc99"), new DateTime(2023, 9, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, false, 75m },
                    { new Guid("e72472cf-ec75-4128-9015-c78e51947f72"), new DateTime(2023, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 11, true, 150m },
                    { new Guid("ee1611d2-68f2-4bf5-ad7a-74f2a49c6121"), new DateTime(2024, 7, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 7, true, 80m }
                });

            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "EventId", "BetId", "CategoryId", "EventTypeId", "Odds", "Status" },
                values: new object[,]
                {
                    { new Guid("17e58c2d-4aaf-480d-a094-cbb408ddc385"), new Guid("62f5c2af-4375-4499-98cf-572749a51b5f"), 2, 5, 2.1m, 2 },
                    { new Guid("1f62cdb9-2271-4c23-a875-b0d6c4e5ad69"), new Guid("054fe7b7-27f9-493f-9133-df2e8bcf5894"), 1, 6, 1.8m, 2 },
                    { new Guid("24a11241-5020-4726-b0a5-fc8df4246d2c"), new Guid("054fe7b7-27f9-493f-9133-df2e8bcf5894"), 1, 4, 2.3m, 0 },
                    { new Guid("43f0117f-0526-403b-8f29-e0b579158694"), new Guid("56606df7-634e-488a-a66a-ab3ed1340404"), 1, 1, 1.5m, 0 },
                    { new Guid("43fb44f0-6f06-481e-a6ab-c0b8ae8268fc"), new Guid("62f5c2af-4375-4499-98cf-572749a51b5f"), 3, 4, 2.4m, 0 },
                    { new Guid("44b21f53-351e-4c95-b55a-ae482d3a7ab9"), new Guid("e439a252-b890-41ee-ab00-a02c15a7cc99"), 2, 1, 1.6m, 0 },
                    { new Guid("4e5e6bb2-7b65-4f67-9451-0ed49f2fbc71"), new Guid("e72472cf-ec75-4128-9015-c78e51947f72"), 3, 5, 1.5m, 2 },
                    { new Guid("58004cc9-4a6e-435d-99dd-7a8d2fe10f50"), new Guid("e439a252-b890-41ee-ab00-a02c15a7cc99"), 3, 4, 2.0m, 0 },
                    { new Guid("602e3c6c-4cb4-4e22-abc9-1fd4a5f6b5fc"), new Guid("62f5c2af-4375-4499-98cf-572749a51b5f"), 2, 3, 1.5m, 0 },
                    { new Guid("6515529f-bda4-4548-931e-ec330d983327"), new Guid("054fe7b7-27f9-493f-9133-df2e8bcf5894"), 2, 5, 2.1m, 0 },
                    { new Guid("695b9a7a-6e39-4a9e-903c-29a5fc13cf97"), new Guid("62f5c2af-4375-4499-98cf-572749a51b5f"), 1, 6, 2.5m, 1 },
                    { new Guid("6e14b4c6-1c30-48c7-8889-e84196369c68"), new Guid("62f5c2af-4375-4499-98cf-572749a51b5f"), 1, 1, 1.7m, 0 },
                    { new Guid("775646ef-f9d7-482c-aba0-2bc2b883a1a4"), new Guid("56606df7-634e-488a-a66a-ab3ed1340404"), 2, 2, 2.0m, 0 },
                    { new Guid("a7ff257c-3697-4c56-ab85-4b5d0840f3b9"), new Guid("e72472cf-ec75-4128-9015-c78e51947f72"), 2, 2, 2.2m, 0 },
                    { new Guid("b8dca998-a42e-4a32-a140-238ac26832f8"), new Guid("054fe7b7-27f9-493f-9133-df2e8bcf5894"), 2, 1, 1.6m, 1 },
                    { new Guid("dc40bafb-abd2-4c2b-bf29-adfc2784d9ce"), new Guid("56606df7-634e-488a-a66a-ab3ed1340404"), 3, 3, 1.7m, 0 },
                    { new Guid("e3f3fa73-712c-439f-9337-9af0185bd3b2"), new Guid("e72472cf-ec75-4128-9015-c78e51947f72"), 1, 3, 1.9m, 1 }
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
