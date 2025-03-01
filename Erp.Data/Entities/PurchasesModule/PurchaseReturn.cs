using System.ComponentModel.DataAnnotations.Schema;

namespace Erp.Data.Entities.PurchasesModule
{


  public class PurchaseReturn : IMustHaveTenant
  {
    public int PurchaseReturnId { get; set; }
    public DateTime ReturnDate { get; set; } = DateTime.UtcNow;
    public decimal TotalAmount { get; set; }
    public string? Notes { get; set; }

    // Navigation Properties
    public int supplierId { get; set; }
    [ForeignKey("supplierId")]
    public Supplier supplier { get; set; }

    public ICollection<PurchaseReturnItem> Items { get; set; } = new List<PurchaseReturnItem>();

    public string TenantId { get; set; } = null!;

  }

}
