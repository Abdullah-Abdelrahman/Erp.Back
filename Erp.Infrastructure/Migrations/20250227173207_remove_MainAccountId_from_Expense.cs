using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Erp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class remove_MainAccountId_from_Expense : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Expenses_Accounts_MainAccountId",
                table: "Expenses");

            migrationBuilder.DropForeignKey(
                name: "FK_Receipts_Accounts_MainAccountId",
                table: "Receipts");

            migrationBuilder.DropIndex(
                name: "IX_Receipts_MainAccountId",
                table: "Receipts");

            migrationBuilder.DropIndex(
                name: "IX_Expenses_MainAccountId",
                table: "Expenses");

            migrationBuilder.DropColumn(
                name: "MainAccountId",
                table: "Receipts");

            migrationBuilder.DropColumn(
                name: "MainAccountId",
                table: "Expenses");

            migrationBuilder.AddColumn<int>(
                name: "ReceiptId",
                table: "ReceiptCategories",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ReceiptCategories_ReceiptId",
                table: "ReceiptCategories",
                column: "ReceiptId");

            migrationBuilder.AddForeignKey(
                name: "FK_ReceiptCategories_Receipts_ReceiptId",
                table: "ReceiptCategories",
                column: "ReceiptId",
                principalTable: "Receipts",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ReceiptCategories_Receipts_ReceiptId",
                table: "ReceiptCategories");

            migrationBuilder.DropIndex(
                name: "IX_ReceiptCategories_ReceiptId",
                table: "ReceiptCategories");

            migrationBuilder.DropColumn(
                name: "ReceiptId",
                table: "ReceiptCategories");

            migrationBuilder.AddColumn<int>(
                name: "MainAccountId",
                table: "Receipts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MainAccountId",
                table: "Expenses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Receipts_MainAccountId",
                table: "Receipts",
                column: "MainAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_Expenses_MainAccountId",
                table: "Expenses",
                column: "MainAccountId");

            migrationBuilder.AddForeignKey(
                name: "FK_Expenses_Accounts_MainAccountId",
                table: "Expenses",
                column: "MainAccountId",
                principalTable: "Accounts",
                principalColumn: "AccountID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Receipts_Accounts_MainAccountId",
                table: "Receipts",
                column: "MainAccountId",
                principalTable: "Accounts",
                principalColumn: "AccountID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
