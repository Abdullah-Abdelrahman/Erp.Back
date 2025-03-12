using MediatR;
using Name.Core.Bases;
using System.ComponentModel.DataAnnotations;

namespace Erp.Core.Features.StockTaking.Commands.Models
{
  public class AddStockTakingCommand : IRequest<Response<string>>
  {

    public string Description { get; set; } = null!;
    [Required]
    public DateTime Date { get; set; }


  }
}
