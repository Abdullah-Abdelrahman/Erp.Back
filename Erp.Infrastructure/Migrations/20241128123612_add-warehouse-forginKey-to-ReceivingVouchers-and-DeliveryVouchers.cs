using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Erp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addwarehouseforginKeytoReceivingVouchersandDeliveryVouchers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "WarehouseId",
                table: "ReceivingVouchers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "WarehouseId",
                table: "DeliveryVouchers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ReceivingVouchers_WarehouseId",
                table: "ReceivingVouchers",
                column: "WarehouseId");

            migrationBuilder.CreateIndex(
                name: "IX_DeliveryVouchers_WarehouseId",
                table: "DeliveryVouchers",
                column: "WarehouseId");

            migrationBuilder.AddForeignKey(
                name: "FK_DeliveryVouchers_Warehouses_WarehouseId",
                table: "DeliveryVouchers",
                column: "WarehouseId",
                principalTable: "Warehouses",
                principalColumn: "WarehouseId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ReceivingVouchers_Warehouses_WarehouseId",
                table: "ReceivingVouchers",
                column: "WarehouseId",
                principalTable: "Warehouses",
                principalColumn: "WarehouseId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DeliveryVouchers_Warehouses_WarehouseId",
                table: "DeliveryVouchers");

            migrationBuilder.DropForeignKey(
                name: "FK_ReceivingVouchers_Warehouses_WarehouseId",
                table: "ReceivingVouchers");

            migrationBuilder.DropIndex(
                name: "IX_ReceivingVouchers_WarehouseId",
                table: "ReceivingVouchers");

            migrationBuilder.DropIndex(
                name: "IX_DeliveryVouchers_WarehouseId",
                table: "DeliveryVouchers");

            migrationBuilder.DropColumn(
                name: "WarehouseId",
                table: "ReceivingVouchers");

            migrationBuilder.DropColumn(
                name: "WarehouseId",
                table: "DeliveryVouchers");
        }
    }
}
