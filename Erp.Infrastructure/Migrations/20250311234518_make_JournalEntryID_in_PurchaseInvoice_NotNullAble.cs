using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Erp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class make_JournalEntryID_in_PurchaseInvoice_NotNullAble : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseInvoices_journalEntries_JournalEntryID",
                table: "PurchaseInvoices");

            migrationBuilder.AlterColumn<int>(
                name: "JournalEntryID",
                table: "PurchaseInvoices",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseInvoices_journalEntries_JournalEntryID",
                table: "PurchaseInvoices",
                column: "JournalEntryID",
                principalTable: "journalEntries",
                principalColumn: "JournalEntryID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseInvoices_journalEntries_JournalEntryID",
                table: "PurchaseInvoices");

            migrationBuilder.AlterColumn<int>(
                name: "JournalEntryID",
                table: "PurchaseInvoices",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseInvoices_journalEntries_JournalEntryID",
                table: "PurchaseInvoices",
                column: "JournalEntryID",
                principalTable: "journalEntries",
                principalColumn: "JournalEntryID");
        }
    }
}
