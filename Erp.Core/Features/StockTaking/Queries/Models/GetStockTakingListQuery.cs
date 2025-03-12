using Erp.Core.Features.StockTaking.Queries.Results;
using MediatR;
using Name.Core.Bases;

namespace Erp.Core.Features.StockTaking.Queries.Models
{
  public class GetStockTakingListQuery : IRequest<Response<List<GetStockTakingListResult>>>
  {
  }
}
