using MediatR;
using Name.Core.Bases;
using System.ComponentModel.DataAnnotations;

namespace Erp.Core.Features.StockTaking.Commands.Models
{
  public class EditStockTakingCommand : IRequest<Response<string>>
  {
    [Required]
    public int StockTakingId { get; set; }


  }
}
