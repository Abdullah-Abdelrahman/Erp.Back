using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Erp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Change_Employee_model : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "Employee");

            migrationBuilder.RenameColumn(
                name: "Address",
                table: "Employee",
                newName: "TenantId");

            migrationBuilder.AddColumn<string>(
                name: "Address1",
                table: "Employee",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Address2",
                table: "Employee",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "Employee",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Country",
                table: "Employee",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImagePath",
                table: "Employee",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Landline",
                table: "Employee",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Notes",
                table: "Employee",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PrivateEmail",
                table: "Employee",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "postcode",
                table: "Employee",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "zone",
                table: "Employee",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address1",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "Address2",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "City",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "Country",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "ImagePath",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "Landline",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "Notes",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "PrivateEmail",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "postcode",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "zone",
                table: "Employee");

            migrationBuilder.RenameColumn(
                name: "TenantId",
                table: "Employee",
                newName: "Address");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Employee",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");
        }
    }
}
