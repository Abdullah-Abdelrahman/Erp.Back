using Erp.Data.Dto.Treasury;
using MediatR;
using Name.Core.Bases;

namespace Erp.Core.Features.Treasury.Queries.Models
{
  public class GetTreasuryListQuery : IRequest<Response<List<GetTreasuryByIdDto>>>
  {
  }
}
