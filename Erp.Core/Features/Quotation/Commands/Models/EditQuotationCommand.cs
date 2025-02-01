using Erp.Data.Dto.Quotation;
using MediatR;
using Name.Core.Bases;

namespace Erp.Core.Features.Quotation.Commands.Models
{
  public class EditQuotationCommand : UpdateQuotationRequest, IRequest<Response<string>>
  {


  }
}
