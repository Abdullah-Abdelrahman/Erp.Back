using Erp.Core.Features.Account.Queries.Results;
using MediatR;
using Name.Core.Bases;

namespace Erp.Core.Features.Account.Queries.Models
{
  public class GetPrimaryAccountsListQuery : IRequest<Response<List<GetPrimaryAccountByIdResult>>>
  {
  }
}
