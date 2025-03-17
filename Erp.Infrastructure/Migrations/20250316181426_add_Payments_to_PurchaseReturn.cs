using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Erp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class add_Payments_to_PurchaseReturn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PurchaseReturnId",
                table: "payments",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_payments_PurchaseReturnId",
                table: "payments",
                column: "PurchaseReturnId");

            migrationBuilder.AddForeignKey(
                name: "FK_payments_PurchaseReturns_PurchaseReturnId",
                table: "payments",
                column: "PurchaseReturnId",
                principalTable: "PurchaseReturns",
                principalColumn: "PurchaseReturnId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_payments_PurchaseReturns_PurchaseReturnId",
                table: "payments");

            migrationBuilder.DropIndex(
                name: "IX_payments_PurchaseReturnId",
                table: "payments");

            migrationBuilder.DropColumn(
                name: "PurchaseReturnId",
                table: "payments");
        }
    }
}
