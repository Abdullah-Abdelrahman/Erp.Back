using Erp.Core.Features.Warehouses.Queries.Results;
using MediatR;
using Name.Core.Bases;

namespace Erp.Core.Features.Warehouses.Queries.Models
{
  public class GetWarehouseByIdQuery : IRequest<Response<GetWarehouseByIdResult>>
  {
    public int Id { get; set; }

    public GetWarehouseByIdQuery(int id)
    {
      Id = id;
    }
  }
}
