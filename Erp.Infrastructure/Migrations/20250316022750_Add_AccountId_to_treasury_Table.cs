using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Erp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Add_AccountId_to_treasury_Table : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AccountId",
                table: "Treasuries",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Treasuries_AccountId",
                table: "Treasuries",
                column: "AccountId");

            migrationBuilder.AddForeignKey(
                name: "FK_Treasuries_Accounts_AccountId",
                table: "Treasuries",
                column: "AccountId",
                principalTable: "Accounts",
                principalColumn: "AccountID",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Treasuries_Accounts_AccountId",
                table: "Treasuries");

            migrationBuilder.DropIndex(
                name: "IX_Treasuries_AccountId",
                table: "Treasuries");

            migrationBuilder.DropColumn(
                name: "AccountId",
                table: "Treasuries");
        }
    }
}
