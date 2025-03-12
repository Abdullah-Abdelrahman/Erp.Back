using AutoMapper;
using Erp.Core.Features.CompanyModule.Queries.Models;
using Erp.Core.Features.CompanyModule.Queries.Results;
using Erp.Service.Abstracts.MainModule;
using MediatR;
using Name.Core.Bases;

namespace Erp.Core.Features.CompanyModule.Queries.Handlers
{
  public class CompanyModuleQueryHandler : ResponseHandler, IRequestHandler<GetActiveModulesListQuery, Response<List<GetActiveModuleResult>>>
  {
    #region Fields
    private readonly ICompanyModuleService _CompanyModuleService;
    private readonly IMapper _mapper;
    #endregion
    public CompanyModuleQueryHandler(ICompanyModuleService CompanyModuleService, IMapper mapper)
    {
      _mapper = mapper;
      _CompanyModuleService = CompanyModuleService;
    }

    public async Task<Response<List<GetActiveModuleResult>>> Handle(GetActiveModulesListQuery request, CancellationToken cancellationToken)
    {
      var CompanyModuleList = await _CompanyModuleService.GetActiveModulesListAsync();

      var CompanyModuleListMapper = _mapper.Map<List<GetActiveModuleResult>>(CompanyModuleList);

      return Success(CompanyModuleListMapper);
    }
  }
}
