using Erp.Core.Features.ProductAndService.Queries.Results;
using MediatR;
using Name.Core.Bases;

namespace Erp.Core.Features.ProductAndService.Queries.Models
{
  public class GetServiceByIdQuery : IRequest<Response<GetServiceByIdResult>>
  {
    public int Id { get; set; }

    public GetServiceByIdQuery(int id)
    {
      Id = id;
    }
  }
}
