using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Erp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class add_Finance_Model : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "applicationClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ModuleID = table.Column<int>(type: "int", nullable: true)
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

            migrationBuilder.CreateTable(
                name: "BankAccounts",
                columns: table => new
                {
                    BankAccountID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccountHolderName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    BankName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    AccountNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Currency = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    TenantId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DepositPermission = table.Column<int>(type: "int", nullable: false),
                    WithdrawPermission = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BankAccounts", x => x.BankAccountID);
                });

            migrationBuilder.CreateTable(
                name: "ExpenseCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TenantId = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExpenseCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ReceiptCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TenantId = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReceiptCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Treasuries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    TenantId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DepositPermission = table.Column<int>(type: "int", nullable: false),
                    WithdrawPermission = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Treasuries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BankAccountDepositRoles",
                columns: table => new
                {
                    BankAccountDepositPermessionsBankAccountID = table.Column<int>(type: "int", nullable: false),
                    RolesWhoHaveDepositPermessionsId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BankAccountDepositRoles", x => new { x.BankAccountDepositPermessionsBankAccountID, x.RolesWhoHaveDepositPermessionsId });
                    table.ForeignKey(
                        name: "FK_BankAccountDepositRoles_AspNetRoles_RolesWhoHaveDepositPermessionsId",
                        column: x => x.RolesWhoHaveDepositPermessionsId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BankAccountDepositRoles_BankAccounts_BankAccountDepositPermessionsBankAccountID",
                        column: x => x.BankAccountDepositPermessionsBankAccountID,
                        principalTable: "BankAccounts",
                        principalColumn: "BankAccountID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BankAccountWithdrawRoles",
                columns: table => new
                {
                    BankAccountWithdrawPermessionsBankAccountID = table.Column<int>(type: "int", nullable: false),
                    RolesWhoHaveWithdrawPermessionsId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BankAccountWithdrawRoles", x => new { x.BankAccountWithdrawPermessionsBankAccountID, x.RolesWhoHaveWithdrawPermessionsId });
                    table.ForeignKey(
                        name: "FK_BankAccountWithdrawRoles_AspNetRoles_RolesWhoHaveWithdrawPermessionsId",
                        column: x => x.RolesWhoHaveWithdrawPermessionsId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BankAccountWithdrawRoles_BankAccounts_BankAccountWithdrawPermessionsBankAccountID",
                        column: x => x.BankAccountWithdrawPermessionsBankAccountID,
                        principalTable: "BankAccounts",
                        principalColumn: "BankAccountID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Expenses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CodeNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Currency = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    SupplierId = table.Column<int>(type: "int", nullable: true),
                    MainAccountId = table.Column<int>(type: "int", nullable: false),
                    SubAccountId = table.Column<int>(type: "int", nullable: true),
                    IsMultiAccount = table.Column<bool>(type: "bit", nullable: false),
                    Isfrequent = table.Column<bool>(type: "bit", nullable: false),
                    TenantId = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Expenses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Expenses_Accounts_MainAccountId",
                        column: x => x.MainAccountId,
                        principalTable: "Accounts",
                        principalColumn: "AccountID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Expenses_Accounts_SubAccountId",
                        column: x => x.SubAccountId,
                        principalTable: "Accounts",
                        principalColumn: "AccountID");
                    table.ForeignKey(
                        name: "FK_Expenses_ExpenseCategories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "ExpenseCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Expenses_Suppliers_SupplierId",
                        column: x => x.SupplierId,
                        principalTable: "Suppliers",
                        principalColumn: "SupplierId");
                });

            migrationBuilder.CreateTable(
                name: "Receipts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CodeNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Currency = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    MainAccountId = table.Column<int>(type: "int", nullable: false),
                    SubAccountId = table.Column<int>(type: "int", nullable: true),
                    IsMultiAccount = table.Column<bool>(type: "bit", nullable: false),
                    Isfrequent = table.Column<bool>(type: "bit", nullable: false),
                    TenantId = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Receipts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Receipts_Accounts_MainAccountId",
                        column: x => x.MainAccountId,
                        principalTable: "Accounts",
                        principalColumn: "AccountID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Receipts_Accounts_SubAccountId",
                        column: x => x.SubAccountId,
                        principalTable: "Accounts",
                        principalColumn: "AccountID");
                    table.ForeignKey(
                        name: "FK_Receipts_ReceiptCategories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "ReceiptCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TreasuryRoleDeposit",
                columns: table => new
                {
                    RolesWhoHaveDepositPermessionsId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TreasuryDepositPermessionsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TreasuryRoleDeposit", x => new { x.RolesWhoHaveDepositPermessionsId, x.TreasuryDepositPermessionsId });
                    table.ForeignKey(
                        name: "FK_TreasuryRoleDeposit_AspNetRoles_RolesWhoHaveDepositPermessionsId",
                        column: x => x.RolesWhoHaveDepositPermessionsId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TreasuryRoleDeposit_Treasuries_TreasuryDepositPermessionsId",
                        column: x => x.TreasuryDepositPermessionsId,
                        principalTable: "Treasuries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TreasuryRoleWithdraw",
                columns: table => new
                {
                    RolesWhoHaveWithdrawPermessionsId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TreasuryWithdrawPermessionsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TreasuryRoleWithdraw", x => new { x.RolesWhoHaveWithdrawPermessionsId, x.TreasuryWithdrawPermessionsId });
                    table.ForeignKey(
                        name: "FK_TreasuryRoleWithdraw_AspNetRoles_RolesWhoHaveWithdrawPermessionsId",
                        column: x => x.RolesWhoHaveWithdrawPermessionsId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TreasuryRoleWithdraw_Treasuries_TreasuryWithdrawPermessionsId",
                        column: x => x.TreasuryWithdrawPermessionsId,
                        principalTable: "Treasuries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BankAccountEmployeeDeposit",
                columns: table => new
                {
                    BankAccountDepositPermessionsBankAccountID = table.Column<int>(type: "int", nullable: false),
                    employeesWhoHaveDepositPermessionsEmployeeID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BankAccountEmployeeDeposit", x => new { x.BankAccountDepositPermessionsBankAccountID, x.employeesWhoHaveDepositPermessionsEmployeeID });
                    table.ForeignKey(
                        name: "FK_BankAccountEmployeeDeposit_BankAccounts_BankAccountDepositPermessionsBankAccountID",
                        column: x => x.BankAccountDepositPermessionsBankAccountID,
                        principalTable: "BankAccounts",
                        principalColumn: "BankAccountID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BankAccountEmployeeWithdraw",
                columns: table => new
                {
                    BankAccountWithdrawPermessionsBankAccountID = table.Column<int>(type: "int", nullable: false),
                    employeesWhoHaveWithdrawPermessionsEmployeeID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BankAccountEmployeeWithdraw", x => new { x.BankAccountWithdrawPermessionsBankAccountID, x.employeesWhoHaveWithdrawPermessionsEmployeeID });
                    table.ForeignKey(
                        name: "FK_BankAccountEmployeeWithdraw_BankAccounts_BankAccountWithdrawPermessionsBankAccountID",
                        column: x => x.BankAccountWithdrawPermessionsBankAccountID,
                        principalTable: "BankAccounts",
                        principalColumn: "BankAccountID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Department",
                columns: table => new
                {
                    DepartmentID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DepartmentName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    AbbreviationName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    DepartmentHeadID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Department", x => x.DepartmentID);
                });

            migrationBuilder.CreateTable(
                name: "JobType",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    DepartmentId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobType", x => x.ID);
                    table.ForeignKey(
                        name: "FK_JobType_Department_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Department",
                        principalColumn: "DepartmentID");
                });

            migrationBuilder.CreateTable(
                name: "Employee",
                columns: table => new
                {
                    EmployeeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyID = table.Column<int>(type: "int", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Gender = table.Column<int>(type: "int", nullable: true),
                    JobTitle = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DepartmentID = table.Column<int>(type: "int", nullable: true),
                    HireDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    JobTypeID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee", x => x.EmployeeID);
                    table.ForeignKey(
                        name: "FK_Employee_Department_DepartmentID",
                        column: x => x.DepartmentID,
                        principalTable: "Department",
                        principalColumn: "DepartmentID");
                    table.ForeignKey(
                        name: "FK_Employee_JobType_JobTypeID",
                        column: x => x.JobTypeID,
                        principalTable: "JobType",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Employee_companies_CompanyID",
                        column: x => x.CompanyID,
                        principalTable: "companies",
                        principalColumn: "CompanyID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TreasuryEmployeeDeposit",
                columns: table => new
                {
                    TreasuryDepositPermessionsId = table.Column<int>(type: "int", nullable: false),
                    employeesWhoHaveDepositPermessionsEmployeeID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TreasuryEmployeeDeposit", x => new { x.TreasuryDepositPermessionsId, x.employeesWhoHaveDepositPermessionsEmployeeID });
                    table.ForeignKey(
                        name: "FK_TreasuryEmployeeDeposit_Employee_employeesWhoHaveDepositPermessionsEmployeeID",
                        column: x => x.employeesWhoHaveDepositPermessionsEmployeeID,
                        principalTable: "Employee",
                        principalColumn: "EmployeeID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TreasuryEmployeeDeposit_Treasuries_TreasuryDepositPermessionsId",
                        column: x => x.TreasuryDepositPermessionsId,
                        principalTable: "Treasuries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TreasuryEmployeeWithdraw",
                columns: table => new
                {
                    TreasuryWithdrawPermessionsId = table.Column<int>(type: "int", nullable: false),
                    employeesWhoHaveWithdrawPermessionsEmployeeID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TreasuryEmployeeWithdraw", x => new { x.TreasuryWithdrawPermessionsId, x.employeesWhoHaveWithdrawPermessionsEmployeeID });
                    table.ForeignKey(
                        name: "FK_TreasuryEmployeeWithdraw_Employee_employeesWhoHaveWithdrawPermessionsEmployeeID",
                        column: x => x.employeesWhoHaveWithdrawPermessionsEmployeeID,
                        principalTable: "Employee",
                        principalColumn: "EmployeeID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TreasuryEmployeeWithdraw_Treasuries_TreasuryWithdrawPermessionsId",
                        column: x => x.TreasuryWithdrawPermessionsId,
                        principalTable: "Treasuries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_applicationClaims_ModuleID",
                table: "applicationClaims",
                column: "ModuleID");

            migrationBuilder.CreateIndex(
                name: "IX_BankAccountDepositRoles_RolesWhoHaveDepositPermessionsId",
                table: "BankAccountDepositRoles",
                column: "RolesWhoHaveDepositPermessionsId");

            migrationBuilder.CreateIndex(
                name: "IX_BankAccountEmployeeDeposit_employeesWhoHaveDepositPermessionsEmployeeID",
                table: "BankAccountEmployeeDeposit",
                column: "employeesWhoHaveDepositPermessionsEmployeeID");

            migrationBuilder.CreateIndex(
                name: "IX_BankAccountEmployeeWithdraw_employeesWhoHaveWithdrawPermessionsEmployeeID",
                table: "BankAccountEmployeeWithdraw",
                column: "employeesWhoHaveWithdrawPermessionsEmployeeID");

            migrationBuilder.CreateIndex(
                name: "IX_BankAccountWithdrawRoles_RolesWhoHaveWithdrawPermessionsId",
                table: "BankAccountWithdrawRoles",
                column: "RolesWhoHaveWithdrawPermessionsId");

            migrationBuilder.CreateIndex(
                name: "IX_Department_DepartmentHeadID",
                table: "Department",
                column: "DepartmentHeadID");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_CompanyID",
                table: "Employee",
                column: "CompanyID");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_DepartmentID",
                table: "Employee",
                column: "DepartmentID");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_JobTypeID",
                table: "Employee",
                column: "JobTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_Expenses_CategoryId",
                table: "Expenses",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Expenses_MainAccountId",
                table: "Expenses",
                column: "MainAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_Expenses_SubAccountId",
                table: "Expenses",
                column: "SubAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_Expenses_SupplierId",
                table: "Expenses",
                column: "SupplierId");

            migrationBuilder.CreateIndex(
                name: "IX_JobType_DepartmentId",
                table: "JobType",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Receipts_CategoryId",
                table: "Receipts",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Receipts_MainAccountId",
                table: "Receipts",
                column: "MainAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_Receipts_SubAccountId",
                table: "Receipts",
                column: "SubAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_TreasuryEmployeeDeposit_employeesWhoHaveDepositPermessionsEmployeeID",
                table: "TreasuryEmployeeDeposit",
                column: "employeesWhoHaveDepositPermessionsEmployeeID");

            migrationBuilder.CreateIndex(
                name: "IX_TreasuryEmployeeWithdraw_employeesWhoHaveWithdrawPermessionsEmployeeID",
                table: "TreasuryEmployeeWithdraw",
                column: "employeesWhoHaveWithdrawPermessionsEmployeeID");

            migrationBuilder.CreateIndex(
                name: "IX_TreasuryRoleDeposit_TreasuryDepositPermessionsId",
                table: "TreasuryRoleDeposit",
                column: "TreasuryDepositPermessionsId");

            migrationBuilder.CreateIndex(
                name: "IX_TreasuryRoleWithdraw_TreasuryWithdrawPermessionsId",
                table: "TreasuryRoleWithdraw",
                column: "TreasuryWithdrawPermessionsId");

            migrationBuilder.AddForeignKey(
                name: "FK_BankAccountEmployeeDeposit_Employee_employeesWhoHaveDepositPermessionsEmployeeID",
                table: "BankAccountEmployeeDeposit",
                column: "employeesWhoHaveDepositPermessionsEmployeeID",
                principalTable: "Employee",
                principalColumn: "EmployeeID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BankAccountEmployeeWithdraw_Employee_employeesWhoHaveWithdrawPermessionsEmployeeID",
                table: "BankAccountEmployeeWithdraw",
                column: "employeesWhoHaveWithdrawPermessionsEmployeeID",
                principalTable: "Employee",
                principalColumn: "EmployeeID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Department_Employee_DepartmentHeadID",
                table: "Department",
                column: "DepartmentHeadID",
                principalTable: "Employee",
                principalColumn: "EmployeeID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Department_Employee_DepartmentHeadID",
                table: "Department");

            migrationBuilder.DropTable(
                name: "applicationClaims");

            migrationBuilder.DropTable(
                name: "BankAccountDepositRoles");

            migrationBuilder.DropTable(
                name: "BankAccountEmployeeDeposit");

            migrationBuilder.DropTable(
                name: "BankAccountEmployeeWithdraw");

            migrationBuilder.DropTable(
                name: "BankAccountWithdrawRoles");

            migrationBuilder.DropTable(
                name: "Expenses");

            migrationBuilder.DropTable(
                name: "Receipts");

            migrationBuilder.DropTable(
                name: "TreasuryEmployeeDeposit");

            migrationBuilder.DropTable(
                name: "TreasuryEmployeeWithdraw");

            migrationBuilder.DropTable(
                name: "TreasuryRoleDeposit");

            migrationBuilder.DropTable(
                name: "TreasuryRoleWithdraw");

            migrationBuilder.DropTable(
                name: "BankAccounts");

            migrationBuilder.DropTable(
                name: "ExpenseCategories");

            migrationBuilder.DropTable(
                name: "ReceiptCategories");

            migrationBuilder.DropTable(
                name: "Treasuries");

            migrationBuilder.DropTable(
                name: "Employee");

            migrationBuilder.DropTable(
                name: "JobType");

            migrationBuilder.DropTable(
                name: "Department");
        }
    }
}
