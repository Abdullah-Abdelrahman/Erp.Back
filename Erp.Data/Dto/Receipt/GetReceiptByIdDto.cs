namespace Erp.Data.Dto.Receipt
{
  public class GetReceiptByIdDto
  {

    public int Id { get; set; }

    public string CodeNumber { get; set; }

    public decimal Amount { get; set; }


    public string? Currency { get; set; }


    public DateTime? Date { get; set; }


    public string Description { get; set; }

    public List<int> CategoriesIds { get; set; }


    public int SubAccountId { get; set; }


    public int TreasuryId { get; set; }


    public bool IsMultiAccount { get; set; }


    public List<MultiAccReceiptItemGetDto> multiAccReceiptItems { get; set; } = new List<MultiAccReceiptItemGetDto>();
    public bool Isfrequent { get; set; } = false;


    public bool WithCostCenter { get; set; } = false;




    public List<ReceiptCostCenterGetDto> ReceiptCostCenterDtos { get; set; } = new List<ReceiptCostCenterGetDto>();

  }

  public class ReceiptCostCenterGetDto
  {

    public int ReceiptId { get; set; }

    public int CostCenterId { get; set; }

    public decimal Percentage { get; set; }

    public decimal Amount { get; set; }


  }

  public class MultiAccReceiptItemGetDto
  {

    public int Id { get; set; }

    public int SecondaryAccountId { get; set; }


    public int? CostCenterId { get; set; }

    public decimal Tax { get; set; }

    public decimal Amount { get; set; }

  }

}
