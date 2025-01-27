using Erp.Core.Features.Warehouses.Queries.Results;
using MediatR;
using Name.Core.Bases;

namespace Erp.Core.Features.Warehouses.Queries.Models
{
  public class GetWarehouseListQuery : IRequest<Response<List<GetWarehouseByIdResult>>>
  {
  }
}
