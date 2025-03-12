
using E = Erp.Data.Entities.InventoryModule;
namespace Erp.Core.Features.PriceList.Queries.Results
{
  public class GetPriceListByIdResult
  {
    public int PriceListId { get; set; }
    public string PriceListName { get; set; } = null!;

    public bool IsActive { get; set; }

    public List<PriceListItemDto> PriceListItems { get; set; } = new List<PriceListItemDto>();
  }

  public class PriceListItemDto
  {
    public E.ProductAndServiceBase Product { get; set; }
    public decimal SellPrice { get; set; }
  }

}
