using Erp.Data.Entities.AccountsModule;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Erp.Data.Entities.Finance
{
  public class MultiAccReceiptItem : IMustHaveTenant
  {
    [Key]
    public int Id { get; set; }

    public int receiptId { get; set; }
    [ForeignKey("receiptId")]
    public Receipt receipt { get; set; }


    public int SecondaryAccountId { get; set; }

    [ForeignKey("SecondaryAccountId")]
    public SecondaryAccount SecondaryAccount { get; set; } = null!;

    public int? CostCenterId { get; set; }
    [ForeignKey("CostCenterId")]
    public CostCenter? CostCenter { get; set; }

    public decimal Tax { get; set; } = 0.0M;

    public decimal Amount { get; set; } = 0.0M;
    public string TenantId { get; set; } = null!;
  }
}
