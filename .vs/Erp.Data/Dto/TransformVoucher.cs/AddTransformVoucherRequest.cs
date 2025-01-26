namespace Erp.Data.Dto.TransformVoucher
{
  public class AddTransformVoucherRequest
  {
    public int TransformVoucherId { get; set; }
    public DateTime TransformDate { get; set; } = DateTime.UtcNow;
    public string? Notes { get; set; }

    // From to
    public int FromWarehouseId { get; set; }


    public int ToWarehouseId { get; set; }



    public List<TransformVoucherItemDT0> TransformVoucherItemDT0s { get; set; }
  }


  public class TransformVoucherItemDT0
  {

    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }
    public decimal TotalPrice => Quantity * UnitPrice;
    public int ProductId { get; set; }

  }
}
