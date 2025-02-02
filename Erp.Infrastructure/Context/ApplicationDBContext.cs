using Erp.Data.Entities.AccountsModule;
using Erp.Data.Entities.CustomersModule;
using Erp.Data.Entities.InventoryModule;
using Erp.Data.Entities.MainModule;
using Erp.Data.Entities.PurchasesModule;
using Erp.Data.Entities.SalesModule;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Name.Infrastructure.Data
{
  public class ApplicationDBContext : IdentityDbContext<UserBase>
  {

    //private readonly IEncryptionProvider _encryptionProvider;
    public ApplicationDBContext() { }

    public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
    {

      //_encryptionProvider = new GenerateEncryptionProvider("dthfhgwt365d765dhgfyt46cghfo97hgk05dhft46dc");
    }

    #region Dbsets

    /// -------------------Main Module-----------------------///

    public DbSet<UserBase> userBases { get; set; }



    // -------------------Inventory Module-----------------------//

    #region InventoryDbsets
    public DbSet<Product> Products { get; set; }// المنتجات
    public DbSet<Category> Categories { get; set; }// نوع النتج
    public DbSet<Warehouse> Warehouses { get; set; } // المخزن

    // تسجيل جميع انواع الاذونات
    public DbSet<StockTransaction> StockTransactions { get; set; }



    public DbSet<ReceivingVoucher> ReceivingVouchers { get; set; }//اضافه لمخزن
    public DbSet<ReceivingVoucherItem> receivingVoucherItems { get; set; }//تفاصيل الطلب


    //إذن صرف مخزن
    public DbSet<DeliveryVoucher> DeliveryVouchers { get; set; }
    public DbSet<DeliveryVoucherItem> deliveryVoucherItems { get; set; }



    //
    public DbSet<TransformVoucher> transformVouchers { get; set; }// اذن تحويل من مخزن لمخزن
    public DbSet<TransformVoucherItem> transformVoucherItems { get; set; }



    #endregion

    // -------------------Purchases Module-----------------------//

    #region PurchasesDbsets
    //فاتوره شراء
    public DbSet<PurchaseInvoice> PurchaseInvoices { get; set; }
    //المنتجات الموجوده في فاتوره الشراء
    public DbSet<PurchaseInvoiceItem> PurchaseInvoiceItems { get; set; }

    // فاتوره مرتجعات
    public DbSet<PurchaseReturn> PurchaseReturns { get; set; }
    // المنتجات الموجوده في فاتوره المرتجعات
    public DbSet<PurchaseReturnItem> PurchaseReturnItems { get; set; }

    // اشعارات مدينه
    public DbSet<DebitNote> DebitNotes { get; set; }

    public DbSet<DebitNoteItem> DebitNoteItems { get; set; }


    //الموريدين
    public DbSet<Supplier> Suppliers { get; set; }


    // اعدادات فاتوره الشراء
    public DbSet<PurchaseInoviceSettings> purchaseInoviceSettings { get; set; }

    #endregion

    // -------------------Accounts Module-----------------------//
    #region AccountsDbsets
    public DbSet<Account> Accounts { get; set; }
    public DbSet<SecondaryAccount> secondaryAccounts { get; set; }
    public DbSet<PrimaryAccount> primaryAccounts { get; set; }

    public DbSet<CostCenter> costCenters { get; set; }
    public DbSet<PrimaryCostCenter> primaryCostCenters { get; set; }
    public DbSet<SecondaryCostCenter> secondaryCostCenters { get; set; }



    public DbSet<JournalEntry> journalEntries { get; set; }
    public DbSet<JournalEntryDetail> journalEntryDetails { get; set; }


    #endregion
    // -------------------Customers Module-----------------------//
    #region CustomersDbsets
    public DbSet<Customer> Customers { get; set; }
    public DbSet<CommercialCustomer> commercialCustomers { get; set; }
    public DbSet<IndividualCustomer> individualCustomers { get; set; }
    public DbSet<ContactList> contactLists { get; set; }
    public DbSet<CustomerClassification> customerClassifications { get; set; }
    #endregion


    // -------------------Sales Module-----------------------//

    #region SalesDbsets
    public DbSet<Invoice> invoices { get; set; }
    public DbSet<InvoiceItem> InvoiceItems { get; set; }
    public DbSet<Quotation> Quotations { get; set; }
    public DbSet<QuotationItem> QuotationItems { get; set; }
    public DbSet<RecurringInvoice> RecurringInvoices { get; set; }
    public DbSet<RecurringInvoiceItem> recurringInvoiceItems { get; set; }
    public DbSet<CreditNote> CreditNotes { get; set; }
    public DbSet<CreditNoteItem> creditNoteItems { get; set; }
    public DbSet<CustomerPayment> CustomerPayments { get; set; }

    #endregion
    // -------------------Finance Module-----------------------//
    #region FinanceDbsets

    #endregion
    // -------------------HumanResources Module-----------------------//

    #region HumanResources


    #endregion


    #endregion




    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      //optionsBuilder.UseSqlServer("Data Source=DESKTOP-30J4B23\\SQLEXPRESS;Initial Catalog= OnlineGym ;Integrated Security=True;Connect Timeout=100;Trust Server Certificate=True");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      base.OnModelCreating(modelBuilder);

      // -------------------Inventory Module-----------------------//
      #region Inventory
      // modelBuilder.UseEncryption(_encryptionProvider);
      modelBuilder.Entity<Product>()
          .HasMany(p => p.StockTransactions)
          .WithOne(st => st.Product)
          .HasForeignKey(st => st.ProductId);

      modelBuilder.Entity<StockTransaction>()
          .HasOne(st => st.Warehouse)
          .WithMany(w => w.StockTransactions)
          .HasForeignKey(st => st.WarehouseId);


      modelBuilder.Entity<ReceivingVoucher>().
          HasMany(po => po.receivingVoucherItems).
          WithOne(poi => poi.receivingVoucher).
          HasForeignKey(poi => poi.receivingVoucherId);

      modelBuilder.Entity<ReceivingVoucherItem>()
          .HasOne(poi => poi.Product)
          .WithMany()
          .HasForeignKey(poi => poi.ProductId);

      modelBuilder.Entity<DeliveryVoucher>().
          HasMany(so => so.deliveryVoucherItems).
          WithOne(soi => soi.deliveryVoucher).
          HasForeignKey(soi => soi.deliveryVoucherId);

      modelBuilder.Entity<DeliveryVoucherItem>()
          .HasOne(soi => soi.Product)
          .WithMany()
          .HasForeignKey(soi => soi.ProductId);


      modelBuilder.Entity<TransformVoucher>().
         HasMany(po => po.TransformItems).
         WithOne(poi => poi.transformVoucher).
         HasForeignKey(poi => poi.transformVoucherId);

      modelBuilder.Entity<TransformVoucherItem>()
          .HasOne(poi => poi.Product)
          .WithMany()
          .HasForeignKey(poi => poi.ProductId);

      modelBuilder.Entity<TransformVoucher>()
       .HasOne(tv => tv.FromWarehouse)
       .WithMany()
       .HasForeignKey(tv => tv.FromWarehouseId)
       .OnDelete(DeleteBehavior.Restrict);

      modelBuilder.Entity<TransformVoucher>()
          .HasOne(tv => tv.ToWarehouse)
          .WithMany()
          .HasForeignKey(tv => tv.ToWarehouseId)
          .OnDelete(DeleteBehavior.Restrict);


      #endregion


      // -------------------Accounts Module-----------------------//
      #region Accounts
      modelBuilder.Entity<Account>()
          .HasDiscriminator<string>("AccountType")
          .HasValue<PrimaryAccount>("Primary")
          .HasValue<SecondaryAccount>("Secondary");


      modelBuilder.Entity<CostCenter>()
           .HasDiscriminator<string>("CostCenterType")
           .HasValue<PrimaryCostCenter>("Primary")
           .HasValue<SecondaryCostCenter>("Secondary");



      modelBuilder.Entity<JournalEntryDetail>()
        .HasOne(jd => jd.JournalEntry)
        .WithMany(j => j.details)
        .HasForeignKey(jd => jd.JournalEntryID)
        .OnDelete(DeleteBehavior.Restrict); // Prevents cascading delete

      modelBuilder.Entity<JournalEntryDetail>()
          .HasOne(jd => jd.Account)
          .WithMany()
          .HasForeignKey(jd => jd.AccountID)
          .OnDelete(DeleteBehavior.Restrict);

      modelBuilder.Entity<JournalEntryDetail>()
          .HasOne(jd => jd.CostCenter)
          .WithMany()
          .HasForeignKey(jd => jd.CostCenterId)
          .OnDelete(DeleteBehavior.Restrict);
      #endregion

      // -------------------Customers Module-----------------------//

      #region Customers
      modelBuilder.Entity<Customer>()
          .HasDiscriminator<string>("CustomerType")
          .HasValue<CommercialCustomer>("Commercial")
          .HasValue<IndividualCustomer>("Individual");



      modelBuilder.Entity<ContactList>()
        .HasOne(jd => jd.Customer).WithMany(i => i.ContactLists)
        .HasForeignKey(jd => jd.CustomerId)
        .OnDelete(DeleteBehavior.Restrict); // Prevents cascading delete


      #endregion
      // -------------------Sales Module-----------------------//



      modelBuilder.Entity<Invoice>().
          HasMany(po => po.Items).
          WithOne(poi => poi.Invoice).
          HasForeignKey(poi => poi.InvoiceID);

      modelBuilder.Entity<InvoiceItem>()
          .HasOne(poi => poi.product)
          .WithMany()
          .HasForeignKey(poi => poi.productID);

      modelBuilder.Entity<CreditNote>().
          HasMany(po => po.Items).
          WithOne(poi => poi.creditNote).
          HasForeignKey(poi => poi.CreditNoteID);

      modelBuilder.Entity<CreditNoteItem>()
          .HasOne(poi => poi.product)
          .WithMany()
          .HasForeignKey(poi => poi.productID);


      modelBuilder.Entity<Quotation>().
          HasMany(po => po.Items).
          WithOne(poi => poi.Quotation).
          HasForeignKey(poi => poi.QuotationId);

      modelBuilder.Entity<QuotationItem>()
          .HasOne(poi => poi.Product)
          .WithMany()
          .HasForeignKey(poi => poi.ProductId);

      modelBuilder.Entity<RecurringInvoice>().
         HasMany(po => po.Items).
         WithOne(poi => poi.RInvoice).
         HasForeignKey(poi => poi.RInvoiceID);

      modelBuilder.Entity<RecurringInvoiceItem>()
          .HasOne(poi => poi.product)
          .WithMany()
          .HasForeignKey(poi => poi.productID);

      modelBuilder.Entity<CustomerPayment>()
        .HasOne(cp => cp.Invoice)
        .WithMany(i => i.payments)
        .HasForeignKey(cp => cp.InvoiceId)
        .OnDelete(DeleteBehavior.Restrict);
    }

  }


}
