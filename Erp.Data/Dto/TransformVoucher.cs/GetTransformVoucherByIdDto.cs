using Erp.Data.Entities.InventoryModule;

namespace Erp.Data.Dto.TransformVoucher.cs
{
  public class GetTransformVoucherByIdDto
  {
    public int TransformVoucherId { get; set; }
    public DateTime TransformDate { get; set; } = DateTime.UtcNow;
    public string? Notes { get; set; }


    public Warehouse FromWarehouse { get; set; }


    public Warehouse ToWarehouse { get; set; }
    public List<TransformVoucherItemDto> transformVoucherItemsDto { get; set; } = new List<TransformVoucherItemDto>();
  }

  public class TransformVoucherItemDto
  {

    public int TransformVoucherItemId { get; set; }
    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }
    public decimal TotalPrice { get; set; }
    public Product Product { get; set; } = null!;
  }
}
