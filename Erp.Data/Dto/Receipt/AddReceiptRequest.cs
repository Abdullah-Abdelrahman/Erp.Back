using System.ComponentModel.DataAnnotations;

namespace Erp.Data.Dto.Receipt
{
  public class AddReceiptRequest
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


    public int? SubAccountId { get; set; } // الحساب الفرعي (اختياري)

    [Required]
    public int TreasuryId { get; set; } // الحساب الفرعي (اختياري)


    public bool IsMultiAccount { get; set; } = false; // متعدد الحسابات؟


    public List<MultiAccReceiptItemDto> multiAccReceiptItems { get; set; } = new List<MultiAccReceiptItemDto>();
    public bool Isfrequent { get; set; } = false;  //متكرر


    public bool WithCostCenter { get; set; } = false;




    public List<ReceiptCostCenterDto> ReceiptCostCenterDtos { get; set; } = new List<ReceiptCostCenterDto>();



  }




  public class ReceiptCostCenterDto
  {
    [Required]
    public int CostCenterId { get; set; }

    public decimal Percentage { get; set; } = 0.0M;

    public decimal Amount { get; set; } = 0.0M;


  }

  public class MultiAccReceiptItemDto
  {
    public int? SecondaryAccountId { get; set; }


    public int? CostCenterId { get; set; }

    public decimal Tax { get; set; } = 0.0M;

    public decimal Amount { get; set; } = 0.0M;

  }

}
