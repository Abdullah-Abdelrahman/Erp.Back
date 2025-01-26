using Erp.Core.Features.Supplier.Queries.Results;
using MediatR;
using Name.Core.Bases;

namespace Erp.Core.Features.Supplier.Queries.Models
{
  public class GetSupplierListQuery : IRequest<Response<List<GetSupplierByIdResult>>>
  {
  }
}
