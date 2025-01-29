using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Erp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addCustomersModuleclasses : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CustomerName",
                table: "Customers");

            migrationBuilder.RenameColumn(
                name: "ContactInfo",
                table: "Customers",
                newName: "zone");

            migrationBuilder.RenameColumn(
                name: "Address",
                table: "Customers",
                newName: "postcode");

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ClassificationId",
                table: "Customers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CommercialName",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Commercialregister",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Country",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CustomerType",
                table: "Customers",
                type: "nvarchar(13)",
                maxLength: 13,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FullName",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Landline",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Notes",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StreetAddress1",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StreetAddress2",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TaxCard",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "billingMethod",
                table: "Customers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "contactLists",
                columns: table => new
                {
                    ContactListId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Landline = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CustomerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_contactLists", x => x.ContactListId);
                    table.ForeignKey(
                        name: "FK_contactLists_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "customerClassifications",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_customerClassifications", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Customers_ClassificationId",
                table: "Customers",
                column: "ClassificationId");

            migrationBuilder.CreateIndex(
                name: "IX_contactLists_CustomerId",
                table: "contactLists",
                column: "CustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_customerClassifications_ClassificationId",
                table: "Customers",
                column: "ClassificationId",
                principalTable: "customerClassifications",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_customerClassifications_ClassificationId",
                table: "Customers");

            migrationBuilder.DropTable(
                name: "contactLists");

            migrationBuilder.DropTable(
                name: "customerClassifications");

            migrationBuilder.DropIndex(
                name: "IX_Customers_ClassificationId",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "City",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "ClassificationId",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "CommercialName",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "Commercialregister",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "Country",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "CustomerType",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "FullName",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "Landline",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "Notes",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "StreetAddress1",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "StreetAddress2",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "TaxCard",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "billingMethod",
                table: "Customers");

            migrationBuilder.RenameColumn(
                name: "zone",
                table: "Customers",
                newName: "ContactInfo");

            migrationBuilder.RenameColumn(
                name: "postcode",
                table: "Customers",
                newName: "Address");

            migrationBuilder.AddColumn<string>(
                name: "CustomerName",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
