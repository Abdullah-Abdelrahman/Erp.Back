namespace Erp.Data.Entities.InventoryModule
{
  public class Category
  {
    public int CategoryId { get; set; }
    public string CategoryName { get; set; } = null!;

    // Navigation Property
    public ICollection<Product> Products { get; set; } = new List<Product>();
  }

}
