using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Erp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class add_ExpenseId_to_MultiAccExpenseItem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MultiAccExpenseItem_Accounts_SecondaryAccountId",
                table: "MultiAccExpenseItem");

            migrationBuilder.DropForeignKey(
                name: "FK_MultiAccExpenseItem_Expenses_ExpenseId",
                table: "MultiAccExpenseItem");

            migrationBuilder.DropForeignKey(
                name: "FK_MultiAccExpenseItem_costCenters_CostCenterId",
                table: "MultiAccExpenseItem");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MultiAccExpenseItem",
                table: "MultiAccExpenseItem");

            migrationBuilder.RenameTable(
                name: "MultiAccExpenseItem",
                newName: "multiAccExpenseItems");

            migrationBuilder.RenameIndex(
                name: "IX_MultiAccExpenseItem_SecondaryAccountId",
                table: "multiAccExpenseItems",
                newName: "IX_multiAccExpenseItems_SecondaryAccountId");

            migrationBuilder.RenameIndex(
                name: "IX_MultiAccExpenseItem_ExpenseId",
                table: "multiAccExpenseItems",
                newName: "IX_multiAccExpenseItems_ExpenseId");

            migrationBuilder.RenameIndex(
                name: "IX_MultiAccExpenseItem_CostCenterId",
                table: "multiAccExpenseItems",
                newName: "IX_multiAccExpenseItems_CostCenterId");

            migrationBuilder.AlterColumn<int>(
                name: "ExpenseId",
                table: "multiAccExpenseItems",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TenantId",
                table: "multiAccExpenseItems",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_multiAccExpenseItems",
                table: "multiAccExpenseItems",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_multiAccExpenseItems_Accounts_SecondaryAccountId",
                table: "multiAccExpenseItems",
                column: "SecondaryAccountId",
                principalTable: "Accounts",
                principalColumn: "AccountID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_multiAccExpenseItems_Expenses_ExpenseId",
                table: "multiAccExpenseItems",
                column: "ExpenseId",
                principalTable: "Expenses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_multiAccExpenseItems_costCenters_CostCenterId",
                table: "multiAccExpenseItems",
                column: "CostCenterId",
                principalTable: "costCenters",
                principalColumn: "CostCenterId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_multiAccExpenseItems_Accounts_SecondaryAccountId",
                table: "multiAccExpenseItems");

            migrationBuilder.DropForeignKey(
                name: "FK_multiAccExpenseItems_Expenses_ExpenseId",
                table: "multiAccExpenseItems");

            migrationBuilder.DropForeignKey(
                name: "FK_multiAccExpenseItems_costCenters_CostCenterId",
                table: "multiAccExpenseItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_multiAccExpenseItems",
                table: "multiAccExpenseItems");

            migrationBuilder.DropColumn(
                name: "TenantId",
                table: "multiAccExpenseItems");

            migrationBuilder.RenameTable(
                name: "multiAccExpenseItems",
                newName: "MultiAccExpenseItem");

            migrationBuilder.RenameIndex(
                name: "IX_multiAccExpenseItems_SecondaryAccountId",
                table: "MultiAccExpenseItem",
                newName: "IX_MultiAccExpenseItem_SecondaryAccountId");

            migrationBuilder.RenameIndex(
                name: "IX_multiAccExpenseItems_ExpenseId",
                table: "MultiAccExpenseItem",
                newName: "IX_MultiAccExpenseItem_ExpenseId");

            migrationBuilder.RenameIndex(
                name: "IX_multiAccExpenseItems_CostCenterId",
                table: "MultiAccExpenseItem",
                newName: "IX_MultiAccExpenseItem_CostCenterId");

            migrationBuilder.AlterColumn<int>(
                name: "ExpenseId",
                table: "MultiAccExpenseItem",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MultiAccExpenseItem",
                table: "MultiAccExpenseItem",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MultiAccExpenseItem_Accounts_SecondaryAccountId",
                table: "MultiAccExpenseItem",
                column: "SecondaryAccountId",
                principalTable: "Accounts",
                principalColumn: "AccountID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MultiAccExpenseItem_Expenses_ExpenseId",
                table: "MultiAccExpenseItem",
                column: "ExpenseId",
                principalTable: "Expenses",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MultiAccExpenseItem_costCenters_CostCenterId",
                table: "MultiAccExpenseItem",
                column: "CostCenterId",
                principalTable: "costCenters",
                principalColumn: "CostCenterId");
        }
    }
}
