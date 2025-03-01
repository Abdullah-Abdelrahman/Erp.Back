using System.ComponentModel.DataAnnotations;

namespace Erp.Data.Dto.Expense
{
  public class AddExpenseRequest
  {

    [Required]
    [StringLength(20)]
    public string CodeNumber { get; set; } = string.Empty; // رقم الكود

    [Required]
    public decimal Amount { get; set; } // المبلغ

    [Required]
    [StringLength(3)]
    public string? Currency { get; set; }


    public DateTime? Date { get; set; }

    [StringLength(255)]
    public string? Description { get; set; }

    public List<int> CategoriesIds { get; set; } = new List<int>();

    public int? SupplierId { get; set; } // المورد (اختياري)

    public int? SubAccountId { get; set; } // الحساب الفرعي (اختياري)

    [Required]
    public int TreasuryId { get; set; } // الحساب الفرعي (اختياري)


    public bool IsMultiAccount { get; set; } = false; // متعدد الحسابات؟


    public List<MultiAccExpenseItemDto> multiAccExpenseItems { get; set; } = new List<MultiAccExpenseItemDto>();
    public bool Isfrequent { get; set; } = false;  //متكرر


    public bool WithCostCenter { get; set; } = false;




    public List<ExpenseCostCenterDto> expenseCostCenterDtos { get; set; } = new List<ExpenseCostCenterDto>();



  }




  public class ExpenseCostCenterDto
  {
    [Required]
    public int CostCenterId { get; set; }

    public decimal Percentage { get; set; } = 0.0M;

    public decimal Amount { get; set; } = 0.0M;


  }

  public class MultiAccExpenseItemDto
  {
    public int? SecondaryAccountId { get; set; }


    public int? CostCenterId { get; set; }

    public decimal Tax { get; set; } = 0.0M;

    public decimal Amount { get; set; } = 0.0M;

  }

}
