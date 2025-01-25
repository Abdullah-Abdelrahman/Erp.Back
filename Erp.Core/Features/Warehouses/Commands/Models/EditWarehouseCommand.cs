using MediatR;
using Name.Core.Bases;

namespace Erp.Core.Features.Warehouses.Commands.Models
{
  public class EditWarehouseCommand : IRequest<Response<string>>
  {
    public int WarehouseId { get; set; }
    public string WarehouseName { get; set; } = null!;
    public string? Address { get; set; }
  }
}
