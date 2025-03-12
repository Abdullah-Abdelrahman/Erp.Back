using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Erp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class add_journalentryId_to_PurchaseInvoice_accId_to_supplirer_accId_to_customer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AccountId",
                table: "Suppliers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "JournalEntryID",
                table: "PurchaseInvoices",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AccountId",
                table: "Customers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Suppliers_AccountId",
                table: "Suppliers",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseInvoices_JournalEntryID",
                table: "PurchaseInvoices",
                column: "JournalEntryID");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_AccountId",
                table: "Customers",
                column: "AccountId");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_Accounts_AccountId",
                table: "Customers",
                column: "AccountId",
                principalTable: "Accounts",
                principalColumn: "AccountID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseInvoices_journalEntries_JournalEntryID",
                table: "PurchaseInvoices",
                column: "JournalEntryID",
                principalTable: "journalEntries",
                principalColumn: "JournalEntryID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Suppliers_Accounts_AccountId",
                table: "Suppliers",
                column: "AccountId",
                principalTable: "Accounts",
                principalColumn: "AccountID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_Accounts_AccountId",
                table: "Customers");

            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseInvoices_journalEntries_JournalEntryID",
                table: "PurchaseInvoices");

            migrationBuilder.DropForeignKey(
                name: "FK_Suppliers_Accounts_AccountId",
                table: "Suppliers");

            migrationBuilder.DropIndex(
                name: "IX_Suppliers_AccountId",
                table: "Suppliers");

            migrationBuilder.DropIndex(
                name: "IX_PurchaseInvoices_JournalEntryID",
                table: "PurchaseInvoices");

            migrationBuilder.DropIndex(
                name: "IX_Customers_AccountId",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "AccountId",
                table: "Suppliers");

            migrationBuilder.DropColumn(
                name: "JournalEntryID",
                table: "PurchaseInvoices");

            migrationBuilder.DropColumn(
                name: "AccountId",
                table: "Customers");
        }
    }
}
