using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Erp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class add_Main_modul_Tables_Subscrption_still_need_updates : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Module_Subscription_SubscriptionId",
                table: "Module");

            migrationBuilder.DropForeignKey(
                name: "FK_Subscription_companies_CompanyID",
                table: "Subscription");

            migrationBuilder.DropTable(
                name: "applicationClaims");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Subscription",
                table: "Subscription");

            migrationBuilder.DropIndex(
                name: "IX_Subscription_CompanyID",
                table: "Subscription");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Module",
                table: "Module");

            migrationBuilder.DropIndex(
                name: "IX_Module_SubscriptionId",
                table: "Module");

            migrationBuilder.DropColumn(
                name: "CompanyID",
                table: "Subscription");

            migrationBuilder.DropColumn(
                name: "SubscriptionId",
                table: "Module");

            migrationBuilder.RenameTable(
                name: "Subscription",
                newName: "subscriptions");

            migrationBuilder.RenameTable(
                name: "Module",
                newName: "modules");

            migrationBuilder.AddColumn<int>(
                name: "Duration",
                table: "subscriptions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "modules",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ClaimList",
                table: "modules",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "[]");

            migrationBuilder.AddPrimaryKey(
                name: "PK_subscriptions",
                table: "subscriptions",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_modules",
                table: "modules",
                column: "ModuleID");

            migrationBuilder.CreateTable(
                name: "companyModules",
                columns: table => new
                {
                    ModuleId = table.Column<int>(type: "int", nullable: false),
                    CompanyId = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_companyModules", x => new { x.CompanyId, x.ModuleId });
                    table.ForeignKey(
                        name: "FK_companyModules_companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "companies",
                        principalColumn: "CompanyID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_companyModules_modules_ModuleId",
                        column: x => x.ModuleId,
                        principalTable: "modules",
                        principalColumn: "ModuleID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "companySubscriptions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyId = table.Column<int>(type: "int", nullable: false),
                    SubscriptionId = table.Column<int>(type: "int", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_companySubscriptions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_companySubscriptions_companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "companies",
                        principalColumn: "CompanyID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_companySubscriptions_subscriptions_SubscriptionId",
                        column: x => x.SubscriptionId,
                        principalTable: "subscriptions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_companyModules_ModuleId",
                table: "companyModules",
                column: "ModuleId");

            migrationBuilder.CreateIndex(
                name: "IX_companySubscriptions_CompanyId",
                table: "companySubscriptions",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_companySubscriptions_SubscriptionId",
                table: "companySubscriptions",
                column: "SubscriptionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "companyModules");

            migrationBuilder.DropTable(
                name: "companySubscriptions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_subscriptions",
                table: "subscriptions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_modules",
                table: "modules");

            migrationBuilder.DropColumn(
                name: "Duration",
                table: "subscriptions");

            migrationBuilder.DropColumn(
                name: "ClaimList",
                table: "modules");

            migrationBuilder.RenameTable(
                name: "subscriptions",
                newName: "Subscription");

            migrationBuilder.RenameTable(
                name: "modules",
                newName: "Module");

            migrationBuilder.AddColumn<int>(
                name: "CompanyID",
                table: "Subscription",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Module",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "SubscriptionId",
                table: "Module",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Subscription",
                table: "Subscription",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Module",
                table: "Module",
                column: "ModuleID");

            migrationBuilder.CreateTable(
                name: "applicationClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ModuleID = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_applicationClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_applicationClaims_Module_ModuleID",
                        column: x => x.ModuleID,
                        principalTable: "Module",
                        principalColumn: "ModuleID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Subscription_CompanyID",
                table: "Subscription",
                column: "CompanyID");

            migrationBuilder.CreateIndex(
                name: "IX_Module_SubscriptionId",
                table: "Module",
                column: "SubscriptionId");

            migrationBuilder.CreateIndex(
                name: "IX_applicationClaims_ModuleID",
                table: "applicationClaims",
                column: "ModuleID");

            migrationBuilder.AddForeignKey(
                name: "FK_Module_Subscription_SubscriptionId",
                table: "Module",
                column: "SubscriptionId",
                principalTable: "Subscription",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Subscription_companies_CompanyID",
                table: "Subscription",
                column: "CompanyID",
                principalTable: "companies",
                principalColumn: "CompanyID");
        }
    }
}
