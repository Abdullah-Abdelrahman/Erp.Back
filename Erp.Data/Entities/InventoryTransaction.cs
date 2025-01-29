using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Erp.Data.Entities.InventoryModule;

namespace Erp.Data.Entities
{
  public class InventoryTransaction
  {
    [Key]
    public int InventoryTransactionID { get; set; }

    [Required]
    public int ProductID { get; set; }

    [ForeignKey(nameof(ProductID))]
    public Product Product { get; set; }

    [Required]
    public int WarehouseID { get; set; }

    [ForeignKey(nameof(WarehouseID))]
    public Warehouse Warehouse { get; set; }

    [Required]
    public TransactionType TransactionType { get; set; }

    [Required]
    public int Quantity { get; set; }

    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public DateTime TransactionDate { get; set; } = DateTime.UtcNow;
  }

  public enum TransactionType
  {
    PURCHASE,
    SALE,
    RETURN,
    TRANSFER,
    ADJUSTMENT
  }
}
