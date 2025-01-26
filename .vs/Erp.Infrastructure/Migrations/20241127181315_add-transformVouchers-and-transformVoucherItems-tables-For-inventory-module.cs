using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Erp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addtransformVouchersandtransformVoucherItemstablesForinventorymodule : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SalesOrders_Customers_CustomerId",
                table: "SalesOrders");

            migrationBuilder.DropIndex(
                name: "IX_SalesOrders_CustomerId",
                table: "SalesOrders");

            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "SalesOrders");

            migrationBuilder.DropColumn(
                name: "OrderDate",
                table: "SalesOrders");

            migrationBuilder.DropColumn(
                name: "OrderDate",
                table: "PurchaseOrders");

            migrationBuilder.AddColumn<string>(
                name: "ImagePath",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "isActive",
                table: "Products",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "transformVouchers",
                columns: table => new
                {
                    TransformVoucherId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TransformDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FromWarehouseId = table.Column<int>(type: "int", nullable: true),
                    ToWarehouseId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_transformVouchers", x => x.TransformVoucherId);
                    table.ForeignKey(
                        name: "FK_transformVouchers_Warehouses_FromWarehouseId",
                        column: x => x.FromWarehouseId,
                        principalTable: "Warehouses",
                        principalColumn: "WarehouseId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_transformVouchers_Warehouses_ToWarehouseId",
                        column: x => x.ToWarehouseId,
                        principalTable: "Warehouses",
                        principalColumn: "WarehouseId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "transformVoucherItems",
                columns: table => new
                {
                    TransformVoucherItemId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    transformVoucherId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_transformVoucherItems", x => x.TransformVoucherItemId);
                    table.ForeignKey(
                        name: "FK_transformVoucherItems_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_transformVoucherItems_transformVouchers_transformVoucherId",
                        column: x => x.transformVoucherId,
                        principalTable: "transformVouchers",
                        principalColumn: "TransformVoucherId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_transformVoucherItems_ProductId",
                table: "transformVoucherItems",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_transformVoucherItems_transformVoucherId",
                table: "transformVoucherItems",
                column: "transformVoucherId");

            migrationBuilder.CreateIndex(
                name: "IX_transformVouchers_FromWarehouseId",
                table: "transformVouchers",
                column: "FromWarehouseId");

            migrationBuilder.CreateIndex(
                name: "IX_transformVouchers_ToWarehouseId",
                table: "transformVouchers",
                column: "ToWarehouseId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "transformVoucherItems");

            migrationBuilder.DropTable(
                name: "transformVouchers");

            migrationBuilder.DropColumn(
                name: "ImagePath",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "isActive",
                table: "Products");

            migrationBuilder.AddColumn<int>(
                name: "CustomerId",
                table: "SalesOrders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "OrderDate",
                table: "SalesOrders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "OrderDate",
                table: "PurchaseOrders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateIndex(
                name: "IX_SalesOrders_CustomerId",
                table: "SalesOrders",
                column: "CustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_SalesOrders_Customers_CustomerId",
                table: "SalesOrders",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "CustomerId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
