using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Erp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class add_StockTaking_table : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "stockTakings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TenantId = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_stockTakings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "stockTakingItems",
                columns: table => new
                {
                    StockTakingId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    NumberIStock = table.Column<int>(type: "int", nullable: false),
                    NumberInProgram = table.Column<int>(type: "int", nullable: false),
                    DecreaseAndExcess = table.Column<int>(type: "int", nullable: false),
                    TenantId = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_stockTakingItems", x => new { x.StockTakingId, x.ProductId });
                    table.ForeignKey(
                        name: "FK_stockTakingItems_productAndServiceBases_ProductId",
                        column: x => x.ProductId,
                        principalTable: "productAndServiceBases",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_stockTakingItems_stockTakings_StockTakingId",
                        column: x => x.StockTakingId,
                        principalTable: "stockTakings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_stockTakingItems_ProductId",
                table: "stockTakingItems",
                column: "ProductId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "stockTakingItems");

            migrationBuilder.DropTable(
                name: "stockTakings");
        }
    }
}
