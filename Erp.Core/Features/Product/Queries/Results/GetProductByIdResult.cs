using E = Erp.Data.Entities.InventoryModule;
namespace Erp.Core.Features.Product.Queries.Results
{
  public class GetProductByIdResult
  {
    public int ProductId { get; set; }
    public string ProductName { get; set; } = null!;
    public string? Description { get; set; }
    public decimal PurchasePrice { get; set; }

    public decimal SellPrice { get; set; }

    public decimal LowestSellingPrice { get; set; }
    public int StockQuantity { get; set; }
    public int MinAmountBeforNotefy { get; set; }
    public bool isActive { get; set; }
    public string? ImagePath { get; set; }


    public List<E.Category> categories { get; set; } = new List<E.Category>();

    //Image
    public byte[]? ImageFile { get; set; }

  }
}
