using Erp.Data.Abstracts;
using Erp.Data.Entities;
using Erp.Data.Entities.AccountsModule;
using Erp.Data.Entities.CustomersModule;
using Erp.Data.Entities.Finance;
using Erp.Data.Entities.HumanResources.OrganizationalStructure;
using Erp.Data.Entities.HumanResources.Staff;
using Erp.Data.Entities.InventoryModule;
using Erp.Data.Entities.MainModule;
using Erp.Data.Entities.PurchasesModule;
using Erp.Data.Entities.SalesModule;
using Erp.Service.Abstracts.MainModule;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Name.Infrastructure.Data
{
  public class ApplicationDBContext : IdentityDbContext<UserBase, ApplicationRole, string>
  {

    //private readonly IEncryptionProvider _encryptionProvider;
    //Aaa123@
    private readonly ITenantService _tenantService;

    public string? CurrentTenantId { get; set; }
    public ApplicationDBContext() { }

    public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options, ITenantService tenantService) : base(options)
    {
      _tenantService = tenantService;
      CurrentTenantId = _tenantService.TenantId;


      //_encryptionProvider = new GenerateEncryptionProvider("dthfhgwt365d765dhgfyt46cghfo97hgk05dhft46dc");

    }

    #region Dbsets


    /// -------------------Main Module-----------------------///

    public DbSet<UserBase> userBases { get; set; }

    public DbSet<ApplicationRole> applicationRoles { get; set; }
    //Without tenant id cause it is fixed for all
    public DbSet<ApplicationClaim> applicationClaims { get; set; }

    public DbSet<Company> companies { get; set; }



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

    public DbSet<BankAccount> BankAccounts { get; set; }
    public DbSet<Expense> Expenses { get; set; }
    public DbSet<ExpenseCategory> ExpenseCategories { get; set; }
    public DbSet<Receipt> Receipts { get; set; }
    public DbSet<ReceiptCategory> ReceiptCategories { get; set; }
    public DbSet<Treasury> Treasuries { get; set; }

    public DbSet<MultiAccExpenseItem> multiAccExpenseItems { get; set; }

    public DbSet<MultiAccReceiptItem> multiAccReceiptItems { get; set; }



    #endregion
    // -------------------HumanResources Module-----------------------//

    #region HumanResources

    public DbSet<Department> departments { get; set; }

    public DbSet<EmploymentLevel> employmentLevels { get; set; }

    public DbSet<EmploymentType> employmentTypes { get; set; }

    public DbSet<JobType> jobTypes { get; set; }




    #endregion


    #endregion




    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      //optionsBuilder.UseSqlServer("Data Source=DESKTOP-30J4B23\\SQLEXPRESS;Initial Catalog= OnlineGym ;Integrated Security=True;Connect Timeout=100;Trust Server Certificate=True");


    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      base.OnModelCreating(modelBuilder);

      #region MainModule
      // modelBuilder.Entity<Company>().HasQueryFilter(p => p.TenantId == CurrentTenantId);
      modelBuilder.Entity<ApplicationRole>().HasQueryFilter(p => p.TenantId == CurrentTenantId);
      #endregion

      // -------------------Inventory Module-----------------------//
      #region Inventory
      // modelBuilder.UseEncryption(_encryptionProvider);

      modelBuilder.Entity<Product>().HasQueryFilter(p => p.TenantId == CurrentTenantId);
      modelBuilder.Entity<Category>().HasQueryFilter(p => p.TenantId == CurrentTenantId);
      modelBuilder.Entity<Warehouse>().HasQueryFilter(p => p.TenantId == CurrentTenantId);
      modelBuilder.Entity<StockTransaction>().HasQueryFilter(p => p.TenantId == CurrentTenantId);
      modelBuilder.Entity<ReceivingVoucher>().HasQueryFilter(p => p.TenantId == CurrentTenantId);
      modelBuilder.Entity<ReceivingVoucherItem>().HasQueryFilter(p => p.TenantId == CurrentTenantId);
      modelBuilder.Entity<DeliveryVoucher>().HasQueryFilter(p => p.TenantId == CurrentTenantId);
      modelBuilder.Entity<DeliveryVoucherItem>().HasQueryFilter(p => p.TenantId == CurrentTenantId);
      modelBuilder.Entity<TransformVoucher>().HasQueryFilter(p => p.TenantId == CurrentTenantId);
      modelBuilder.Entity<TransformVoucherItem>().HasQueryFilter(p => p.TenantId == CurrentTenantId);

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


      // -------------------Purchases Module-----------------------//

      #region Purchases
      modelBuilder.Entity<PurchaseInvoice>().HasQueryFilter(p => p.TenantId == CurrentTenantId);
      modelBuilder.Entity<PurchaseInvoiceItem>().HasQueryFilter(p => p.TenantId == CurrentTenantId);
      modelBuilder.Entity<PurchaseReturn>().HasQueryFilter(p => p.TenantId == CurrentTenantId);
      modelBuilder.Entity<PurchaseReturnItem>().HasQueryFilter(p => p.TenantId == CurrentTenantId);
      modelBuilder.Entity<DebitNote>().HasQueryFilter(p => p.TenantId == CurrentTenantId);
      modelBuilder.Entity<DebitNoteItem>().HasQueryFilter(p => p.TenantId == CurrentTenantId);
      modelBuilder.Entity<Supplier>().HasQueryFilter(p => p.TenantId == CurrentTenantId);
      modelBuilder.Entity<PurchaseInoviceSettings>().HasQueryFilter(p => p.TenantId == CurrentTenantId);

      #endregion

      // -------------------Accounts Module-----------------------//
      #region Accounts

      modelBuilder.Entity<Account>().HasQueryFilter(p => p.TenantId == CurrentTenantId);

      modelBuilder.Entity<CostCenter>().HasQueryFilter(p => p.TenantId == CurrentTenantId);

      modelBuilder.Entity<JournalEntry>().HasQueryFilter(p => p.TenantId == CurrentTenantId);
      modelBuilder.Entity<JournalEntryDetail>().HasQueryFilter(p => p.TenantId == CurrentTenantId);

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

      modelBuilder.Entity<Customer>().HasQueryFilter(p => p.TenantId == CurrentTenantId);

      modelBuilder.Entity<ContactList>().HasQueryFilter(p => p.TenantId == CurrentTenantId);
      modelBuilder.Entity<CustomerClassification>().HasQueryFilter(p => p.TenantId == CurrentTenantId);
      modelBuilder.Entity<Customer>()
          .HasDiscriminator<string>("CustomerType")
          .HasValue<CommercialCustomer>("Commercial")
          .HasValue<IndividualCustomer>("Individual");



      modelBuilder.Entity<ContactList>()
        .HasOne(jd => jd.Customer).WithMany(i => i.ContactLists)
        .HasForeignKey(jd => jd.CustomerId)
        .OnDelete(DeleteBehavior.Cascade);


      #endregion
      // -------------------Sales Module-----------------------//

      #region Sales
      modelBuilder.Entity<Invoice>().HasQueryFilter(p => p.TenantId == CurrentTenantId);
      modelBuilder.Entity<InvoiceItem>().HasQueryFilter(p => p.TenantId == CurrentTenantId);
      modelBuilder.Entity<Quotation>().HasQueryFilter(p => p.TenantId == CurrentTenantId);
      modelBuilder.Entity<QuotationItem>().HasQueryFilter(p => p.TenantId == CurrentTenantId);
      modelBuilder.Entity<RecurringInvoice>().HasQueryFilter(p => p.TenantId == CurrentTenantId);
      modelBuilder.Entity<RecurringInvoiceItem>().HasQueryFilter(p => p.TenantId == CurrentTenantId);
      modelBuilder.Entity<CreditNote>().HasQueryFilter(p => p.TenantId == CurrentTenantId);
      modelBuilder.Entity<CreditNoteItem>().HasQueryFilter(p => p.TenantId == CurrentTenantId);
      modelBuilder.Entity<CustomerPayment>().HasQueryFilter(p => p.TenantId == CurrentTenantId);

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


      #endregion


      // -------------------Finance Module-----------------------//
      #region Finance
      modelBuilder.Entity<BankAccount>().HasQueryFilter(p => p.TenantId == CurrentTenantId);
      modelBuilder.Entity<Expense>().HasQueryFilter(p => p.TenantId == CurrentTenantId);
      modelBuilder.Entity<ExpenseCategory>().HasQueryFilter(p => p.TenantId == CurrentTenantId);
      modelBuilder.Entity<Receipt>().HasQueryFilter(p => p.TenantId == CurrentTenantId);
      modelBuilder.Entity<ReceiptCategory>().HasQueryFilter(p => p.TenantId == CurrentTenantId);
      modelBuilder.Entity<Treasury>().HasQueryFilter(p => p.TenantId == CurrentTenantId);
      modelBuilder.Entity<MultiAccExpenseItem>().HasQueryFilter(p => p.TenantId == CurrentTenantId);
      modelBuilder.Entity<MultiAccReceiptItem>().HasQueryFilter(p => p.TenantId == CurrentTenantId);


      modelBuilder.Entity<BankAccount>()
        .HasMany(b => b.employeesWhoHaveDepositPermessions)
        .WithMany(r => r.BankAccountDepositPermessions)
        .UsingEntity(j => j.ToTable("BankAccountEmployeeDeposit"));

      // Many-to-Many: BankAccount <-> Employee (Withdraw)
      modelBuilder.Entity<BankAccount>()
          .HasMany(b => b.employeesWhoHaveWithdrawPermessions)
          .WithMany(r => r.BankAccountWithdrawPermessions)
          .UsingEntity(j => j.ToTable("BankAccountEmployeeWithdraw"));


      modelBuilder.Entity<BankAccount>()
        .HasMany(b => b.RolesWhoHaveDepositPermessions)
        .WithMany(r => r.BankAccountDepositPermessions)
        .UsingEntity(j => j.ToTable("BankAccountDepositRoles"));

      modelBuilder.Entity<BankAccount>()
          .HasMany(b => b.RolesWhoHaveWithdrawPermessions)
          .WithMany(r => r.BankAccountWithdrawPermessions)
          .UsingEntity(j => j.ToTable("BankAccountWithdrawRoles"));


      modelBuilder.Entity<Treasury>()
        .HasMany(t => t.employeesWhoHaveDepositPermessions)
        .WithMany(r => r.TreasuryDepositPermessions)
        .UsingEntity(j => j.ToTable("TreasuryEmployeeDeposit"));

      // Many-to-Many: Treasury <-> Employee (Withdraw)
      modelBuilder.Entity<Treasury>()
          .HasMany(t => t.employeesWhoHaveWithdrawPermessions)
          .WithMany(r => r.TreasuryWithdrawPermessions)
          .UsingEntity(j => j.ToTable("TreasuryEmployeeWithdraw"));


      modelBuilder.Entity<Treasury>()
        .HasMany(t => t.RolesWhoHaveDepositPermessions)
        .WithMany(r => r.TreasuryDepositPermessions)
        .UsingEntity(j => j.ToTable("TreasuryRoleDeposit"));

      // Many-to-Many: Treasury <-> ApplicationRole (Withdraw)
      modelBuilder.Entity<Treasury>()
          .HasMany(t => t.RolesWhoHaveWithdrawPermessions)
          .WithMany(r => r.TreasuryWithdrawPermessions)
          .UsingEntity(j => j.ToTable("TreasuryRoleWithdraw"));



      modelBuilder.Entity<Expense>()
       .HasMany(s => s.CostCenters)
       .WithMany(b => b.Expenses)
       .UsingEntity<ExpenseCostCenter>(
        j => j
            .HasOne(sb => sb.CostCenter)
            .WithMany(b => b.ExpenseCostCenters)
            .HasForeignKey(sb => sb.CostCenterId),
        j => j
            .HasOne(sb => sb.Expense)
            .WithMany(s => s.ExpenseCostCenters)
            .HasForeignKey(sb => sb.ExpenseId),
        j =>
        {
          j.HasKey(t => new { t.ExpenseId, t.CostCenterId });
        }
       );

      modelBuilder.Entity<Receipt>()
       .HasMany(s => s.CostCenters)
       .WithMany(b => b.Receipts)
       .UsingEntity<ReceiptCostCenter>(
        j => j
            .HasOne(sb => sb.CostCenter)
            .WithMany(b => b.ReceiptCostCenters)
            .HasForeignKey(sb => sb.CostCenterId),
        j => j
            .HasOne(sb => sb.receipt)
            .WithMany(s => s.ReceiptCostCenters)
            .HasForeignKey(sb => sb.ReceiptId),
        j =>
        {
          j.HasKey(t => new { t.ReceiptId, t.CostCenterId });
        }
       );

      modelBuilder.Entity<Expense>()
        .HasOne(cp => cp.SubAccount)
        .WithMany(i => i.expenses)
        .HasForeignKey(cp => cp.SubAccountId)
        .OnDelete(DeleteBehavior.Restrict);


      modelBuilder.Entity<Receipt>()
       .HasOne(cp => cp.SubAccount)
       .WithMany(i => i.receipts)
       .HasForeignKey(cp => cp.SubAccountId)
       .OnDelete(DeleteBehavior.Restrict);

      #endregion

      // -------------------HumanResources Module-----------------------//

      #region HumanResources


      #endregion

    }


    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {

      foreach (var entry in ChangeTracker.Entries<IMustHaveTenant>().Where(e => e.State == EntityState.Added))
      {
        if (CurrentTenantId != null)
        {

          entry.Entity.TenantId = CurrentTenantId;

        }
      }
      foreach (var entry in ChangeTracker.Entries<IMustHaveTenant>().Where(e => e.State == EntityState.Modified))
      {
        if (CurrentTenantId != null)
        {

          entry.Entity.TenantId = CurrentTenantId;

        }
      }
      return base.SaveChangesAsync(cancellationToken);
    }

  }


}
