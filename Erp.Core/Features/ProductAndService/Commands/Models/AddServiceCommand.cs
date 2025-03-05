using Erp.Data.Dto.ProductAndService;
using MediatR;
using Name.Core.Bases;

namespace Erp.Core.Features.ProductAndService.Commands.Models
{
  public class AddServiceCommand : AddServiceRequest, IRequest<Response<string>>
  {
  }
}
