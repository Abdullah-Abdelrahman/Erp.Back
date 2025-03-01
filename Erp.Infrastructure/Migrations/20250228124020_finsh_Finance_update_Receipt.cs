using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Erp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class finsh_Finance_update_Receipt : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Receipts_ReceiptCategories_CategoryId",
                table: "Receipts");

            migrationBuilder.RenameColumn(
                name: "CategoryId",
                table: "Receipts",
                newName: "TreasuryId");

            migrationBuilder.RenameIndex(
                name: "IX_Receipts_CategoryId",
                table: "Receipts",
                newName: "IX_Receipts_TreasuryId");

            migrationBuilder.AlterColumn<int>(
                name: "SubAccountId",
                table: "Receipts",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Currency",
                table: "Receipts",
                type: "nvarchar(3)",
                maxLength: 3,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10);

            migrationBuilder.AddColumn<bool>(
                name: "WithCostCenter",
                table: "Receipts",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<string>(
                name: "Currency",
                table: "Expenses",
                type: "nvarchar(3)",
                maxLength: 3,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10);

            migrationBuilder.CreateTable(
                name: "multiAccReceiptItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    receiptId = table.Column<int>(type: "int", nullable: false),
                    SecondaryAccountId = table.Column<int>(type: "int", nullable: false),
                    CostCenterId = table.Column<int>(type: "int", nullable: true),
                    Tax = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TenantId = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_multiAccReceiptItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_multiAccReceiptItems_Accounts_SecondaryAccountId",
                        column: x => x.SecondaryAccountId,
                        principalTable: "Accounts",
                        principalColumn: "AccountID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_multiAccReceiptItems_Receipts_receiptId",
                        column: x => x.receiptId,
                        principalTable: "Receipts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_multiAccReceiptItems_costCenters_CostCenterId",
                        column: x => x.CostCenterId,
                        principalTable: "costCenters",
                        principalColumn: "CostCenterId");
                });

            migrationBuilder.CreateTable(
                name: "ReceiptCostCenter",
                columns: table => new
                {
                    ReceiptId = table.Column<int>(type: "int", nullable: false),
                    CostCenterId = table.Column<int>(type: "int", nullable: false),
                    Percentage = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReceiptCostCenter", x => new { x.ReceiptId, x.CostCenterId });
                    table.ForeignKey(
                        name: "FK_ReceiptCostCenter_Receipts_ReceiptId",
                        column: x => x.ReceiptId,
                        principalTable: "Receipts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ReceiptCostCenter_costCenters_CostCenterId",
                        column: x => x.CostCenterId,
                        principalTable: "costCenters",
                        principalColumn: "CostCenterId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_multiAccReceiptItems_CostCenterId",
                table: "multiAccReceiptItems",
                column: "CostCenterId");

            migrationBuilder.CreateIndex(
                name: "IX_multiAccReceiptItems_receiptId",
                table: "multiAccReceiptItems",
                column: "receiptId");

            migrationBuilder.CreateIndex(
                name: "IX_multiAccReceiptItems_SecondaryAccountId",
                table: "multiAccReceiptItems",
                column: "SecondaryAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_ReceiptCostCenter_CostCenterId",
                table: "ReceiptCostCenter",
                column: "CostCenterId");

            migrationBuilder.AddForeignKey(
                name: "FK_Receipts_Treasuries_TreasuryId",
                table: "Receipts",
                column: "TreasuryId",
                principalTable: "Treasuries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Receipts_Treasuries_TreasuryId",
                table: "Receipts");

            migrationBuilder.DropTable(
                name: "multiAccReceiptItems");

            migrationBuilder.DropTable(
                name: "ReceiptCostCenter");

            migrationBuilder.DropColumn(
                name: "WithCostCenter",
                table: "Receipts");

            migrationBuilder.RenameColumn(
                name: "TreasuryId",
                table: "Receipts",
                newName: "CategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_Receipts_TreasuryId",
                table: "Receipts",
                newName: "IX_Receipts_CategoryId");

            migrationBuilder.AlterColumn<int>(
                name: "SubAccountId",
                table: "Receipts",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Currency",
                table: "Receipts",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(3)",
                oldMaxLength: 3);

            migrationBuilder.AlterColumn<string>(
                name: "Currency",
                table: "Expenses",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(3)",
                oldMaxLength: 3);

            migrationBuilder.AddForeignKey(
                name: "FK_Receipts_ReceiptCategories_CategoryId",
                table: "Receipts",
                column: "CategoryId",
                principalTable: "ReceiptCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
