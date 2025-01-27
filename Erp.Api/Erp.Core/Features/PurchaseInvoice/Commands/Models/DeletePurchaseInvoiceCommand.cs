using MediatR;
using Name.Core.Bases;

namespace Erp.Core.Features.PurchaseInvoice.Commands.Models
{
  public class DeletePurchaseInvoiceCommand : IRequest<Response<string>>
  {
    public int Id { get; set; }
    public DeletePurchaseInvoiceCommand(int id)
    {
      Id = id;
    }

  }
}
