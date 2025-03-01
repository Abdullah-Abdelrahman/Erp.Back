using Erp.Data.Entities.InventoryModule;
using Erp.Data.Entities.PurchasesModule;
using E = Erp.Data.Entities.InventoryModule;
namespace Erp.Data.Dto.ReceivingVoucher
{
  public class GetReceivingVoucherByIdDto
  {
    public int ReceivingVoucherId { get; set; }
    public DateTime ReceivingDate { get; set; }
    public string? Notes { get; set; }


    public Warehouse Warehouse { get; set; }

    public Supplier Supplier { get; set; } = null!;


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
