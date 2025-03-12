using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Erp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class update_DeliveryVoucher_add_status_and_account_column : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "ToWarehouseId",
                table: "transformVouchers",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "FromWarehouseId",
                table: "transformVouchers",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AccountId",
                table: "DeliveryVouchers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "VoucherStatusId",
                table: "DeliveryVouchers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_DeliveryVouchers_AccountId",
                table: "DeliveryVouchers",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_DeliveryVouchers_VoucherStatusId",
                table: "DeliveryVouchers",
                column: "VoucherStatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_DeliveryVouchers_Accounts_AccountId",
                table: "DeliveryVouchers",
                column: "AccountId",
                principalTable: "Accounts",
                principalColumn: "AccountID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DeliveryVouchers_voucherStatuses_VoucherStatusId",
                table: "DeliveryVouchers",
                column: "VoucherStatusId",
                principalTable: "voucherStatuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DeliveryVouchers_Accounts_AccountId",
                table: "DeliveryVouchers");

            migrationBuilder.DropForeignKey(
                name: "FK_DeliveryVouchers_voucherStatuses_VoucherStatusId",
                table: "DeliveryVouchers");

            migrationBuilder.DropIndex(
                name: "IX_DeliveryVouchers_AccountId",
                table: "DeliveryVouchers");

            migrationBuilder.DropIndex(
                name: "IX_DeliveryVouchers_VoucherStatusId",
                table: "DeliveryVouchers");

            migrationBuilder.DropColumn(
                name: "AccountId",
                table: "DeliveryVouchers");

            migrationBuilder.DropColumn(
                name: "VoucherStatusId",
                table: "DeliveryVouchers");

            migrationBuilder.AlterColumn<int>(
                name: "ToWarehouseId",
                table: "transformVouchers",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "FromWarehouseId",
                table: "transformVouchers",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");
        }
    }
}
