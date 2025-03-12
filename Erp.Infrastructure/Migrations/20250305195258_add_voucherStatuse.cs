using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Erp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class add_voucherStatuse : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "VoucherStatusId",
                table: "ReceivingVouchers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "voucherStatuses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_voucherStatuses", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ReceivingVouchers_VoucherStatusId",
                table: "ReceivingVouchers",
                column: "VoucherStatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_ReceivingVouchers_voucherStatuses_VoucherStatusId",
                table: "ReceivingVouchers",
                column: "VoucherStatusId",
                principalTable: "voucherStatuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ReceivingVouchers_voucherStatuses_VoucherStatusId",
                table: "ReceivingVouchers");

            migrationBuilder.DropTable(
                name: "voucherStatuses");

            migrationBuilder.DropIndex(
                name: "IX_ReceivingVouchers_VoucherStatusId",
                table: "ReceivingVouchers");

            migrationBuilder.DropColumn(
                name: "VoucherStatusId",
                table: "ReceivingVouchers");
        }
    }
}
