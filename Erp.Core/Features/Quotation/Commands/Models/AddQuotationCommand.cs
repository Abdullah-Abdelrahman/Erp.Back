using Erp.Data.Dto.Quotation;
using MediatR;
using Name.Core.Bases;

namespace Erp.Core.Features.Quotation.Commands.Models
{
  public class AddQuotationCommand : AddQuotationRequest, IRequest<Response<string>>
  {

  }
}
