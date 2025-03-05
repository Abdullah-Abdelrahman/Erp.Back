
using Erp.Data.Entities.InventoryModule;
using E = Erp.Data.Entities.InventoryModule;
namespace Erp.Core.Features.ProductAndService.Queries.Results
{
  public class GetServiceByIdResult
  {

    public int ServiceId { get; set; }
    public string ServiceName { get; set; } = null!;
    public string? Description { get; set; }
    public decimal PurchasePrice { get; set; }

    public decimal SellPrice { get; set; }

    public decimal LowestSellingPrice { get; set; }

    public ProductStatus Status { get; set; }
    public string? ImagePath { get; set; }


    public List<E.Category> categories { get; set; } = new List<E.Category>();

    //Image
    public byte[]? ImageFile { get; set; }
  }
}
