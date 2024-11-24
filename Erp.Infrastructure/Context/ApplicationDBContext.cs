using Erp.Data.Entities;
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
        public DbSet<UserBase> userBases { get; set; }


        //Inventory Module
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Warehouse> Warehouses { get; set; }
        public DbSet<StockTransaction> StockTransactions { get; set; }
        public DbSet<DeliveryVoucher> DeliveryVouchers { get; set; }
        public DbSet<ReceivingVoucher> ReceivingVouchers { get; set; }
        public DbSet<PurchaseOrder> PurchaseOrders { get; set; }
        public DbSet<PurchaseOrderItem> PurchaseOrderItems { get; set; }
        public DbSet<SalesOrder> SalesOrders { get; set; }
        public DbSet<SalesOrderItem> SalesOrderItems { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Customer> Customers { get; set; }


        #endregion

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer("Data Source=DESKTOP-30J4B23\\SQLEXPRESS;Initial Catalog= OnlineGym ;Integrated Security=True;Connect Timeout=100;Trust Server Certificate=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // modelBuilder.UseEncryption(_encryptionProvider);
            modelBuilder.Entity<Product>()
                .HasMany(p => p.StockTransactions)
                .WithOne(st => st.Product)
                .HasForeignKey(st => st.ProductId);

            modelBuilder.Entity<StockTransaction>()
                .HasOne(st => st.Warehouse)
                .WithMany(w => w.StockTransactions)
                .HasForeignKey(st => st.WarehouseId);

            modelBuilder.Entity<PurchaseOrder>().
                HasMany(po => po.PurchaseOrderItems).
                WithOne(poi => poi.PurchaseOrder).
                HasForeignKey(poi => poi.PurchaseOrderId);

            modelBuilder.Entity<PurchaseOrderItem>()
                .HasOne(poi => poi.Product)
                .WithMany()
                .HasForeignKey(poi => poi.ProductId);

            modelBuilder.Entity<SalesOrder>().
                HasMany(so => so.SalesOrderItems).
                WithOne(soi => soi.SalesOrder).
                HasForeignKey(soi => soi.SalesOrderId);

            modelBuilder.Entity<SalesOrderItem>()
                .HasOne(soi => soi.Product)
                .WithMany()
                .HasForeignKey(soi => soi.ProductId);


        }

    }


}
