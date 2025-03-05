using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Erp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class update_Product_and_service_table_make_it_using_TPH : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_creditNoteItems_Products_productID",
                table: "creditNoteItems");

            migrationBuilder.DropForeignKey(
                name: "FK_DebitNoteItems_Products_ProductId",
                table: "DebitNoteItems");

            migrationBuilder.DropForeignKey(
                name: "FK_deliveryVoucherItems_Products_ProductId",
                table: "deliveryVoucherItems");

            migrationBuilder.DropForeignKey(
                name: "FK_InvoiceItems_Products_productID",
                table: "InvoiceItems");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Suppliers_SupplierId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseInvoiceItems_Products_ProductId",
                table: "PurchaseInvoiceItems");

            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseReturnItems_Products_ProductId",
                table: "PurchaseReturnItems");

            migrationBuilder.DropForeignKey(
                name: "FK_QuotationItems_Products_ProductId",
                table: "QuotationItems");

            migrationBuilder.DropForeignKey(
                name: "FK_receivingVoucherItems_Products_ProductId",
                table: "receivingVoucherItems");

            migrationBuilder.DropForeignKey(
                name: "FK_recurringInvoiceItems_Products_productID",
                table: "recurringInvoiceItems");

            migrationBuilder.DropForeignKey(
                name: "FK_StockTransactions_Products_ProductId",
                table: "StockTransactions");

            migrationBuilder.DropForeignKey(
                name: "FK_transformVoucherItems_Products_ProductId",
                table: "transformVoucherItems");

            migrationBuilder.DropTable(
                name: "CategoryProduct");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Products",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "isActive",
                table: "Products");

            migrationBuilder.RenameTable(
                name: "Products",
                newName: "productAndServiceBases");

            migrationBuilder.RenameColumn(
                name: "ProductName",
                table: "productAndServiceBases",
                newName: "Name");

            migrationBuilder.RenameIndex(
                name: "IX_Products_SupplierId",
                table: "productAndServiceBases",
                newName: "IX_productAndServiceBases_SupplierId");

            migrationBuilder.AddColumn<int>(
                name: "ProductAndServiceBaseProductId",
                table: "Categories",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "StockQuantity",
                table: "productAndServiceBases",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "ProductOrService",
                table: "productAndServiceBases",
                type: "nvarchar(21)",
                maxLength: 21,
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "MinAmountBeforNotefy",
                table: "productAndServiceBases",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "productAndServiceBases",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "productAndServiceBases",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "TrackInventory",
                table: "productAndServiceBases",
                type: "bit",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_productAndServiceBases",
                table: "productAndServiceBases",
                column: "ProductId");

            migrationBuilder.CreateTable(
                name: "priceLists",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TenantId = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_priceLists", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "priceListItems",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    PriceListId = table.Column<int>(type: "int", nullable: false),
                    SellPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TenantId = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_priceListItems", x => new { x.PriceListId, x.ProductId });
                    table.ForeignKey(
                        name: "FK_priceListItems_priceLists_PriceListId",
                        column: x => x.PriceListId,
                        principalTable: "priceLists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_priceListItems_productAndServiceBases_ProductId",
                        column: x => x.ProductId,
                        principalTable: "productAndServiceBases",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Categories_ProductAndServiceBaseProductId",
                table: "Categories",
                column: "ProductAndServiceBaseProductId");

            migrationBuilder.CreateIndex(
                name: "IX_productAndServiceBases_CategoryId",
                table: "productAndServiceBases",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_priceListItems_ProductId",
                table: "priceListItems",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_productAndServiceBases_ProductAndServiceBaseProductId",
                table: "Categories",
                column: "ProductAndServiceBaseProductId",
                principalTable: "productAndServiceBases",
                principalColumn: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_creditNoteItems_productAndServiceBases_productID",
                table: "creditNoteItems",
                column: "productID",
                principalTable: "productAndServiceBases",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DebitNoteItems_productAndServiceBases_ProductId",
                table: "DebitNoteItems",
                column: "ProductId",
                principalTable: "productAndServiceBases",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_deliveryVoucherItems_productAndServiceBases_ProductId",
                table: "deliveryVoucherItems",
                column: "ProductId",
                principalTable: "productAndServiceBases",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_InvoiceItems_productAndServiceBases_productID",
                table: "InvoiceItems",
                column: "productID",
                principalTable: "productAndServiceBases",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_productAndServiceBases_Categories_CategoryId",
                table: "productAndServiceBases",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_productAndServiceBases_Suppliers_SupplierId",
                table: "productAndServiceBases",
                column: "SupplierId",
                principalTable: "Suppliers",
                principalColumn: "SupplierId");

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseInvoiceItems_productAndServiceBases_ProductId",
                table: "PurchaseInvoiceItems",
                column: "ProductId",
                principalTable: "productAndServiceBases",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseReturnItems_productAndServiceBases_ProductId",
                table: "PurchaseReturnItems",
                column: "ProductId",
                principalTable: "productAndServiceBases",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_QuotationItems_productAndServiceBases_ProductId",
                table: "QuotationItems",
                column: "ProductId",
                principalTable: "productAndServiceBases",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_receivingVoucherItems_productAndServiceBases_ProductId",
                table: "receivingVoucherItems",
                column: "ProductId",
                principalTable: "productAndServiceBases",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_recurringInvoiceItems_productAndServiceBases_productID",
                table: "recurringInvoiceItems",
                column: "productID",
                principalTable: "productAndServiceBases",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StockTransactions_productAndServiceBases_ProductId",
                table: "StockTransactions",
                column: "ProductId",
                principalTable: "productAndServiceBases",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_transformVoucherItems_productAndServiceBases_ProductId",
                table: "transformVoucherItems",
                column: "ProductId",
                principalTable: "productAndServiceBases",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categories_productAndServiceBases_ProductAndServiceBaseProductId",
                table: "Categories");

            migrationBuilder.DropForeignKey(
                name: "FK_creditNoteItems_productAndServiceBases_productID",
                table: "creditNoteItems");

            migrationBuilder.DropForeignKey(
                name: "FK_DebitNoteItems_productAndServiceBases_ProductId",
                table: "DebitNoteItems");

            migrationBuilder.DropForeignKey(
                name: "FK_deliveryVoucherItems_productAndServiceBases_ProductId",
                table: "deliveryVoucherItems");

            migrationBuilder.DropForeignKey(
                name: "FK_InvoiceItems_productAndServiceBases_productID",
                table: "InvoiceItems");

            migrationBuilder.DropForeignKey(
                name: "FK_productAndServiceBases_Categories_CategoryId",
                table: "productAndServiceBases");

            migrationBuilder.DropForeignKey(
                name: "FK_productAndServiceBases_Suppliers_SupplierId",
                table: "productAndServiceBases");

            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseInvoiceItems_productAndServiceBases_ProductId",
                table: "PurchaseInvoiceItems");

            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseReturnItems_productAndServiceBases_ProductId",
                table: "PurchaseReturnItems");

            migrationBuilder.DropForeignKey(
                name: "FK_QuotationItems_productAndServiceBases_ProductId",
                table: "QuotationItems");

            migrationBuilder.DropForeignKey(
                name: "FK_receivingVoucherItems_productAndServiceBases_ProductId",
                table: "receivingVoucherItems");

            migrationBuilder.DropForeignKey(
                name: "FK_recurringInvoiceItems_productAndServiceBases_productID",
                table: "recurringInvoiceItems");

            migrationBuilder.DropForeignKey(
                name: "FK_StockTransactions_productAndServiceBases_ProductId",
                table: "StockTransactions");

            migrationBuilder.DropForeignKey(
                name: "FK_transformVoucherItems_productAndServiceBases_ProductId",
                table: "transformVoucherItems");

            migrationBuilder.DropTable(
                name: "priceListItems");

            migrationBuilder.DropTable(
                name: "priceLists");

            migrationBuilder.DropIndex(
                name: "IX_Categories_ProductAndServiceBaseProductId",
                table: "Categories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_productAndServiceBases",
                table: "productAndServiceBases");

            migrationBuilder.DropIndex(
                name: "IX_productAndServiceBases_CategoryId",
                table: "productAndServiceBases");

            migrationBuilder.DropColumn(
                name: "ProductAndServiceBaseProductId",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "productAndServiceBases");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "productAndServiceBases");

            migrationBuilder.DropColumn(
                name: "TrackInventory",
                table: "productAndServiceBases");

            migrationBuilder.RenameTable(
                name: "productAndServiceBases",
                newName: "Products");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Products",
                newName: "ProductName");

            migrationBuilder.RenameIndex(
                name: "IX_productAndServiceBases_SupplierId",
                table: "Products",
                newName: "IX_Products_SupplierId");

            migrationBuilder.AlterColumn<int>(
                name: "StockQuantity",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ProductOrService",
                table: "Products",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(21)",
                oldMaxLength: 21);

            migrationBuilder.AlterColumn<int>(
                name: "MinAmountBeforNotefy",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "isActive",
                table: "Products",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Products",
                table: "Products",
                column: "ProductId");

            migrationBuilder.CreateTable(
                name: "CategoryProduct",
                columns: table => new
                {
                    ProductsProductId = table.Column<int>(type: "int", nullable: false),
                    categoriesCategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryProduct", x => new { x.ProductsProductId, x.categoriesCategoryId });
                    table.ForeignKey(
                        name: "FK_CategoryProduct_Categories_categoriesCategoryId",
                        column: x => x.categoriesCategoryId,
                        principalTable: "Categories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CategoryProduct_Products_ProductsProductId",
                        column: x => x.ProductsProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CategoryProduct_categoriesCategoryId",
                table: "CategoryProduct",
                column: "categoriesCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_creditNoteItems_Products_productID",
                table: "creditNoteItems",
                column: "productID",
                principalTable: "Products",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DebitNoteItems_Products_ProductId",
                table: "DebitNoteItems",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_deliveryVoucherItems_Products_ProductId",
                table: "deliveryVoucherItems",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_InvoiceItems_Products_productID",
                table: "InvoiceItems",
                column: "productID",
                principalTable: "Products",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Suppliers_SupplierId",
                table: "Products",
                column: "SupplierId",
                principalTable: "Suppliers",
                principalColumn: "SupplierId");

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseInvoiceItems_Products_ProductId",
                table: "PurchaseInvoiceItems",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseReturnItems_Products_ProductId",
                table: "PurchaseReturnItems",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_QuotationItems_Products_ProductId",
                table: "QuotationItems",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_receivingVoucherItems_Products_ProductId",
                table: "receivingVoucherItems",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_recurringInvoiceItems_Products_productID",
                table: "recurringInvoiceItems",
                column: "productID",
                principalTable: "Products",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StockTransactions_Products_ProductId",
                table: "StockTransactions",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_transformVoucherItems_Products_ProductId",
                table: "transformVoucherItems",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
