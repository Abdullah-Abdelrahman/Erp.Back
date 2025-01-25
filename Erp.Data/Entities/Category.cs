using Name.Data.Entities;

namespace Erp.Data.Entities
{
  public class Category
  {
    public int CategoryId { get; set; }
    public string CategoryName { get; set; } = null!;

    // Navigation Property
    public ICollection<Product> Products { get; set; } = new List<Product>();
  }

}
