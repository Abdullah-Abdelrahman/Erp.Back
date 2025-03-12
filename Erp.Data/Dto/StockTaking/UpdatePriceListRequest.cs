using System.ComponentModel.DataAnnotations;

namespace Erp.Data.Dto.StockTaking
{
  public class UpdatePriceListRequest
  {
    [Required]
    public int StockTakingId { get; set; }
    [Required]
    public string Name { get; set; } = null!;
    [Required]
    public string Description { get; set; } = null!;
    [Required]
    public DateTime Date { get; set; }
    public List<UpdateStockTakingItemDTO> StockTakingItemDtos { get; set; } = new List<UpdateStockTakingItemDTO>();
  }

  public class UpdateStockTakingItemDTO
  {

    [Required]
    public int ProductId { get; set; }


    [Required]
    public int StockTakingId { get; set; }

    [Required]
    public int NumberIStock { get; set; }

    [Required]
    public int NumberInProgram { get; set; }

    //العجز والزياده
    public int DecreaseAndExcess { get; set; }


  }
}
