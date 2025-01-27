using Erp.Core.Features.Account.Queries.Results;
using MediatR;
using Name.Core.Bases;

namespace Erp.Core.Features.Account.Queries.Models
{
  public class GetPrimaryAccountByIdQuery : IRequest<Response<GetPrimaryAccountByIdResult>>
  {
    public int Id { get; set; }

    public GetPrimaryAccountByIdQuery(int id)
    {
      Id = id;
    }
  }
}
