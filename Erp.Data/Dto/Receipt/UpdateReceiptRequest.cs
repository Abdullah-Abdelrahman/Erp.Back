using System.ComponentModel.DataAnnotations;

namespace Erp.Data.Dto.Receipt
{
  public class UpdateReceiptRequest
  {
    [Required]
    public int Id { get; set; }

    [Required]
    [StringLength(20)]
    public string CodeNumber { get; set; } = string.Empty; // رقم الكود

    [Required]
    public decimal Amount { get; set; } // المبلغ

    [Required]
    [StringLength(10)]
    public string? Currency { get; set; }


    public DateTime? Date { get; set; }

    [StringLength(255)]
    public string Description { get; set; } = string.Empty; // الوصف

    public List<int> CategoriesIds { get; set; } = new List<int>();


    public int SubAccountId { get; set; } // الحساب الفرعي (اختياري)

    [Required]
    public int TreasuryId { get; set; } // الحساب الفرعي (اختياري)


    public bool IsMultiAccount { get; set; } = false; // متعدد الحسابات؟


    public List<MultiAccReceiptItemUpdateDto> multiAccReceiptItems { get; set; } = new List<MultiAccReceiptItemUpdateDto>();
    public bool Isfrequent { get; set; } = false;  //متكرر


    public bool WithCostCenter { get; set; } = false;




    public List<ReceiptCostCenterUpdateDto> ReceiptCostCenterDtos { get; set; } = new List<ReceiptCostCenterUpdateDto>();


  }

  public class ReceiptCostCenterUpdateDto
  {
    [Required]
    public int ReceiptId { get; set; }
    [Required]
    public int CostCenterId { get; set; }

    public decimal Percentage { get; set; } = 0.0M;

    public decimal Amount { get; set; } = 0.0M;


  }

  public class MultiAccReceiptItemUpdateDto
  {
    //لو عاوز تعمل واحد جديد ابعت نل
    public int? Id { get; set; }

    public int? SecondaryAccountId { get; set; }


    public int? CostCenterId { get; set; }

    public decimal Tax { get; set; } = 0.0M;

    public decimal Amount { get; set; } = 0.0M;

  }
}
