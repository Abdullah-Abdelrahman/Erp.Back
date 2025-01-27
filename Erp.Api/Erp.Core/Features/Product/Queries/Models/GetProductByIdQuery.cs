using Erp.Core.Features.Product.Queries.Results;
using MediatR;
using Name.Core.Bases;

namespace Erp.Core.Features.Product.Queries.Models
{
  public class GetProductByIdQuery : IRequest<Response<GetProductByIdResult>>
  {
    public int Id { get; set; }

    public GetProductByIdQuery(int id)
    {
      Id = id;
    }
  }
}
