using Erp.Core.Features.Account.Queries.Results;
using MediatR;
using Name.Core.Bases;

namespace Erp.Core.Features.Account.Queries.Models
{
  public class GetMainAccountsListQuery : IRequest<Response<List<GetPrimaryAccountByIdResult>>>
  {
  }
}
