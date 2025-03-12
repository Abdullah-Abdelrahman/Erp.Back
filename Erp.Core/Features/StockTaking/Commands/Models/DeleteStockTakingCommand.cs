using MediatR;
using Name.Core.Bases;

namespace Erp.Core.Features.StockTaking.Commands.Models
{
  public class DeleteStockTakingCommand : IRequest<Response<string>>
  {
    public int StockTakingId { get; set; }

    public DeleteStockTakingCommand(int id)
    {
      StockTakingId = id;
    }
  }
}
