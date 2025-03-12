using Erp.Core.Features.CompanyModule.Queries.Results;
using MediatR;
using Name.Core.Bases;

namespace Erp.Core.Features.CompanyModule.Queries.Models
{
  public class GetActiveModulesListQuery : IRequest<Response<List<GetActiveModuleResult>>>
  {
  }
}
