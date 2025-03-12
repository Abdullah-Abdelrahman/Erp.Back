using System.ComponentModel.DataAnnotations;

namespace Erp.Data.Dto.StockTaking
{
  public class AddStockTakingRequest
  {
    [Required]
    public string Name { get; set; } = null!;
    [Required]
    public string Description { get; set; } = null!;
    [Required]
    public DateTime Date { get; set; }
    public List<AddStockTakingItemDTO> StockTakingItemDtos { get; set; } = new List<AddStockTakingItemDTO>();
  }


  public class AddStockTakingItemDTO
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
