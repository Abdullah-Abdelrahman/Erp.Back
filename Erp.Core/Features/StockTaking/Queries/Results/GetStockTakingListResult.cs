namespace Erp.Core.Features.StockTaking.Queries.Results
{
  public class GetStockTakingListResult
  {
    public int Id { get; set; }

    public string Description { get; set; } = null!;

    public DateTime Date { get; set; }
  }
}
