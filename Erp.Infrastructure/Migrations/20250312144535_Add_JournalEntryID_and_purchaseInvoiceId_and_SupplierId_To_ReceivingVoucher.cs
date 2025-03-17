using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Erp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Add_JournalEntryID_and_purchaseInvoiceId_and_SupplierId_To_ReceivingVoucher : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "JournalEntryID",
                table: "ReceivingVouchers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SupplierId",
                table: "ReceivingVouchers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "purchaseInvoiceId",
                table: "ReceivingVouchers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ReceivingVouchers_JournalEntryID",
                table: "ReceivingVouchers",
                column: "JournalEntryID");

            migrationBuilder.CreateIndex(
                name: "IX_ReceivingVouchers_purchaseInvoiceId",
                table: "ReceivingVouchers",
                column: "purchaseInvoiceId");

            migrationBuilder.CreateIndex(
                name: "IX_ReceivingVouchers_SupplierId",
                table: "ReceivingVouchers",
                column: "SupplierId");

            migrationBuilder.AddForeignKey(
                name: "FK_ReceivingVouchers_PurchaseInvoices_purchaseInvoiceId",
                table: "ReceivingVouchers",
                column: "purchaseInvoiceId",
                principalTable: "PurchaseInvoices",
                principalColumn: "PurchaseInvoiceId");

            migrationBuilder.AddForeignKey(
                name: "FK_ReceivingVouchers_Suppliers_SupplierId",
                table: "ReceivingVouchers",
                column: "SupplierId",
                principalTable: "Suppliers",
                principalColumn: "SupplierId");

            migrationBuilder.AddForeignKey(
                name: "FK_ReceivingVouchers_journalEntries_JournalEntryID",
                table: "ReceivingVouchers",
                column: "JournalEntryID",
                principalTable: "journalEntries",
                principalColumn: "JournalEntryID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ReceivingVouchers_PurchaseInvoices_purchaseInvoiceId",
                table: "ReceivingVouchers");

            migrationBuilder.DropForeignKey(
                name: "FK_ReceivingVouchers_Suppliers_SupplierId",
                table: "ReceivingVouchers");

            migrationBuilder.DropForeignKey(
                name: "FK_ReceivingVouchers_journalEntries_JournalEntryID",
                table: "ReceivingVouchers");

            migrationBuilder.DropIndex(
                name: "IX_ReceivingVouchers_JournalEntryID",
                table: "ReceivingVouchers");

            migrationBuilder.DropIndex(
                name: "IX_ReceivingVouchers_purchaseInvoiceId",
                table: "ReceivingVouchers");

            migrationBuilder.DropIndex(
                name: "IX_ReceivingVouchers_SupplierId",
                table: "ReceivingVouchers");

            migrationBuilder.DropColumn(
                name: "JournalEntryID",
                table: "ReceivingVouchers");

            migrationBuilder.DropColumn(
                name: "SupplierId",
                table: "ReceivingVouchers");

            migrationBuilder.DropColumn(
                name: "purchaseInvoiceId",
                table: "ReceivingVouchers");
        }
    }
}
