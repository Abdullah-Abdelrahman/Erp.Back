namespace Erp.Data.Dto.ReceivingVoucher
{
  public class UpdateReceivingVoucherRequest
  {
    public int ReceivingVoucherId { get; set; }
    public DateTime ReceivingDate { get; set; }
    public string? Notes { get; set; }

    // Foreign Keys
    public int WarehouseId { get; set; }


    // Foreign Key - acc
    public int AccountId { get; set; }

    public List<ReceivingVoucherItemUpdateDT0> receivingVoucherItems { get; set; }
  }

  public class ReceivingVoucherItemUpdateDT0
  {
    public int? ReceivingVoucherItemId { get; set; }
    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }
    public decimal TotalPrice => Quantity * UnitPrice;
    public int ProductId { get; set; }

  }
}
