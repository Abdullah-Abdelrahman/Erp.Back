using System.ComponentModel.DataAnnotations;

namespace Erp.Data.Entities.InventoryModule
{
  public class PriceList : IMustHaveTenant
  {
    public int Id { get; set; }
    [Required]
    public string Name { get; set; } = null!;
    [Required]
    bool IsActive { get; set; } = true;

    public ICollection<PriceListItem> priceListItems { get; set; } = new List<PriceListItem>();


    public string TenantId { get; set; } = null!;
  }


}
