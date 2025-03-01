using Erp.Data.Entities.AccountsModule;
using Erp.Data.Entities.Finance;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Erp.Data.Entities
{
  public class MultiAccExpenseItem : IMustHaveTenant
  {
    [Key]
    public int Id { get; set; }

    public int ExpenseId { get; set; }
    [ForeignKey("ExpenseId")]
    public Expense Expense { get; set; }


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
