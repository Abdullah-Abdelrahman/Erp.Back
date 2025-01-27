using MediatR;
using Name.Core.Bases;

namespace Erp.Core.Features.Supplier.Commands.Models
{
  public class DeleteSupplierCommand : IRequest<Response<string>>
  {
    public int Id { get; set; }
    public DeleteSupplierCommand(int id)
    {
      Id = id;
    }
  }
}
