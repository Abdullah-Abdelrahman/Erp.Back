using System.Text.Json.Serialization;

namespace Erp.Data.Dto.ReceivingVoucher
{
  public class AddReceivingVoucherRequest
  {
    public DateTime? ReceivingDate { get; set; }
    public string? Notes { get; set; }
    // Foreign Keys
    public int? WarehouseId { get; set; }

    // Foreign Key - Account
    public int? AccountId { get; set; }
    public int? SupplierId { get; set; }

    //مبيتعرض في الفرونت
    [JsonIgnore]
    public int? purchaseInvoiceId { get; set; }


    public List<ReceivingVoucherItemDT0> receivingVoucherItemDT0s { get; set; } = new List<ReceivingVoucherItemDT0>();
  }


  public class ReceivingVoucherItemDT0
  {
    public int ProductId { get; set; }
    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }
    public decimal TotalPrice => Quantity * UnitPrice;

  }
}
