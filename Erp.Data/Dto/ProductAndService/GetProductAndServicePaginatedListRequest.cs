using Erp.Data.Entities.InventoryModule;

namespace Erp.Data.Dto.ProductAndService
{
  public class GetProductAndServicePaginatedListRequest
  {
    public int Id { get; set; }

    public string Name { get; set; } = null!;
    public string Description { get; set; } = string.Empty;
    public string InternalNotes { get; set; } = string.Empty;

    public decimal PurchasePrice { get; set; }
    public decimal SellPrice { get; set; }

    public decimal LowestSellingPrice { get; set; }


    public ProductStatus Status { get; set; }

    public ICollection<int> CategoriesIds { get; set; }

    public string? ImagePath { get; set; }


    public ProductOrService ProductOrService { get; set; }

    //for product only

    //if null then it is Service
    public int? StockQuantity { get; set; }
    //if null then it is Service
    public int? MinAmountBeforNotefy { get; set; }

    public int? SupplierId { get; set; }

    public GetProductAndServicePaginatedListRequest()
    {

    }

  }

  public enum ProductOrService
  {
    Product,
    Service,
  }
}
