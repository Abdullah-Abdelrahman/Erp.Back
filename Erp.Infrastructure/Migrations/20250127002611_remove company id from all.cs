using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Erp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class removecompanyidfromall : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Accounts_Company_CompanyID",
                table: "Accounts");

            migrationBuilder.DropForeignKey(
                name: "FK_journalEntries_Company_CompanyID",
                table: "journalEntries");

            migrationBuilder.DropTable(
                name: "Company");

            migrationBuilder.DropIndex(
                name: "IX_journalEntries_CompanyID",
                table: "journalEntries");

            migrationBuilder.DropIndex(
                name: "IX_Accounts_CompanyID",
                table: "Accounts");

            migrationBuilder.DropColumn(
                name: "CompanyID",
                table: "journalEntries");

            migrationBuilder.DropColumn(
                name: "CompanyID",
                table: "Accounts");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CompanyID",
                table: "journalEntries",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CompanyID",
                table: "Accounts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Company",
                columns: table => new
                {
                    CompanyID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CompanyEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CompanyName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Domain = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    SubscriptionEndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SubscriptionStartDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Company", x => x.CompanyID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_journalEntries_CompanyID",
                table: "journalEntries",
                column: "CompanyID");

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_CompanyID",
                table: "Accounts",
                column: "CompanyID");

            migrationBuilder.AddForeignKey(
                name: "FK_Accounts_Company_CompanyID",
                table: "Accounts",
                column: "CompanyID",
                principalTable: "Company",
                principalColumn: "CompanyID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_journalEntries_Company_CompanyID",
                table: "journalEntries",
                column: "CompanyID",
                principalTable: "Company",
                principalColumn: "CompanyID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
