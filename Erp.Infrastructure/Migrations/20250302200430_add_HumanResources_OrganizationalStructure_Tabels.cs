using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Erp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class add_HumanResources_OrganizationalStructure_Tabels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Department_Employee_DepartmentHeadID",
                table: "Department");

            migrationBuilder.DropForeignKey(
                name: "FK_Employee_Department_DepartmentID",
                table: "Employee");

            migrationBuilder.DropForeignKey(
                name: "FK_Employee_JobType_JobTypeID",
                table: "Employee");

            migrationBuilder.DropForeignKey(
                name: "FK_JobType_Department_DepartmentId",
                table: "JobType");

            migrationBuilder.DropPrimaryKey(
                name: "PK_JobType",
                table: "JobType");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Department",
                table: "Department");

            migrationBuilder.DropColumn(
                name: "JobTitle",
                table: "Employee");

            migrationBuilder.RenameTable(
                name: "JobType",
                newName: "jobTypes");

            migrationBuilder.RenameTable(
                name: "Department",
                newName: "departments");

            migrationBuilder.RenameIndex(
                name: "IX_JobType_DepartmentId",
                table: "jobTypes",
                newName: "IX_jobTypes_DepartmentId");

            migrationBuilder.RenameIndex(
                name: "IX_Department_DepartmentHeadID",
                table: "departments",
                newName: "IX_departments_DepartmentHeadID");

            migrationBuilder.AlterColumn<string>(
                name: "PrivateEmail",
                table: "Employee",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "Employee",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateOfBirth",
                table: "Employee",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Country",
                table: "Employee",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Address2",
                table: "Employee",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Address1",
                table: "Employee",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "DirectManagerId",
                table: "Employee",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Employee",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "EmploymentLevelId",
                table: "Employee",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EmploymentTypeId",
                table: "Employee",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RoleID",
                table: "Employee",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "UseDefaultFinancialHistory",
                table: "Employee",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddPrimaryKey(
                name: "PK_jobTypes",
                table: "jobTypes",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_departments",
                table: "departments",
                column: "DepartmentID");

            migrationBuilder.CreateTable(
                name: "employmentLevels",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_employmentLevels", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "employmentTypes",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_employmentTypes", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Employee_DirectManagerId",
                table: "Employee",
                column: "DirectManagerId");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_EmploymentLevelId",
                table: "Employee",
                column: "EmploymentLevelId");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_EmploymentTypeId",
                table: "Employee",
                column: "EmploymentTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_RoleID",
                table: "Employee",
                column: "RoleID");

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
                name: "FK_jobTypes_departments_DepartmentId",
                table: "jobTypes",
                column: "DepartmentId",
                principalTable: "departments",
                principalColumn: "DepartmentID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
                name: "FK_jobTypes_departments_DepartmentId",
                table: "jobTypes");

            migrationBuilder.DropTable(
                name: "employmentLevels");

            migrationBuilder.DropTable(
                name: "employmentTypes");

            migrationBuilder.DropIndex(
                name: "IX_Employee_DirectManagerId",
                table: "Employee");

            migrationBuilder.DropIndex(
                name: "IX_Employee_EmploymentLevelId",
                table: "Employee");

            migrationBuilder.DropIndex(
                name: "IX_Employee_EmploymentTypeId",
                table: "Employee");

            migrationBuilder.DropIndex(
                name: "IX_Employee_RoleID",
                table: "Employee");

            migrationBuilder.DropPrimaryKey(
                name: "PK_jobTypes",
                table: "jobTypes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_departments",
                table: "departments");

            migrationBuilder.DropColumn(
                name: "DirectManagerId",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "EmploymentLevelId",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "EmploymentTypeId",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "RoleID",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "UseDefaultFinancialHistory",
                table: "Employee");

            migrationBuilder.RenameTable(
                name: "jobTypes",
                newName: "JobType");

            migrationBuilder.RenameTable(
                name: "departments",
                newName: "Department");

            migrationBuilder.RenameIndex(
                name: "IX_jobTypes_DepartmentId",
                table: "JobType",
                newName: "IX_JobType_DepartmentId");

            migrationBuilder.RenameIndex(
                name: "IX_departments_DepartmentHeadID",
                table: "Department",
                newName: "IX_Department_DepartmentHeadID");

            migrationBuilder.AlterColumn<string>(
                name: "PrivateEmail",
                table: "Employee",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "Employee",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20,
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateOfBirth",
                table: "Employee",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<string>(
                name: "Country",
                table: "Employee",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Address2",
                table: "Employee",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Address1",
                table: "Employee",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "JobTitle",
                table: "Employee",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_JobType",
                table: "JobType",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Department",
                table: "Department",
                column: "DepartmentID");

            migrationBuilder.AddForeignKey(
                name: "FK_Department_Employee_DepartmentHeadID",
                table: "Department",
                column: "DepartmentHeadID",
                principalTable: "Employee",
                principalColumn: "EmployeeID");

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_Department_DepartmentID",
                table: "Employee",
                column: "DepartmentID",
                principalTable: "Department",
                principalColumn: "DepartmentID");

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_JobType_JobTypeID",
                table: "Employee",
                column: "JobTypeID",
                principalTable: "JobType",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_JobType_Department_DepartmentId",
                table: "JobType",
                column: "DepartmentId",
                principalTable: "Department",
                principalColumn: "DepartmentID");
        }
    }
}
