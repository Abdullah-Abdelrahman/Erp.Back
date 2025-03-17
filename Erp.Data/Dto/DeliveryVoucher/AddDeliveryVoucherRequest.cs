using System.Text.Json.Serialization;

namespace Erp.Data.Dto.DeliveryVoucher
{
  public class AddDeliveryVoucherRequest
  {
    public DateTime? DeliveryDate { get; set; }
    public string? Notes { get; set; }
    // Foreign Keys
    public int? WarehouseId { get; set; }

    // Foreign Key - Account
    public int? AccountId { get; set; }

    public int? CustomerId { get; set; }

    //مبيتعرض في الفرونت
    [JsonIgnore]
    public int? purchaseReturnId { get; set; }

    [JsonIgnore]
    public int? debitNoteId { get; set; }


    public List<DeliveryVoucherItemDT0> DeliveryVoucherItemDT0s { get; set; }
  }


  public class DeliveryVoucherItemDT0
  {

    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }
    public decimal TotalPrice => Quantity * UnitPrice;
    public int ProductId { get; set; }

  }
}
