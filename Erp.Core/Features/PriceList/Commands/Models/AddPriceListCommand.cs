using MediatR;
using Name.Core.Bases;
using System.ComponentModel.DataAnnotations;

namespace Erp.Core.Features.PriceList.Commands.Models
{
  public class AddPriceListCommand : IRequest<Response<string>>
  {
    [Required]
    public string PriceListName { get; set; } = null!;

    [Required]
    public bool IsActive { get; set; }

  }
}
