using Erp.Data.Entities.AccountsModule;
using System.ComponentModel.DataAnnotations.Schema;

namespace Erp.Data.Entities.Finance
{
  public class ReceiptCostCenter
  {
    public int ReceiptId { get; set; }
    [ForeignKey("ReceiptId")]
    public Receipt receipt { get; set; }


    public int CostCenterId { get; set; }
    [ForeignKey("CostCenterId")]
    public CostCenter CostCenter { get; set; }


    public decimal Percentage { get; set; } = 0.0M;

    public decimal Amount { get; set; } = 0.0M;
  }
}
