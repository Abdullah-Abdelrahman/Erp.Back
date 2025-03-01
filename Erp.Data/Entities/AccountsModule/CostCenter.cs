using Erp.Data.Entities.Finance;
using System.ComponentModel.DataAnnotations.Schema;

namespace Erp.Data.Entities.AccountsModule
{

  public class CostCenter : IMustHaveTenant
  {
    public int CostCenterId { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;


    public int? ParentCostCenterID { get; set; }
    [ForeignKey("ParentCostCenterID")]
    public CostCenter? ParentCostCenter { get; set; }


    public ICollection<Expense> Expenses { get; set; } = new HashSet<Expense>();

    public ICollection<ExpenseCostCenter> ExpenseCostCenters { get; set; } = new HashSet<ExpenseCostCenter>();


    public ICollection<Receipt> Receipts { get; set; } = new HashSet<Receipt>();

    public ICollection<ReceiptCostCenter> ReceiptCostCenters { get; set; } = new HashSet<ReceiptCostCenter>();

    public string TenantId { get; set; } = null!;

  }


}
