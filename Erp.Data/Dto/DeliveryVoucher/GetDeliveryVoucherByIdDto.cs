using Erp.Data.Entities.AccountsModule;
using Erp.Data.Entities.InventoryModule;
using E = Erp.Data.Entities.InventoryModule;
namespace Erp.Data.Dto.DeliveryVoucher
{
  public class GetDeliveryVoucherByIdDto
  {
    public int DeliveryVoucherId { get; set; }
    public DateTime DeliveryDate { get; set; } = DateTime.UtcNow;
    public string? Notes { get; set; }

    public Warehouse Warehouse { get; set; }

    public Account Account { get; set; } = null!;

    public VoucherStatus VoucherStatus { get; set; }

    public int? CustomerId { get; set; }

    public int JournalEntryID { get; set; }

    //لو معموله من خلال فاتوره مشتريات
    public int? purchaseReturnId { get; set; }

    public int? debitNoteId { get; set; }
    public List<DeliveryVoucherItemDto> deliveryVoucherItemDto { get; set; } = new List<DeliveryVoucherItemDto>();
  }

  public class DeliveryVoucherItemDto
  {

    public int DeliveryVoucherItemId { get; set; }
    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }
    public decimal TotalPrice { get; set; }
    public E.Product Product { get; set; } = null!;
  }
}
