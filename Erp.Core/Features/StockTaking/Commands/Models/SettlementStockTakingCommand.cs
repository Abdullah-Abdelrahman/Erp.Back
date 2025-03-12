using MediatR;
using Name.Core.Bases;

namespace Erp.Core.Features.StockTaking.Commands.Models
{
  public class SettlementStockTakingCommand : IRequest<Response<string>>
  {
  }
}
