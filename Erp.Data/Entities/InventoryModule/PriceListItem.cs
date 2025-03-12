using System.ComponentModel.DataAnnotations.Schema;

namespace Erp.Data.Entities.InventoryModule
{
  public class PriceListItem : IMustHaveTenant
  {

    public int ProductId { get; set; }

    [ForeignKey("ProductId")]
    public ProductAndServiceBase Product { get; set; } = null!;

    public int PriceListId { get; set; }

    [ForeignKey("PriceListId")]
    public PriceList PriceList { get; set; } = null!;


    public decimal SellPrice { get; set; }

    public string TenantId { get; set; } = null!;
  }
}
