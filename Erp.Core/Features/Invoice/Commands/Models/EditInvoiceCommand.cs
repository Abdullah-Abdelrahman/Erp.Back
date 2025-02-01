using Erp.Data.Dto.Invoice;
using MediatR;
using Name.Core.Bases;

namespace Erp.Core.Features.Invoice.Commands.Models
{
  public class EditInvoiceCommand : UpdateInvoiceRequest, IRequest<Response<string>>
  {


  }
}
