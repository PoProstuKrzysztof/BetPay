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
                    Stake = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    BetDate = table.Column<DateTime>(type: "datetime2", nullable: false),
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
                table: "Bets",
                columns: new[] { "BetId", "BetDate", "Bookmaker", "IsTaxIncluded", "Stake", "Status" },
                values: new object[,]
                {
                    { new Guid("015bad62-91c7-4fae-a449-5be0457f3f98"), new DateTime(2024, 9, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "SUPERBET", true, 50m, 2 },
                    { new Guid("9a7e6f75-7b74-4f9f-a07f-4a27de8972be"), new DateTime(2024, 9, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "FORTUNA", true, 200m, 2 },
                    { new Guid("cb46de97-2c16-46f5-a9c2-569e3a4926ad"), new DateTime(2024, 9, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "BETCLIC", false, 75m, 2 },
                    { new Guid("f1c9658e-4e32-405b-9b7d-518800e1b64c"), new DateTime(2024, 9, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "STS", true, 100m, 2 },
                    { new Guid("f6bd5e7a-9b6d-45bc-b8cc-0ecb390243dd"), new DateTime(2024, 9, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "BETFAN", true, 150m, 2 }
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
                    { new Guid("1d5660b7-b7e9-404e-8d14-121c385dd125"), new Guid("cb46de97-2c16-46f5-a9c2-569e3a4926ad"), 2, 2, 1.7m, 2 },
                    { new Guid("22f0084d-490d-4c52-bcf0-6f00e24d59a0"), new Guid("f6bd5e7a-9b6d-45bc-b8cc-0ecb390243dd"), 1, 3, 2.1m, 0 },
                    { new Guid("2c838f49-e594-4cb3-877c-c9821e912c2e"), new Guid("015bad62-91c7-4fae-a449-5be0457f3f98"), 1, 1, 1.5m, 0 },
                    { new Guid("3c2ebcde-7914-41bd-9287-6fe85d5e1d81"), new Guid("015bad62-91c7-4fae-a449-5be0457f3f98"), 2, 2, 2.0m, 0 },
                    { new Guid("3ebaffe4-5286-4157-8274-d1e907b5a40f"), new Guid("f1c9658e-4e32-405b-9b7d-518800e1b64c"), 3, 4, 2.2m, 1 },
                    { new Guid("91611eef-bf4f-480c-9ab0-152871e946b4"), new Guid("f6bd5e7a-9b6d-45bc-b8cc-0ecb390243dd"), 3, 4, 2.3m, 0 },
                    { new Guid("965182d1-eac8-460a-9b89-139e5a942e52"), new Guid("f1c9658e-4e32-405b-9b7d-518800e1b64c"), 1, 3, 1.8m, 0 },
                    { new Guid("9a47d4c2-11ac-4c60-9f3b-41175eb98dfb"), new Guid("9a7e6f75-7b74-4f9f-a07f-4a27de8972be"), 2, 1, 1.6m, 2 },
                    { new Guid("d052d5d3-8386-44e1-bd14-6db8846cddb3"), new Guid("9a7e6f75-7b74-4f9f-a07f-4a27de8972be"), 1, 3, 2.5m, 2 },
                    { new Guid("d14ad669-9356-40e5-b74e-59ba7023d8ff"), new Guid("cb46de97-2c16-46f5-a9c2-569e3a4926ad"), 3, 4, 2.0m, 0 }
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
