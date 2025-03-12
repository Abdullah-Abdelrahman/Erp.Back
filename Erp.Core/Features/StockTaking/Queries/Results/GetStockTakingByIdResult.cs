namespace Erp.Core.Features.StockTaking.Queries.Results
{
  public class GetStockTakingByIdResult
  {
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public DateTime Date { get; set; }

    public List<StockTakingItemDto> StockTakingItems { get; set; } = new List<StockTakingItemDto>();
  }

  public class StockTakingItemDto
  {

    public int ProductId { get; set; }



    public int StockTakingId { get; set; }


    public int NumberIStock { get; set; }


    public int NumberInProgram { get; set; }

    //العجز والزياده
    public int DecreaseAndExcess { get; set; }
  }

}
