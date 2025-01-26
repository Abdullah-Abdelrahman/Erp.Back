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







    // -------------------Purchases Module-----------------------//

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







    // Not from invetory module

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
    }

  }


}
