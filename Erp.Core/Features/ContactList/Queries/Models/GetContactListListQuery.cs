using Erp.Core.Features.ContactList.Queries.Results;
using MediatR;
using Name.Core.Bases;

namespace Erp.Core.Features.ContactList.Queries.Models
{
  public class GetContactListListQuery : IRequest<Response<List<GetContactListByIdResult>>>
  {
  }
}
