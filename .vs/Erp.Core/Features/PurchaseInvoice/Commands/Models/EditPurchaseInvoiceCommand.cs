using Erp.Data.Dto.PurchaseInvoice;
using MediatR;
using Name.Core.Bases;

namespace Erp.Core.Features.PurchaseInvoice.Commands.Models
{
  public class EditPurchaseInvoiceCommand : UpdatePurchaseInvoiceRequest, IRequest<Response<string>>
  {


  }
}
