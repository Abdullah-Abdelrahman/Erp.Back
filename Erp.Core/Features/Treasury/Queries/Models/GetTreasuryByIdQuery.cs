using Erp.Data.Dto.Treasury;
using MediatR;
using Name.Core.Bases;

namespace Erp.Core.Features.Treasury.Queries.Models
{
  public class GetTreasuryByIdQuery : IRequest<Response<GetTreasuryByIdDto>>
  {
    public int Id { get; set; }

    public GetTreasuryByIdQuery(int id)
    {
      Id = id;
    }
  }
}
