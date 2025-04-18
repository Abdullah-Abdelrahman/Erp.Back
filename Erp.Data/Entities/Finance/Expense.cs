using Erp.Data.Entities.AccountsModule;
using Erp.Data.Entities.PurchasesModule;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Erp.Data.Entities.Finance
{
  //سند صرف
  public class Expense : IMustHaveTenant
  {

    [Key]
    public int Id { get; set; }

    [Required]
    [StringLength(20)]
    public string CodeNumber { get; set; } = string.Empty; // رقم الكود

    [Required]
    public decimal Amount { get; set; } // المبلغ

    [Required]
    [StringLength(3)]
    public string? Currency { get; set; }

    [Required]
    public DateTime Date { get; set; } = DateTime.Now;

    [StringLength(255)]
    public string Description { get; set; } = string.Empty; // الوصف

    public ICollection<ExpenseCategory> expenseCategories { get; set; } = new List<ExpenseCategory>();

    public int? SupplierId { get; set; } // المورد (اختياري)

    [ForeignKey(nameof(SupplierId))]
    public Supplier? Supplier { get; set; } // المورد المرتبط بالنفقة

    //[Required]
    //public int MainAccountId { get; set; } // الحساب الرئيسي

    //[ForeignKey(nameof(MainAccountId))]
    //public Account MainAccount { get; set; } = null!;

    public int SubAccountId { get; set; } // الحساب الفرعي (اختياري)

    [ForeignKey(nameof(SubAccountId))]
    public Account SubAccount { get; set; }


    public int TreasuryId { get; set; } // الحساب الفرعي (اختياري)

    [ForeignKey("TreasuryId")]
    public Treasury Treasury { get; set; } = null!;

    public bool IsMultiAccount { get; set; } = false; // متعدد الحسابات؟


    public ICollection<MultiAccExpenseItem> multiAccExpenseItems { get; set; } = new List<MultiAccExpenseItem>();

    public bool Isfrequent { get; set; } = false;  //متكرر


    public bool WithCostCenter { get; set; } = false;
    public ICollection<CostCenter> CostCenters { get; set; } = new List<CostCenter>();

    public ICollection<ExpenseCostCenter> ExpenseCostCenters { get; set; } = new List<ExpenseCostCenter>();





    public string TenantId { get; set; } = null!;

  }
}
