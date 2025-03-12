using Erp.Core.Features.PriceList.Queries.Results;
using MediatR;
using Name.Core.Bases;

namespace Erp.Core.Features.PriceList.Queries.Models
{
  public class GetPriceListByIdQuery : IRequest<Response<GetPriceListByIdResult>>
  {
    public int Id { get; set; }

    public GetPriceListByIdQuery(int id)
    {
      Id = id;
    }
  }
}
