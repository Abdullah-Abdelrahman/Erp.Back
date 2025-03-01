using Erp.Core.Features.Company.Queries.Results;
using MediatR;
using Name.Core.Bases;

namespace Erp.Core.Features.Company.Queries.Models
{
  public class GetCompanyListQuery : IRequest<Response<List<GetCompanyByIdResult>>>
  {
  }
}
