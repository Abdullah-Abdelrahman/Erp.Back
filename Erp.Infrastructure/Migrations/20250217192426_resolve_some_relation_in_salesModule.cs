using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Erp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class resolve_some_relation_in_salesModule : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Expenses_Accounts_SubAccountId",
                table: "Expenses");

            migrationBuilder.DropForeignKey(
                name: "FK_Expenses_ExpenseCategories_CategoryId",
                table: "Expenses");

            migrationBuilder.DropForeignKey(
                name: "FK_Receipts_Accounts_SubAccountId",
                table: "Receipts");

            migrationBuilder.RenameColumn(
                name: "CategoryId",
                table: "Expenses",
                newName: "TreasuryId");

            migrationBuilder.RenameIndex(
                name: "IX_Expenses_CategoryId",
                table: "Expenses",
                newName: "IX_Expenses_TreasuryId");

            migrationBuilder.AlterColumn<int>(
                name: "SubAccountId",
                table: "Expenses",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "WithCostCenter",
                table: "Expenses",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "ExpenseId",
                table: "ExpenseCategories",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ExpenseCostCenter",
                columns: table => new
                {
                    ExpenseId = table.Column<int>(type: "int", nullable: false),
                    CostCenterId = table.Column<int>(type: "int", nullable: false),
                    Percentage = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExpenseCostCenter", x => new { x.ExpenseId, x.CostCenterId });
                    table.ForeignKey(
                        name: "FK_ExpenseCostCenter_Expenses_ExpenseId",
                        column: x => x.ExpenseId,
                        principalTable: "Expenses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ExpenseCostCenter_costCenters_CostCenterId",
                        column: x => x.CostCenterId,
                        principalTable: "costCenters",
                        principalColumn: "CostCenterId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MultiAccExpenseItem",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SecondaryAccountId = table.Column<int>(type: "int", nullable: false),
                    CostCenterId = table.Column<int>(type: "int", nullable: true),
                    Tax = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ExpenseId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MultiAccExpenseItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MultiAccExpenseItem_Accounts_SecondaryAccountId",
                        column: x => x.SecondaryAccountId,
                        principalTable: "Accounts",
                        principalColumn: "AccountID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MultiAccExpenseItem_Expenses_ExpenseId",
                        column: x => x.ExpenseId,
                        principalTable: "Expenses",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MultiAccExpenseItem_costCenters_CostCenterId",
                        column: x => x.CostCenterId,
                        principalTable: "costCenters",
                        principalColumn: "CostCenterId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ExpenseCategories_ExpenseId",
                table: "ExpenseCategories",
                column: "ExpenseId");

            migrationBuilder.CreateIndex(
                name: "IX_ExpenseCostCenter_CostCenterId",
                table: "ExpenseCostCenter",
                column: "CostCenterId");

            migrationBuilder.CreateIndex(
                name: "IX_MultiAccExpenseItem_CostCenterId",
                table: "MultiAccExpenseItem",
                column: "CostCenterId");

            migrationBuilder.CreateIndex(
                name: "IX_MultiAccExpenseItem_ExpenseId",
                table: "MultiAccExpenseItem",
                column: "ExpenseId");

            migrationBuilder.CreateIndex(
                name: "IX_MultiAccExpenseItem_SecondaryAccountId",
                table: "MultiAccExpenseItem",
                column: "SecondaryAccountId");

            migrationBuilder.AddForeignKey(
                name: "FK_ExpenseCategories_Expenses_ExpenseId",
                table: "ExpenseCategories",
                column: "ExpenseId",
                principalTable: "Expenses",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Expenses_Accounts_SubAccountId",
                table: "Expenses",
                column: "SubAccountId",
                principalTable: "Accounts",
                principalColumn: "AccountID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Expenses_Treasuries_TreasuryId",
                table: "Expenses",
                column: "TreasuryId",
                principalTable: "Treasuries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Receipts_Accounts_SubAccountId",
                table: "Receipts",
                column: "SubAccountId",
                principalTable: "Accounts",
                principalColumn: "AccountID",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExpenseCategories_Expenses_ExpenseId",
                table: "ExpenseCategories");

            migrationBuilder.DropForeignKey(
                name: "FK_Expenses_Accounts_SubAccountId",
                table: "Expenses");

            migrationBuilder.DropForeignKey(
                name: "FK_Expenses_Treasuries_TreasuryId",
                table: "Expenses");

            migrationBuilder.DropForeignKey(
                name: "FK_Receipts_Accounts_SubAccountId",
                table: "Receipts");

            migrationBuilder.DropTable(
                name: "ExpenseCostCenter");

            migrationBuilder.DropTable(
                name: "MultiAccExpenseItem");

            migrationBuilder.DropIndex(
                name: "IX_ExpenseCategories_ExpenseId",
                table: "ExpenseCategories");

            migrationBuilder.DropColumn(
                name: "WithCostCenter",
                table: "Expenses");

            migrationBuilder.DropColumn(
                name: "ExpenseId",
                table: "ExpenseCategories");

            migrationBuilder.RenameColumn(
                name: "TreasuryId",
                table: "Expenses",
                newName: "CategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_Expenses_TreasuryId",
                table: "Expenses",
                newName: "IX_Expenses_CategoryId");

            migrationBuilder.AlterColumn<int>(
                name: "SubAccountId",
                table: "Expenses",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Expenses_Accounts_SubAccountId",
                table: "Expenses",
                column: "SubAccountId",
                principalTable: "Accounts",
                principalColumn: "AccountID");

            migrationBuilder.AddForeignKey(
                name: "FK_Expenses_ExpenseCategories_CategoryId",
                table: "Expenses",
                column: "CategoryId",
                principalTable: "ExpenseCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Receipts_Accounts_SubAccountId",
                table: "Receipts",
                column: "SubAccountId",
                principalTable: "Accounts",
                principalColumn: "AccountID");
        }
    }
}
