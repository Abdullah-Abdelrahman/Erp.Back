using System.ComponentModel.DataAnnotations.Schema;

namespace Erp.Data.Entities.InventoryModule
{
  public class StockTakingItem : IMustHaveTenant
  {

    public int StockTakingId { get; set; }

    [ForeignKey("StockTakingId")]
    public StockTaking StockTaking { get; set; } = null!;


    public int ProductId { get; set; }

    [ForeignKey("ProductId")]
    public Product Product { get; set; } = null!;


    public int NumberIStock { get; set; }

    public int NumberInProgram { get; set; }

    //العجز والزياده
    public int DecreaseAndExcess { get; set; }
    public string TenantId { get; set; } = null!;
  }
}
