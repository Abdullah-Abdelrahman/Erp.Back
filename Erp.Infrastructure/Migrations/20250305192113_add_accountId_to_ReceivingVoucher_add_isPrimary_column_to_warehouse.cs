using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Erp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class add_accountId_to_ReceivingVoucher_add_isPrimary_column_to_warehouse : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ReceivingVouchers_Suppliers_SupplierId",
                table: "ReceivingVouchers");

            migrationBuilder.RenameColumn(
                name: "SupplierId",
                table: "ReceivingVouchers",
                newName: "AccountId");

            migrationBuilder.RenameIndex(
                name: "IX_ReceivingVouchers_SupplierId",
                table: "ReceivingVouchers",
                newName: "IX_ReceivingVouchers_AccountId");

            migrationBuilder.AddColumn<bool>(
                name: "IsPrimary",
                table: "Warehouses",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddForeignKey(
                name: "FK_ReceivingVouchers_Accounts_AccountId",
                table: "ReceivingVouchers",
                column: "AccountId",
                principalTable: "Accounts",
                principalColumn: "AccountID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ReceivingVouchers_Accounts_AccountId",
                table: "ReceivingVouchers");

            migrationBuilder.DropColumn(
                name: "IsPrimary",
                table: "Warehouses");

            migrationBuilder.RenameColumn(
                name: "AccountId",
                table: "ReceivingVouchers",
                newName: "SupplierId");

            migrationBuilder.RenameIndex(
                name: "IX_ReceivingVouchers_AccountId",
                table: "ReceivingVouchers",
                newName: "IX_ReceivingVouchers_SupplierId");

            migrationBuilder.AddForeignKey(
                name: "FK_ReceivingVouchers_Suppliers_SupplierId",
                table: "ReceivingVouchers",
                column: "SupplierId",
                principalTable: "Suppliers",
                principalColumn: "SupplierId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
