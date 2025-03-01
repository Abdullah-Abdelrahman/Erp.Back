using Erp.Data.Entities.AccountsModule;
using Erp.Data.Entities.Finance;
using System.ComponentModel.DataAnnotations.Schema;

namespace Erp.Data.Entities
{
  public class ExpenseCostCenter
  {
    public int ExpenseId { get; set; }
    [ForeignKey("ExpenseId")]
    public Expense Expense { get; set; }


    public int CostCenterId { get; set; }
    [ForeignKey("CostCenterId")]
    public CostCenter CostCenter { get; set; }


    public decimal Percentage { get; set; } = 0.0M;

    public decimal Amount { get; set; } = 0.0M;
  }
}
