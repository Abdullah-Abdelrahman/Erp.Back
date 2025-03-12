using Erp.Core.Features.StockTaking.Queries.Results;
using MediatR;
using Name.Core.Bases;

namespace Erp.Core.Features.StockTaking.Queries.Models
{
  public class GetStockTakingByIdQuery : IRequest<Response<GetStockTakingByIdResult>>
  {
    public int Id { get; set; }

    public GetStockTakingByIdQuery(int id)
    {
      Id = id;
    }
  }
}
