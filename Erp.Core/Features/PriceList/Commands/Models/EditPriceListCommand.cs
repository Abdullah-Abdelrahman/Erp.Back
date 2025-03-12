using MediatR;
using Microsoft.AspNetCore.Http;
using Name.Core.Bases;
using System.ComponentModel.DataAnnotations;

namespace Erp.Core.Features.PriceList.Commands.Models
{
  public class EditPriceListCommand : IRequest<Response<string>>
  {
    [Required]
    public int PriceListId { get; set; }

    [Required]
    public string PriceListName { get; set; } = null!;
    public int? MainPriceListId { get; set; }

    public IFormFile? ImageFile { get; set; }
  }
}
