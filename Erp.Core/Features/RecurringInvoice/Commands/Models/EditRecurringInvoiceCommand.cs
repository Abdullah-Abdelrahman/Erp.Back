using Erp.Data.Dto.RecurringInvoice;
using MediatR;
using Name.Core.Bases;

namespace Erp.Core.Features.RecurringInvoice.Commands.Models
{
  public class EditRecurringInvoiceCommand : UpdateRecurringInvoiceRequest, IRequest<Response<string>>
  {


  }
}
