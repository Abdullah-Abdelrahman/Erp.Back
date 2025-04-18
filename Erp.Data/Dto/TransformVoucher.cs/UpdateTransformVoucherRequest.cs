using System.ComponentModel.DataAnnotations;

namespace Erp.Data.Dto.TransformVoucher
{
  public class UpdateTransformVoucherRequest
  {
    [Required]
    public int TransformVoucherId { get; set; }
    public DateTime TransformDate { get; set; } = DateTime.UtcNow;
    public string? Notes { get; set; }

    // From to
    [Required]
    public int FromWarehouseId { get; set; }

    [Required]
    public int ToWarehouseId { get; set; }

    public List<TransformVoucherItemUpdateDT0> TransformVoucherItems { get; set; }
  }

  public class TransformVoucherItemUpdateDT0
  {
    public int? TransformVoucherItemId { get; set; }
    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }
    public decimal TotalPrice => Quantity * UnitPrice;
    public int ProductId { get; set; }

  }
}
