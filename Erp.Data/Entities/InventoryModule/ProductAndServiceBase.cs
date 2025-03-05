using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Erp.Data.Entities.InventoryModule
{
  public class ProductAndServiceBase : IMustHaveTenant
  {
    [Key]
    public int ProductId { get; set; }
    [Required]
    public string Name { get; set; } = null!;
    public string Description { get; set; } = string.Empty;
    public string InternalNotes { get; set; } = string.Empty;

    public decimal PurchasePrice { get; set; }
    public decimal SellPrice { get; set; }

    public decimal LowestSellingPrice { get; set; }


    public ProductStatus Status { get; set; } = ProductStatus.Active;


    public string? ImagePath { get; set; }

    [NotMapped]
    public byte[]? ImageFile { get; set; }


    public ICollection<Category> categories { get; set; } = new List<Category>();

    // Navigation Property
    public ICollection<StockTransaction> StockTransactions { get; set; } = new List<StockTransaction>();

    public string TenantId { get; set; } = null!;
  }


  public enum ProductStatus
  {
    Active,
    InActive,
    //مش هينفع يتضاف لاي فاتوره ولا تقدر تعمل عليه اي حركه و مينفعش تشوف التقارير السابقه بتاعته

    Suspended
    //موقوف
    //مش هينفع يتضاف لاي فاتوره ولا تقدر تعمل عليه اي حركه بس ممكن تشوف التقارير السابقه بتاعته
  }
}
