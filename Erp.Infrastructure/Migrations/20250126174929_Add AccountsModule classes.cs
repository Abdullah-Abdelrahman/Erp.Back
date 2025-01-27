using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Erp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddAccountsModuleclasses : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DebitNotes_PurchaseInvoices_PurchaseInvoiceId",
                table: "DebitNotes");

            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseReturns_PurchaseInvoices_PurchaseInvoiceId",
                table: "PurchaseReturns");

            migrationBuilder.DropTable(
                name: "SupplierPayments");

            migrationBuilder.DropColumn(
                name: "TotalPrice",
                table: "PurchaseInvoiceItems");

            migrationBuilder.RenameColumn(
                name: "PurchaseInvoiceId",
                table: "PurchaseReturns",
                newName: "supplierId");

            migrationBuilder.RenameIndex(
                name: "IX_PurchaseReturns_PurchaseInvoiceId",
                table: "PurchaseReturns",
                newName: "IX_PurchaseReturns_supplierId");

            migrationBuilder.RenameColumn(
                name: "PurchaseInvoiceId",
                table: "DebitNotes",
                newName: "SupplierId");

            migrationBuilder.RenameIndex(
                name: "IX_DebitNotes_PurchaseInvoiceId",
                table: "DebitNotes",
                newName: "IX_DebitNotes_SupplierId");

            migrationBuilder.AddColumn<bool>(
                name: "IsPaid",
                table: "PurchaseInvoices",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "numberOfDaysToPay",
                table: "PurchaseInvoices",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Company",
                columns: table => new
                {
                    CompanyID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CompanyAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CompanyEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Domain = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SubscriptionStartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SubscriptionEndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Company", x => x.CompanyID);
                });

            migrationBuilder.CreateTable(
                name: "costCenters",
                columns: table => new
                {
                    CostCenterId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ParentCostCenterID = table.Column<int>(type: "int", nullable: true),
                    CostCenterType = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: false),
                    PrimaryCostCenterCostCenterId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_costCenters", x => x.CostCenterId);
                    table.ForeignKey(
                        name: "FK_costCenters_costCenters_ParentCostCenterID",
                        column: x => x.ParentCostCenterID,
                        principalTable: "costCenters",
                        principalColumn: "CostCenterId");
                    table.ForeignKey(
                        name: "FK_costCenters_costCenters_PrimaryCostCenterCostCenterId",
                        column: x => x.PrimaryCostCenterCostCenterId,
                        principalTable: "costCenters",
                        principalColumn: "CostCenterId");
                });

            migrationBuilder.CreateTable(
                name: "DebitNoteItems",
                columns: table => new
                {
                    DebitNoteItemId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DebitNoteId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    discount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Tax = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    UnitPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DebitNoteItems", x => x.DebitNoteItemId);
                    table.ForeignKey(
                        name: "FK_DebitNoteItems_DebitNotes_DebitNoteId",
                        column: x => x.DebitNoteId,
                        principalTable: "DebitNotes",
                        principalColumn: "DebitNoteId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DebitNoteItems_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    AccountID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyID = table.Column<int>(type: "int", nullable: false),
                    AccountName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    Balance = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ParentAccountID = table.Column<int>(type: "int", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AccountType = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: false),
                    PrimaryAccountAccountID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.AccountID);
                    table.ForeignKey(
                        name: "FK_Accounts_Accounts_ParentAccountID",
                        column: x => x.ParentAccountID,
                        principalTable: "Accounts",
                        principalColumn: "AccountID");
                    table.ForeignKey(
                        name: "FK_Accounts_Accounts_PrimaryAccountAccountID",
                        column: x => x.PrimaryAccountAccountID,
                        principalTable: "Accounts",
                        principalColumn: "AccountID");
                    table.ForeignKey(
                        name: "FK_Accounts_Company_CompanyID",
                        column: x => x.CompanyID,
                        principalTable: "Company",
                        principalColumn: "CompanyID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "journalEntries",
                columns: table => new
                {
                    JournalEntryID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyID = table.Column<int>(type: "int", nullable: false),
                    EntryDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_journalEntries", x => x.JournalEntryID);
                    table.ForeignKey(
                        name: "FK_journalEntries_Company_CompanyID",
                        column: x => x.CompanyID,
                        principalTable: "Company",
                        principalColumn: "CompanyID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "journalEntryDetails",
                columns: table => new
                {
                    JournalEntryDetailID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    JournalEntryID = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AccountID = table.Column<int>(type: "int", nullable: false),
                    Debit = table.Column<decimal>(type: "decimal(15,2)", nullable: false),
                    Credit = table.Column<decimal>(type: "decimal(15,2)", nullable: false),
                    CostCenterId = table.Column<int>(type: "int", nullable: true),
                    SecondaryAccountAccountID = table.Column<int>(type: "int", nullable: true),
                    SecondaryCostCenterCostCenterId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_journalEntryDetails", x => x.JournalEntryDetailID);
                    table.ForeignKey(
                        name: "FK_journalEntryDetails_Accounts_AccountID",
                        column: x => x.AccountID,
                        principalTable: "Accounts",
                        principalColumn: "AccountID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_journalEntryDetails_Accounts_SecondaryAccountAccountID",
                        column: x => x.SecondaryAccountAccountID,
                        principalTable: "Accounts",
                        principalColumn: "AccountID");
                    table.ForeignKey(
                        name: "FK_journalEntryDetails_costCenters_CostCenterId",
                        column: x => x.CostCenterId,
                        principalTable: "costCenters",
                        principalColumn: "CostCenterId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_journalEntryDetails_costCenters_SecondaryCostCenterCostCenterId",
                        column: x => x.SecondaryCostCenterCostCenterId,
                        principalTable: "costCenters",
                        principalColumn: "CostCenterId");
                    table.ForeignKey(
                        name: "FK_journalEntryDetails_journalEntries_JournalEntryID",
                        column: x => x.JournalEntryID,
                        principalTable: "journalEntries",
                        principalColumn: "JournalEntryID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_CompanyID",
                table: "Accounts",
                column: "CompanyID");

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_ParentAccountID",
                table: "Accounts",
                column: "ParentAccountID");

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_PrimaryAccountAccountID",
                table: "Accounts",
                column: "PrimaryAccountAccountID");

            migrationBuilder.CreateIndex(
                name: "IX_costCenters_ParentCostCenterID",
                table: "costCenters",
                column: "ParentCostCenterID");

            migrationBuilder.CreateIndex(
                name: "IX_costCenters_PrimaryCostCenterCostCenterId",
                table: "costCenters",
                column: "PrimaryCostCenterCostCenterId");

            migrationBuilder.CreateIndex(
                name: "IX_DebitNoteItems_DebitNoteId",
                table: "DebitNoteItems",
                column: "DebitNoteId");

            migrationBuilder.CreateIndex(
                name: "IX_DebitNoteItems_ProductId",
                table: "DebitNoteItems",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_journalEntries_CompanyID",
                table: "journalEntries",
                column: "CompanyID");

            migrationBuilder.CreateIndex(
                name: "IX_journalEntryDetails_AccountID",
                table: "journalEntryDetails",
                column: "AccountID");

            migrationBuilder.CreateIndex(
                name: "IX_journalEntryDetails_CostCenterId",
                table: "journalEntryDetails",
                column: "CostCenterId");

            migrationBuilder.CreateIndex(
                name: "IX_journalEntryDetails_JournalEntryID",
                table: "journalEntryDetails",
                column: "JournalEntryID");

            migrationBuilder.CreateIndex(
                name: "IX_journalEntryDetails_SecondaryAccountAccountID",
                table: "journalEntryDetails",
                column: "SecondaryAccountAccountID");

            migrationBuilder.CreateIndex(
                name: "IX_journalEntryDetails_SecondaryCostCenterCostCenterId",
                table: "journalEntryDetails",
                column: "SecondaryCostCenterCostCenterId");

            migrationBuilder.AddForeignKey(
                name: "FK_DebitNotes_Suppliers_SupplierId",
                table: "DebitNotes",
                column: "SupplierId",
                principalTable: "Suppliers",
                principalColumn: "SupplierId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseReturns_Suppliers_supplierId",
                table: "PurchaseReturns",
                column: "supplierId",
                principalTable: "Suppliers",
                principalColumn: "SupplierId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DebitNotes_Suppliers_SupplierId",
                table: "DebitNotes");

            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseReturns_Suppliers_supplierId",
                table: "PurchaseReturns");

            migrationBuilder.DropTable(
                name: "DebitNoteItems");

            migrationBuilder.DropTable(
                name: "journalEntryDetails");

            migrationBuilder.DropTable(
                name: "Accounts");

            migrationBuilder.DropTable(
                name: "costCenters");

            migrationBuilder.DropTable(
                name: "journalEntries");

            migrationBuilder.DropTable(
                name: "Company");

            migrationBuilder.DropColumn(
                name: "IsPaid",
                table: "PurchaseInvoices");

            migrationBuilder.DropColumn(
                name: "numberOfDaysToPay",
                table: "PurchaseInvoices");

            migrationBuilder.RenameColumn(
                name: "supplierId",
                table: "PurchaseReturns",
                newName: "PurchaseInvoiceId");

            migrationBuilder.RenameIndex(
                name: "IX_PurchaseReturns_supplierId",
                table: "PurchaseReturns",
                newName: "IX_PurchaseReturns_PurchaseInvoiceId");

            migrationBuilder.RenameColumn(
                name: "SupplierId",
                table: "DebitNotes",
                newName: "PurchaseInvoiceId");

            migrationBuilder.RenameIndex(
                name: "IX_DebitNotes_SupplierId",
                table: "DebitNotes",
                newName: "IX_DebitNotes_PurchaseInvoiceId");

            migrationBuilder.AddColumn<decimal>(
                name: "TotalPrice",
                table: "PurchaseInvoiceItems",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.CreateTable(
                name: "SupplierPayments",
                columns: table => new
                {
                    SupplierPaymentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SupplierId = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PaymentDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SupplierPayments", x => x.SupplierPaymentId);
                    table.ForeignKey(
                        name: "FK_SupplierPayments_Suppliers_SupplierId",
                        column: x => x.SupplierId,
                        principalTable: "Suppliers",
                        principalColumn: "SupplierId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SupplierPayments_SupplierId",
                table: "SupplierPayments",
                column: "SupplierId");

            migrationBuilder.AddForeignKey(
                name: "FK_DebitNotes_PurchaseInvoices_PurchaseInvoiceId",
                table: "DebitNotes",
                column: "PurchaseInvoiceId",
                principalTable: "PurchaseInvoices",
                principalColumn: "PurchaseInvoiceId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseReturns_PurchaseInvoices_PurchaseInvoiceId",
                table: "PurchaseReturns",
                column: "PurchaseInvoiceId",
                principalTable: "PurchaseInvoices",
                principalColumn: "PurchaseInvoiceId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
