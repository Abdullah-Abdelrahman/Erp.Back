using MediatR;
using Name.Core.Bases;

namespace Erp.Core.Features.Payment.Commands.Models
{
  public class DeleteSupplierPaymentCommand : IRequest<Response<string>>
  {
    public int Id { get; set; }
    public DeleteSupplierPaymentCommand(int id)
    {
      Id = id;
    }
  }
}
