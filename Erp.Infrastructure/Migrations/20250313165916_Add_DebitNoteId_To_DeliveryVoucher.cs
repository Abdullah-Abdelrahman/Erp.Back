using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Erp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Add_DebitNoteId_To_DeliveryVoucher : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "debitNoteId",
                table: "DeliveryVouchers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_DeliveryVouchers_debitNoteId",
                table: "DeliveryVouchers",
                column: "debitNoteId");

            migrationBuilder.AddForeignKey(
                name: "FK_DeliveryVouchers_DebitNotes_debitNoteId",
                table: "DeliveryVouchers",
                column: "debitNoteId",
                principalTable: "DebitNotes",
                principalColumn: "DebitNoteId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DeliveryVouchers_DebitNotes_debitNoteId",
                table: "DeliveryVouchers");

            migrationBuilder.DropIndex(
                name: "IX_DeliveryVouchers_debitNoteId",
                table: "DeliveryVouchers");

            migrationBuilder.DropColumn(
                name: "debitNoteId",
                table: "DeliveryVouchers");
        }
    }
}
