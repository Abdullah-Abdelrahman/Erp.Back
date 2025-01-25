namespace Erp.Data.Dto.TransformVoucher
{
  public class UpdateTransformVoucherRequest
  {
    public int TransformVoucherId { get; set; }
    public DateTime TransformDate { get; set; } = DateTime.UtcNow;
    public string? Notes { get; set; }

    // From to
    public int FromWarehouseId { get; set; }


    public int ToWarehouseId { get; set; }

    public List<TransformVoucherItemUpdateDT0> TransformVoucherItems { get; set; }
  }

  public class TransformVoucherItemUpdateDT0
  {
    public int TransformVoucherItemId { get; set; }
    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }
    public decimal TotalPrice => Quantity * UnitPrice;
    public int ProductId { get; set; }

  }
}
