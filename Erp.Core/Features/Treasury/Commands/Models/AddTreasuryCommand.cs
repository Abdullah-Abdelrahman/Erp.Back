using Erp.Data.Dto.Treasury;
using MediatR;
using Name.Core.Bases;

namespace Erp.Core.Features.Treasury.Commands.Models
{
  public class AddTreasuryCommand : AddTreasuryRequest, IRequest<Response<string>>
  {

  }
}
