using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Erp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Add_paymentStatusId_To_All_PurchasesInvoices : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "paymentStatusId",
                table: "PurchaseReturns",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "paymentStatusId",
                table: "PurchaseInvoices",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "paymentStatusId",
                table: "DebitNotes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "paymentStatuses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_paymentStatuses", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseReturns_paymentStatusId",
                table: "PurchaseReturns",
                column: "paymentStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseInvoices_paymentStatusId",
                table: "PurchaseInvoices",
                column: "paymentStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_DebitNotes_paymentStatusId",
                table: "DebitNotes",
                column: "paymentStatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_DebitNotes_paymentStatuses_paymentStatusId",
                table: "DebitNotes",
                column: "paymentStatusId",
                principalTable: "paymentStatuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseInvoices_paymentStatuses_paymentStatusId",
                table: "PurchaseInvoices",
                column: "paymentStatusId",
                principalTable: "paymentStatuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseReturns_paymentStatuses_paymentStatusId",
                table: "PurchaseReturns",
                column: "paymentStatusId",
                principalTable: "paymentStatuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DebitNotes_paymentStatuses_paymentStatusId",
                table: "DebitNotes");

            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseInvoices_paymentStatuses_paymentStatusId",
                table: "PurchaseInvoices");

            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseReturns_paymentStatuses_paymentStatusId",
                table: "PurchaseReturns");

            migrationBuilder.DropTable(
                name: "paymentStatuses");

            migrationBuilder.DropIndex(
                name: "IX_PurchaseReturns_paymentStatusId",
                table: "PurchaseReturns");

            migrationBuilder.DropIndex(
                name: "IX_PurchaseInvoices_paymentStatusId",
                table: "PurchaseInvoices");

            migrationBuilder.DropIndex(
                name: "IX_DebitNotes_paymentStatusId",
                table: "DebitNotes");

            migrationBuilder.DropColumn(
                name: "paymentStatusId",
                table: "PurchaseReturns");

            migrationBuilder.DropColumn(
                name: "paymentStatusId",
                table: "PurchaseInvoices");

            migrationBuilder.DropColumn(
                name: "paymentStatusId",
                table: "DebitNotes");
        }
    }
}
