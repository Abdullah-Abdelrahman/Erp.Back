using MediatR;
using Name.Core.Bases;
using System.ComponentModel.DataAnnotations;

namespace Erp.Core.Features.PriceList.Commands.Models
{
  public class AddPriceListItemCommand : IRequest<Response<string>>
  {
    [Required]
    public int PriceListId { get; set; }

    [Required]
    public int ProductId { get; set; }

    [Required]
    public decimal SellPrice { get; set; }

  }
}
