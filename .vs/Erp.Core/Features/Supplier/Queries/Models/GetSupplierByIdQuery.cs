using Erp.Core.Features.Supplier.Queries.Results;
using MediatR;
using Name.Core.Bases;

namespace Erp.Core.Features.Supplier.Queries.Models
{
  public class GetSupplierByIdQuery : IRequest<Response<GetSupplierByIdResult>>
  {
    public int Id { get; set; }

    public GetSupplierByIdQuery(int id)
    {
      Id = id;
    }
  }
}
