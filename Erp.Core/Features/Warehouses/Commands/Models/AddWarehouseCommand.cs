using MediatR;
using Name.Core.Bases;

namespace Erp.Core.Features.Warehouses.Commands.Models
{
  public class AddWarehouseCommand : IRequest<Response<string>>
  {

    public string WarehouseName { get; set; } = null!;
    public string? Address { get; set; }

  }
}
