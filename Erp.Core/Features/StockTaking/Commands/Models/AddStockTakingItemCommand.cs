using MediatR;
using Name.Core.Bases;
using System.ComponentModel.DataAnnotations;

namespace Erp.Core.Features.StockTaking.Commands.Models
{
  public class AddStockTakingItemCommand : IRequest<Response<string>>
  {
    [Required]
    public int StockTakingId { get; set; }

    [Required]
    public int ProductId { get; set; }

    [Required]
    public int NumberIStock { get; set; }

    public int NumberInProgram { get; set; }

    //العجز والزياده
    public int DecreaseAndExcess { get; set; }

  }
}
