using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Erp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Add_JournalEntryID_PurchaseReturnId_CustomerId_To_DeliveryVoucher : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CustomerId",
                table: "DeliveryVouchers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "JournalEntryID",
                table: "DeliveryVouchers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "purchaseReturnId",
                table: "DeliveryVouchers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_DeliveryVouchers_CustomerId",
                table: "DeliveryVouchers",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_DeliveryVouchers_JournalEntryID",
                table: "DeliveryVouchers",
                column: "JournalEntryID");

            migrationBuilder.CreateIndex(
                name: "IX_DeliveryVouchers_purchaseReturnId",
                table: "DeliveryVouchers",
                column: "purchaseReturnId");

            migrationBuilder.AddForeignKey(
                name: "FK_DeliveryVouchers_Customers_CustomerId",
                table: "DeliveryVouchers",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "CustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_DeliveryVouchers_PurchaseReturns_purchaseReturnId",
                table: "DeliveryVouchers",
                column: "purchaseReturnId",
                principalTable: "PurchaseReturns",
                principalColumn: "PurchaseReturnId");

            migrationBuilder.AddForeignKey(
                name: "FK_DeliveryVouchers_journalEntries_JournalEntryID",
                table: "DeliveryVouchers",
                column: "JournalEntryID",
                principalTable: "journalEntries",
                principalColumn: "JournalEntryID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DeliveryVouchers_Customers_CustomerId",
                table: "DeliveryVouchers");

            migrationBuilder.DropForeignKey(
                name: "FK_DeliveryVouchers_PurchaseReturns_purchaseReturnId",
                table: "DeliveryVouchers");

            migrationBuilder.DropForeignKey(
                name: "FK_DeliveryVouchers_journalEntries_JournalEntryID",
                table: "DeliveryVouchers");

            migrationBuilder.DropIndex(
                name: "IX_DeliveryVouchers_CustomerId",
                table: "DeliveryVouchers");

            migrationBuilder.DropIndex(
                name: "IX_DeliveryVouchers_JournalEntryID",
                table: "DeliveryVouchers");

            migrationBuilder.DropIndex(
                name: "IX_DeliveryVouchers_purchaseReturnId",
                table: "DeliveryVouchers");

            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "DeliveryVouchers");

            migrationBuilder.DropColumn(
                name: "JournalEntryID",
                table: "DeliveryVouchers");

            migrationBuilder.DropColumn(
                name: "purchaseReturnId",
                table: "DeliveryVouchers");
        }
    }
}
