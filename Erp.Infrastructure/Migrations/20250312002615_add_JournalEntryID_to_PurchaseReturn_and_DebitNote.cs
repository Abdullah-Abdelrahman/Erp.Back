using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Erp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class add_JournalEntryID_to_PurchaseReturn_and_DebitNote : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "JournalEntryID",
                table: "PurchaseReturns",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "JournalEntryID",
                table: "DebitNotes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseReturns_JournalEntryID",
                table: "PurchaseReturns",
                column: "JournalEntryID");

            migrationBuilder.CreateIndex(
                name: "IX_DebitNotes_JournalEntryID",
                table: "DebitNotes",
                column: "JournalEntryID");

            migrationBuilder.AddForeignKey(
                name: "FK_DebitNotes_journalEntries_JournalEntryID",
                table: "DebitNotes",
                column: "JournalEntryID",
                principalTable: "journalEntries",
                principalColumn: "JournalEntryID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseReturns_journalEntries_JournalEntryID",
                table: "PurchaseReturns",
                column: "JournalEntryID",
                principalTable: "journalEntries",
                principalColumn: "JournalEntryID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DebitNotes_journalEntries_JournalEntryID",
                table: "DebitNotes");

            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseReturns_journalEntries_JournalEntryID",
                table: "PurchaseReturns");

            migrationBuilder.DropIndex(
                name: "IX_PurchaseReturns_JournalEntryID",
                table: "PurchaseReturns");

            migrationBuilder.DropIndex(
                name: "IX_DebitNotes_JournalEntryID",
                table: "DebitNotes");

            migrationBuilder.DropColumn(
                name: "JournalEntryID",
                table: "PurchaseReturns");

            migrationBuilder.DropColumn(
                name: "JournalEntryID",
                table: "DebitNotes");
        }
    }
}
