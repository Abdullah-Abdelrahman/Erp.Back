using Erp.Core.Features.Account.Queries.Results;
using MediatR;
using Name.Core.Bases;

namespace Erp.Core.Features.Account.Queries.Models
{
  public class GetSecondaryAccountByIdQuery : IRequest<Response<GetSecondaryAccountByIdResult>>
  {
    public int Id { get; set; }

    public GetSecondaryAccountByIdQuery(int id)
    {
      Id = id;
    }
  }
}
