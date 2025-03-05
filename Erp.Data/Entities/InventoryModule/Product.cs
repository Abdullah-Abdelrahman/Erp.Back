using Erp.Data.Entities.PurchasesModule;
using System.ComponentModel.DataAnnotations.Schema;

namespace Erp.Data.Entities.InventoryModule
{
  // مينفعش تحذف اي بردكت حصل عليه اي عمليه
  public class Product : ProductAndServiceBase
  {

    public int StockQuantity { get; set; }

    public int MinAmountBeforNotefy { get; set; } = 0;

    public int? SupplierId { get; set; }
    [ForeignKey("SupplierId")]
    public Supplier? Supplier { get; set; }


    public bool TrackInventory { get; set; } = false;
  }




}
