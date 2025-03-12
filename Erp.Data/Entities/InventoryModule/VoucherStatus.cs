using System.ComponentModel.DataAnnotations;

namespace Erp.Data.Entities.InventoryModule
{
  public class VoucherStatus
  {
    [Key]
    public int Id { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }
  }
}
