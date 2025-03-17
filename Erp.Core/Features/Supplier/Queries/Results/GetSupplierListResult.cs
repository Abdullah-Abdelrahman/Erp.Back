namespace Erp.Core.Features.Supplier.Queries.Results
{
  public class GetSupplierListResult
  {
    public int SupplierId { get; set; }
    public string SupplierName { get; set; } = null!;

    public int AccountId { get; set; }
  }
}
