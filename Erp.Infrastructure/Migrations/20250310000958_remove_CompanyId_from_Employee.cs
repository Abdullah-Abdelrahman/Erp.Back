using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Erp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class remove_CompanyId_from_Employee : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_companies_CompanyID",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Employees_CompanyID",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "CompanyID",
                table: "Employees");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CompanyID",
                table: "Employees",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Employees_CompanyID",
                table: "Employees",
                column: "CompanyID");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_companies_CompanyID",
                table: "Employees",
                column: "CompanyID",
                principalTable: "companies",
                principalColumn: "CompanyID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
