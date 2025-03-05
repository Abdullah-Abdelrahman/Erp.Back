using System.ComponentModel.DataAnnotations;

namespace Erp.Data.Dto.PriceList
{
  public class AddPriceListRequest
  {
    [Required]
    public string Name { get; set; } = null!;
    [Required]
    bool IsActive { get; set; } = true;

    public List<AddPriceListItemDTO> PriceListItemDtos { get; set; } = new List<AddPriceListItemDTO>();
  }


  public class AddPriceListItemDTO
  {

    [Required]
    public int ProductId { get; set; }


    [Required]
    public int PriceListId { get; set; }


    public decimal SellPrice { get; set; } = 0;


  }
}
