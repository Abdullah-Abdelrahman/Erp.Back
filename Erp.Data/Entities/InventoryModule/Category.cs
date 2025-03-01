using System.ComponentModel.DataAnnotations.Schema;

namespace Erp.Data.Entities.InventoryModule
{
  public class Category : IMustHaveTenant
  {
    public int CategoryId { get; set; }
    public string CategoryName { get; set; } = null!;

    public int? MainCategoryId { get; set; }

    [ForeignKey("MainCategoryId")]
    public Category? MainCategory { get; set; }
    public string? ImagePath { get; set; }

    [NotMapped]
    public byte[]? ImageFile { get; set; }


    // Navigation Property
    public ICollection<Product> Products { get; set; } = new List<Product>();
    public string TenantId { get; set; } = null!;
  }

}
