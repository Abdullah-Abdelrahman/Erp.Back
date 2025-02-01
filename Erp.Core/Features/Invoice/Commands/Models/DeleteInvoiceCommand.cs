using MediatR;
using Name.Core.Bases;

namespace Erp.Core.Features.Invoice.Commands.Models
{
  public class DeleteInvoiceCommand : IRequest<Response<string>>
  {
    public int Id { get; set; }
    public DeleteInvoiceCommand(int id)
    {
      Id = id;
    }

  }
}
