using MediatR;
using Name.Core.Bases;

namespace Erp.Core.Features.RecurringInvoice.Commands.Models
{
  public class DeleteRecurringInvoiceCommand : IRequest<Response<string>>
  {
    public int Id { get; set; }
    public DeleteRecurringInvoiceCommand(int id)
    {
      Id = id;
    }

  }
}
