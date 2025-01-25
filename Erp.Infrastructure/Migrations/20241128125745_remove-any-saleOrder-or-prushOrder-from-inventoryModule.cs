using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Erp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class removeanysaleOrderorprushOrderfrominventoryModule : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DeliveryVouchers_SalesOrders_SalesOrderId",
                table: "DeliveryVouchers");

            migrationBuilder.DropForeignKey(
                name: "FK_ReceivingVouchers_PurchaseOrders_PurchaseOrderId",
                table: "ReceivingVouchers");

            migrationBuilder.DropTable(
                name: "PurchaseOrderItems");

            migrationBuilder.DropTable(
                name: "SalesOrderItems");

            migrationBuilder.DropTable(
                name: "PurchaseOrders");

            migrationBuilder.DropTable(
                name: "SalesOrders");

            migrationBuilder.DropIndex(
                name: "IX_DeliveryVouchers_SalesOrderId",
                table: "DeliveryVouchers");

            migrationBuilder.DropColumn(
                name: "SalesOrderId",
                table: "DeliveryVouchers");

            migrationBuilder.RenameColumn(
                name: "PurchaseOrderId",
                table: "ReceivingVouchers",
                newName: "SupplierId");

            migrationBuilder.RenameIndex(
                name: "IX_ReceivingVouchers_PurchaseOrderId",
                table: "ReceivingVouchers",
                newName: "IX_ReceivingVouchers_SupplierId");

            migrationBuilder.CreateTable(
                name: "deliveryVoucherItems",
                columns: table => new
                {
                    DeliveryVoucherItemId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    UnitPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    deliveryVoucherId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_deliveryVoucherItems", x => x.DeliveryVoucherItemId);
                    table.ForeignKey(
                        name: "FK_deliveryVoucherItems_DeliveryVouchers_deliveryVoucherId",
                        column: x => x.deliveryVoucherId,
                        principalTable: "DeliveryVouchers",
                        principalColumn: "DeliveryVoucherId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_deliveryVoucherItems_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "receivingVoucherItems",
                columns: table => new
                {
                    ReceivingVoucherItemId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    UnitPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    receivingVoucherId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_receivingVoucherItems", x => x.ReceivingVoucherItemId);
                    table.ForeignKey(
                        name: "FK_receivingVoucherItems_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_receivingVoucherItems_ReceivingVouchers_receivingVoucherId",
                        column: x => x.receivingVoucherId,
                        principalTable: "ReceivingVouchers",
                        principalColumn: "ReceivingVoucherId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_deliveryVoucherItems_deliveryVoucherId",
                table: "deliveryVoucherItems",
                column: "deliveryVoucherId");

            migrationBuilder.CreateIndex(
                name: "IX_deliveryVoucherItems_ProductId",
                table: "deliveryVoucherItems",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_receivingVoucherItems_ProductId",
                table: "receivingVoucherItems",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_receivingVoucherItems_receivingVoucherId",
                table: "receivingVoucherItems",
                column: "receivingVoucherId");

            migrationBuilder.AddForeignKey(
                name: "FK_ReceivingVouchers_Suppliers_SupplierId",
                table: "ReceivingVouchers",
                column: "SupplierId",
                principalTable: "Suppliers",
                principalColumn: "SupplierId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ReceivingVouchers_Suppliers_SupplierId",
                table: "ReceivingVouchers");

            migrationBuilder.DropTable(
                name: "deliveryVoucherItems");

            migrationBuilder.DropTable(
                name: "receivingVoucherItems");

            migrationBuilder.RenameColumn(
                name: "SupplierId",
                table: "ReceivingVouchers",
                newName: "PurchaseOrderId");

            migrationBuilder.RenameIndex(
                name: "IX_ReceivingVouchers_SupplierId",
                table: "ReceivingVouchers",
                newName: "IX_ReceivingVouchers_PurchaseOrderId");

            migrationBuilder.AddColumn<int>(
                name: "SalesOrderId",
                table: "DeliveryVouchers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "PurchaseOrders",
                columns: table => new
                {
                    PurchaseOrderId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SupplierId = table.Column<int>(type: "int", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TotalAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaseOrders", x => x.PurchaseOrderId);
                    table.ForeignKey(
                        name: "FK_PurchaseOrders_Suppliers_SupplierId",
                        column: x => x.SupplierId,
                        principalTable: "Suppliers",
                        principalColumn: "SupplierId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SalesOrders",
                columns: table => new
                {
                    SalesOrderId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TotalAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalesOrders", x => x.SalesOrderId);
                });

            migrationBuilder.CreateTable(
                name: "PurchaseOrderItems",
                columns: table => new
                {
                    PurchaseOrderItemId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    PurchaseOrderId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    UnitPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaseOrderItems", x => x.PurchaseOrderItemId);
                    table.ForeignKey(
                        name: "FK_PurchaseOrderItems_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PurchaseOrderItems_PurchaseOrders_PurchaseOrderId",
                        column: x => x.PurchaseOrderId,
                        principalTable: "PurchaseOrders",
                        principalColumn: "PurchaseOrderId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SalesOrderItems",
                columns: table => new
                {
                    SalesOrderItemId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    SalesOrderId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    UnitPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalesOrderItems", x => x.SalesOrderItemId);
                    table.ForeignKey(
                        name: "FK_SalesOrderItems_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SalesOrderItems_SalesOrders_SalesOrderId",
                        column: x => x.SalesOrderId,
                        principalTable: "SalesOrders",
                        principalColumn: "SalesOrderId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DeliveryVouchers_SalesOrderId",
                table: "DeliveryVouchers",
                column: "SalesOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseOrderItems_ProductId",
                table: "PurchaseOrderItems",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseOrderItems_PurchaseOrderId",
                table: "PurchaseOrderItems",
                column: "PurchaseOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseOrders_SupplierId",
                table: "PurchaseOrders",
                column: "SupplierId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesOrderItems_ProductId",
                table: "SalesOrderItems",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesOrderItems_SalesOrderId",
                table: "SalesOrderItems",
                column: "SalesOrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_DeliveryVouchers_SalesOrders_SalesOrderId",
                table: "DeliveryVouchers",
                column: "SalesOrderId",
                principalTable: "SalesOrders",
                principalColumn: "SalesOrderId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ReceivingVouchers_PurchaseOrders_PurchaseOrderId",
                table: "ReceivingVouchers",
                column: "PurchaseOrderId",
                principalTable: "PurchaseOrders",
                principalColumn: "PurchaseOrderId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
