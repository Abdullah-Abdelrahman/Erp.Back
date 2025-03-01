using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Erp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Cascade_when_delete_customer_to_ContactList : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_contactLists_Customers_CustomerId",
                table: "contactLists");

            migrationBuilder.AddForeignKey(
                name: "FK_contactLists_Customers_CustomerId",
                table: "contactLists",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "CustomerId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_contactLists_Customers_CustomerId",
                table: "contactLists");

            migrationBuilder.AddForeignKey(
                name: "FK_contactLists_Customers_CustomerId",
                table: "contactLists",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "CustomerId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
