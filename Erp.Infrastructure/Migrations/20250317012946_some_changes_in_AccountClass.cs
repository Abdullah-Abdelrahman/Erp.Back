using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Erp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class some_changes_in_AccountClass : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_journalEntryDetails_Accounts_SecondaryAccountAccountID",
                table: "journalEntryDetails");

            migrationBuilder.DropIndex(
                name: "IX_journalEntryDetails_SecondaryAccountAccountID",
                table: "journalEntryDetails");

            migrationBuilder.DropColumn(
                name: "SecondaryAccountAccountID",
                table: "journalEntryDetails");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SecondaryAccountAccountID",
                table: "journalEntryDetails",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_journalEntryDetails_SecondaryAccountAccountID",
                table: "journalEntryDetails",
                column: "SecondaryAccountAccountID");

            migrationBuilder.AddForeignKey(
                name: "FK_journalEntryDetails_Accounts_SecondaryAccountAccountID",
                table: "journalEntryDetails",
                column: "SecondaryAccountAccountID",
                principalTable: "Accounts",
                principalColumn: "AccountID");
        }
    }
}
