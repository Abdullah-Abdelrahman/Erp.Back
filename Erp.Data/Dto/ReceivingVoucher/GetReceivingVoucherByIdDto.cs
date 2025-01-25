using Erp.Data.Entities;

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
    public Product Product { get; set; } = null!;
  }

}
