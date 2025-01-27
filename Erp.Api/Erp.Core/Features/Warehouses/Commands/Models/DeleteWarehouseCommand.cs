using MediatR;
using Name.Core.Bases;

namespace Erp.Core.Features.Warehouses.Commands.Models
{
  public class DeleteWarehouseCommand : IRequest<Response<string>>
  {
    public int Id { get; set; }
    public DeleteWarehouseCommand(int id)
    {
      Id = id;
    }
  }
}
