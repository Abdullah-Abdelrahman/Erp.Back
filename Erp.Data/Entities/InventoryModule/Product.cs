using Erp.Data.Entities.PurchasesModule;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Erp.Data.Entities.InventoryModule
{
  public class Product : IMustHaveTenant
  {
    public int ProductId { get; set; }
    [Required]
    public string ProductName { get; set; } = null!;
    public string Description { get; set; } = string.Empty;
    public string InternalNotes { get; set; } = string.Empty;

    public decimal PurchasePrice { get; set; }
    public decimal SellPrice { get; set; }

    public decimal LowestSellingPrice { get; set; }
    public int StockQuantity { get; set; }

    public int MinAmountBeforNotefy { get; set; } = 0;


    public ProductOrService ProductOrService { get; set; } = ProductOrService.Product;
    public int? SupplierId { get; set; }
    [ForeignKey("SupplierId")]
    public Supplier? Supplier { get; set; }
    public bool isActive { get; set; }
    public string? ImagePath { get; set; }

    [NotMapped]
    public byte[]? ImageFile { get; set; }


    public ICollection<Category> categories { get; set; } = new List<Category>();

    // Navigation Property
    public ICollection<StockTransaction> StockTransactions { get; set; } = new List<StockTransaction>();

    public string TenantId { get; set; } = null!;

  }


  public enum ProductOrService
  {
    Product,
    Service
  }
}
