using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Name.Data.Entities;

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
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Attendance> Attendances { get; set; }
        public DbSet<BankAccount> BankAccounts { get; set; }
        public DbSet<BankTransaction> BankTransactions { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<CompanyModule> CompanyModules { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Inventory> Inventories { get; set; }
        public DbSet<InventoryTransaction> InventoryTransactions { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<InvoiceItem> InvoiceItems { get; set; }
        public DbSet<JobType> JobTypes { get; set; }
        public DbSet<JournalEntry> JournalEntries { get; set; }
        public DbSet<JournalEntryDetail> JournalEntryDetails { get; set; }
        public DbSet<Leave> Leaves { get; set; }
        public DbSet<Module> Modules { get; set; }
        public DbSet<Payroll> Payrolls { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<TransactionDetail> TransactionDetails { get; set; }
        public DbSet<UserBase> Users { get; set; }
        public DbSet<Vendor> Vendors { get; set; }
        public DbSet<Warehouse> Warehouses { get; set; }



        #endregion

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer("Data Source=DESKTOP-30J4B23\\SQLEXPRESS;Initial Catalog= OnlineGym ;Integrated Security=True;Connect Timeout=100;Trust Server Certificate=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // modelBuilder.UseEncryption(_encryptionProvider);


        }

    }


}
