using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Erp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AccId_to_warehouse : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Accounts_Accounts_PrimaryAccountAccountID",
                table: "Accounts");

            migrationBuilder.DropIndex(
                name: "IX_Accounts_PrimaryAccountAccountID",
                table: "Accounts");

            migrationBuilder.DropColumn(
                name: "PrimaryAccountAccountID",
                table: "Accounts");

            migrationBuilder.AddColumn<int>(
                name: "AccountId",
                table: "Warehouses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Warehouses_AccountId",
                table: "Warehouses",
                column: "AccountId");

            migrationBuilder.AddForeignKey(
                name: "FK_Warehouses_Accounts_AccountId",
                table: "Warehouses",
                column: "AccountId",
                principalTable: "Accounts",
                principalColumn: "AccountID",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Warehouses_Accounts_AccountId",
                table: "Warehouses");

            migrationBuilder.DropIndex(
                name: "IX_Warehouses_AccountId",
                table: "Warehouses");

            migrationBuilder.DropColumn(
                name: "AccountId",
                table: "Warehouses");

            migrationBuilder.AddColumn<int>(
                name: "PrimaryAccountAccountID",
                table: "Accounts",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_PrimaryAccountAccountID",
                table: "Accounts",
                column: "PrimaryAccountAccountID");

            migrationBuilder.AddForeignKey(
                name: "FK_Accounts_Accounts_PrimaryAccountAccountID",
                table: "Accounts",
                column: "PrimaryAccountAccountID",
                principalTable: "Accounts",
                principalColumn: "AccountID");
        }
    }
}
