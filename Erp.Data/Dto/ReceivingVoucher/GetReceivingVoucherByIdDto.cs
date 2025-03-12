using Erp.Data.Entities.AccountsModule;
using Erp.Data.Entities.InventoryModule;
using E = Erp.Data.Entities.InventoryModule;
namespace Erp.Data.Dto.ReceivingVoucher
{
  public class GetReceivingVoucherByIdDto
  {
    public int ReceivingVoucherId { get; set; }
    public DateTime ReceivingDate { get; set; }
    public string? Notes { get; set; }


    public Warehouse Warehouse { get; set; }

    public Account Account { get; set; } = null!;

    public VoucherStatus VoucherStatus { get; set; }
    public List<ReceivingVoucherItemDto> receivingVoucherItemsDto { get; set; } = new List<ReceivingVoucherItemDto>();
  }

  public class ReceivingVoucherItemDto
  {

    public int ReceivingVoucherItemId { get; set; }
    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }
    public decimal TotalPrice { get; set; }
    public E.Product Product { get; set; } = null!;
  }

}
