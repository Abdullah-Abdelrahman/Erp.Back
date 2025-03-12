namespace Erp.Core.Features.PriceList.Queries.Results
{
  public class GetPriceListListResult
  {
    public int PriceListId { get; set; }
    public string PriceListName { get; set; } = null!;
    public int NumberOfProducts { get; set; }
    public bool IsActive { get; set; }
  }
}
