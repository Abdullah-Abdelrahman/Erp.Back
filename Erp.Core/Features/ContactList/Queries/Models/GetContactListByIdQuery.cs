using Erp.Core.Features.ContactList.Queries.Results;
using MediatR;
using Name.Core.Bases;

namespace Erp.Core.Features.ContactList.Queries.Models
{
  public class GetContactListByIdQuery : IRequest<Response<GetContactListByIdResult>>
  {
    public int Id { get; set; }

    public GetContactListByIdQuery(int id)
    {
      Id = id;
    }
  }
}
