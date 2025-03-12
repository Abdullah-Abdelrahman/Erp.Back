using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Erp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class add_Employee_table : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BankAccountEmployeeDeposit_Employee_employeesWhoHaveDepositPermessionsEmployeeID",
                table: "BankAccountEmployeeDeposit");

            migrationBuilder.DropForeignKey(
                name: "FK_BankAccountEmployeeWithdraw_Employee_employeesWhoHaveWithdrawPermessionsEmployeeID",
                table: "BankAccountEmployeeWithdraw");

            migrationBuilder.DropForeignKey(
                name: "FK_departments_Employee_DepartmentHeadID",
                table: "departments");

            migrationBuilder.DropForeignKey(
                name: "FK_Employee_AspNetRoles_RoleID",
                table: "Employee");

            migrationBuilder.DropForeignKey(
                name: "FK_Employee_Employee_DirectManagerId",
                table: "Employee");

            migrationBuilder.DropForeignKey(
                name: "FK_Employee_companies_CompanyID",
                table: "Employee");

            migrationBuilder.DropForeignKey(
                name: "FK_Employee_departments_DepartmentID",
                table: "Employee");

            migrationBuilder.DropForeignKey(
                name: "FK_Employee_employmentLevels_EmploymentLevelId",
                table: "Employee");

            migrationBuilder.DropForeignKey(
                name: "FK_Employee_employmentTypes_EmploymentTypeId",
                table: "Employee");

            migrationBuilder.DropForeignKey(
                name: "FK_Employee_jobTypes_JobTypeID",
                table: "Employee");

            migrationBuilder.DropForeignKey(
                name: "FK_TreasuryEmployeeDeposit_Employee_employeesWhoHaveDepositPermessionsEmployeeID",
                table: "TreasuryEmployeeDeposit");

            migrationBuilder.DropForeignKey(
                name: "FK_TreasuryEmployeeWithdraw_Employee_employeesWhoHaveWithdrawPermessionsEmployeeID",
                table: "TreasuryEmployeeWithdraw");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Employee",
                table: "Employee");

            migrationBuilder.RenameTable(
                name: "Employee",
                newName: "Employees");

            migrationBuilder.RenameIndex(
                name: "IX_Employee_RoleID",
                table: "Employees",
                newName: "IX_Employees_RoleID");

            migrationBuilder.RenameIndex(
                name: "IX_Employee_JobTypeID",
                table: "Employees",
                newName: "IX_Employees_JobTypeID");

            migrationBuilder.RenameIndex(
                name: "IX_Employee_EmploymentTypeId",
                table: "Employees",
                newName: "IX_Employees_EmploymentTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_Employee_EmploymentLevelId",
                table: "Employees",
                newName: "IX_Employees_EmploymentLevelId");

            migrationBuilder.RenameIndex(
                name: "IX_Employee_DirectManagerId",
                table: "Employees",
                newName: "IX_Employees_DirectManagerId");

            migrationBuilder.RenameIndex(
                name: "IX_Employee_DepartmentID",
                table: "Employees",
                newName: "IX_Employees_DepartmentID");

            migrationBuilder.RenameIndex(
                name: "IX_Employee_CompanyID",
                table: "Employees",
                newName: "IX_Employees_CompanyID");

            migrationBuilder.AlterColumn<string>(
                name: "RoleID",
                table: "Employees",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Employees",
                table: "Employees",
                column: "EmployeeID");

            migrationBuilder.AddForeignKey(
                name: "FK_BankAccountEmployeeDeposit_Employees_employeesWhoHaveDepositPermessionsEmployeeID",
                table: "BankAccountEmployeeDeposit",
                column: "employeesWhoHaveDepositPermessionsEmployeeID",
                principalTable: "Employees",
                principalColumn: "EmployeeID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BankAccountEmployeeWithdraw_Employees_employeesWhoHaveWithdrawPermessionsEmployeeID",
                table: "BankAccountEmployeeWithdraw",
                column: "employeesWhoHaveWithdrawPermessionsEmployeeID",
                principalTable: "Employees",
                principalColumn: "EmployeeID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_departments_Employees_DepartmentHeadID",
                table: "departments",
                column: "DepartmentHeadID",
                principalTable: "Employees",
                principalColumn: "EmployeeID");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_AspNetRoles_RoleID",
                table: "Employees",
                column: "RoleID",
                principalTable: "AspNetRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Employees_DirectManagerId",
                table: "Employees",
                column: "DirectManagerId",
                principalTable: "Employees",
                principalColumn: "EmployeeID");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_companies_CompanyID",
                table: "Employees",
                column: "CompanyID",
                principalTable: "companies",
                principalColumn: "CompanyID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_departments_DepartmentID",
                table: "Employees",
                column: "DepartmentID",
                principalTable: "departments",
                principalColumn: "DepartmentID");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_employmentLevels_EmploymentLevelId",
                table: "Employees",
                column: "EmploymentLevelId",
                principalTable: "employmentLevels",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_employmentTypes_EmploymentTypeId",
                table: "Employees",
                column: "EmploymentTypeId",
                principalTable: "employmentTypes",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_jobTypes_JobTypeID",
                table: "Employees",
                column: "JobTypeID",
                principalTable: "jobTypes",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_TreasuryEmployeeDeposit_Employees_employeesWhoHaveDepositPermessionsEmployeeID",
                table: "TreasuryEmployeeDeposit",
                column: "employeesWhoHaveDepositPermessionsEmployeeID",
                principalTable: "Employees",
                principalColumn: "EmployeeID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TreasuryEmployeeWithdraw_Employees_employeesWhoHaveWithdrawPermessionsEmployeeID",
                table: "TreasuryEmployeeWithdraw",
                column: "employeesWhoHaveWithdrawPermessionsEmployeeID",
                principalTable: "Employees",
                principalColumn: "EmployeeID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BankAccountEmployeeDeposit_Employees_employeesWhoHaveDepositPermessionsEmployeeID",
                table: "BankAccountEmployeeDeposit");

            migrationBuilder.DropForeignKey(
                name: "FK_BankAccountEmployeeWithdraw_Employees_employeesWhoHaveWithdrawPermessionsEmployeeID",
                table: "BankAccountEmployeeWithdraw");

            migrationBuilder.DropForeignKey(
                name: "FK_departments_Employees_DepartmentHeadID",
                table: "departments");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_AspNetRoles_RoleID",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Employees_DirectManagerId",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_companies_CompanyID",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_departments_DepartmentID",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_employmentLevels_EmploymentLevelId",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_employmentTypes_EmploymentTypeId",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_jobTypes_JobTypeID",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_TreasuryEmployeeDeposit_Employees_employeesWhoHaveDepositPermessionsEmployeeID",
                table: "TreasuryEmployeeDeposit");

            migrationBuilder.DropForeignKey(
                name: "FK_TreasuryEmployeeWithdraw_Employees_employeesWhoHaveWithdrawPermessionsEmployeeID",
                table: "TreasuryEmployeeWithdraw");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Employees",
                table: "Employees");

            migrationBuilder.RenameTable(
                name: "Employees",
                newName: "Employee");

            migrationBuilder.RenameIndex(
                name: "IX_Employees_RoleID",
                table: "Employee",
                newName: "IX_Employee_RoleID");

            migrationBuilder.RenameIndex(
                name: "IX_Employees_JobTypeID",
                table: "Employee",
                newName: "IX_Employee_JobTypeID");

            migrationBuilder.RenameIndex(
                name: "IX_Employees_EmploymentTypeId",
                table: "Employee",
                newName: "IX_Employee_EmploymentTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_Employees_EmploymentLevelId",
                table: "Employee",
                newName: "IX_Employee_EmploymentLevelId");

            migrationBuilder.RenameIndex(
                name: "IX_Employees_DirectManagerId",
                table: "Employee",
                newName: "IX_Employee_DirectManagerId");

            migrationBuilder.RenameIndex(
                name: "IX_Employees_DepartmentID",
                table: "Employee",
                newName: "IX_Employee_DepartmentID");

            migrationBuilder.RenameIndex(
                name: "IX_Employees_CompanyID",
                table: "Employee",
                newName: "IX_Employee_CompanyID");

            migrationBuilder.AlterColumn<string>(
                name: "RoleID",
                table: "Employee",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Employee",
                table: "Employee",
                column: "EmployeeID");

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
                name: "FK_departments_Employee_DepartmentHeadID",
                table: "departments",
                column: "DepartmentHeadID",
                principalTable: "Employee",
                principalColumn: "EmployeeID");

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_AspNetRoles_RoleID",
                table: "Employee",
                column: "RoleID",
                principalTable: "AspNetRoles",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_Employee_DirectManagerId",
                table: "Employee",
                column: "DirectManagerId",
                principalTable: "Employee",
                principalColumn: "EmployeeID");

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_companies_CompanyID",
                table: "Employee",
                column: "CompanyID",
                principalTable: "companies",
                principalColumn: "CompanyID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_departments_DepartmentID",
                table: "Employee",
                column: "DepartmentID",
                principalTable: "departments",
                principalColumn: "DepartmentID");

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_employmentLevels_EmploymentLevelId",
                table: "Employee",
                column: "EmploymentLevelId",
                principalTable: "employmentLevels",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_employmentTypes_EmploymentTypeId",
                table: "Employee",
                column: "EmploymentTypeId",
                principalTable: "employmentTypes",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_jobTypes_JobTypeID",
                table: "Employee",
                column: "JobTypeID",
                principalTable: "jobTypes",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_TreasuryEmployeeDeposit_Employee_employeesWhoHaveDepositPermessionsEmployeeID",
                table: "TreasuryEmployeeDeposit",
                column: "employeesWhoHaveDepositPermessionsEmployeeID",
                principalTable: "Employee",
                principalColumn: "EmployeeID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TreasuryEmployeeWithdraw_Employee_employeesWhoHaveWithdrawPermessionsEmployeeID",
                table: "TreasuryEmployeeWithdraw",
                column: "employeesWhoHaveWithdrawPermessionsEmployeeID",
                principalTable: "Employee",
                principalColumn: "EmployeeID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
