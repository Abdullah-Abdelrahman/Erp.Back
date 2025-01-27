using MediatR;
using Name.Core.Bases;

namespace Erp.Core.Features.Account.Queries.Models
{
  public class GetAccountTypeByIdQuery : IRequest<Response<string>>
  {
    public int Id { get; set; }

    public GetAccountTypeByIdQuery(int id)
    {
      Id = id;
    }
  }
}
