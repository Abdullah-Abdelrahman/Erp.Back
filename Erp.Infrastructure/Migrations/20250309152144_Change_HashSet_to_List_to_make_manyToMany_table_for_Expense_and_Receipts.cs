using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Erp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Change_HashSet_to_List_to_make_manyToMany_table_for_Expense_and_Receipts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExpenseCategories_Expenses_ExpenseId",
                table: "ExpenseCategories");

            migrationBuilder.DropIndex(
                name: "IX_ExpenseCategories_ExpenseId",
                table: "ExpenseCategories");

            migrationBuilder.DropColumn(
                name: "ExpenseId",
                table: "ExpenseCategories");

            migrationBuilder.CreateTable(
                name: "ExpenseExpenseCategory",
                columns: table => new
                {
                    ExpensesId = table.Column<int>(type: "int", nullable: false),
                    expenseCategoriesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExpenseExpenseCategory", x => new { x.ExpensesId, x.expenseCategoriesId });
                    table.ForeignKey(
                        name: "FK_ExpenseExpenseCategory_ExpenseCategories_expenseCategoriesId",
                        column: x => x.expenseCategoriesId,
                        principalTable: "ExpenseCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ExpenseExpenseCategory_Expenses_ExpensesId",
                        column: x => x.ExpensesId,
                        principalTable: "Expenses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ExpenseExpenseCategory_expenseCategoriesId",
                table: "ExpenseExpenseCategory",
                column: "expenseCategoriesId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ExpenseExpenseCategory");

            migrationBuilder.AddColumn<int>(
                name: "ExpenseId",
                table: "ExpenseCategories",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ExpenseCategories_ExpenseId",
                table: "ExpenseCategories",
                column: "ExpenseId");

            migrationBuilder.AddForeignKey(
                name: "FK_ExpenseCategories_Expenses_ExpenseId",
                table: "ExpenseCategories",
                column: "ExpenseId",
                principalTable: "Expenses",
                principalColumn: "Id");
        }
    }
}
