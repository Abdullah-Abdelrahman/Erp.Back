using AutoMapper;
using Erp.Core.Features.EmploymentLevel.Queries.Models;
using Erp.Core.Features.EmploymentLevel.Queries.Results;
using Erp.Service.Abstracts.HumanResources.OrganizationalStructure;
using MediatR;
using Name.Core.Bases;

namespace Erp.Core.Features.EmploymentLevel.Queries.Handlers
{
  public class EmploymentLevelQueryHandler : ResponseHandler, IRequestHandler<GetEmploymentLevelByIdQuery, Response<GetEmploymentLevelByIdResult>>, IRequestHandler<GetEmploymentLevelListQuery, Response<List<GetEmploymentLevelByIdResult>>>
  {
    #region Fields
    private readonly IEmploymentLevelService _EmploymentLevelService;
    private readonly IMapper _mapper;
    #endregion
    public EmploymentLevelQueryHandler(IEmploymentLevelService EmploymentLevelService, IMapper mapper)
    {
      _mapper = mapper;
      _EmploymentLevelService = EmploymentLevelService;
    }

    public async Task<Response<GetEmploymentLevelByIdResult>> Handle(GetEmploymentLevelByIdQuery request, CancellationToken cancellationToken)
    {
      var EmploymentLevel = await _EmploymentLevelService.GetEmploymentLevelByIdAsync(request.Id);


      if (EmploymentLevel == null)
      {
        return NotFound<GetEmploymentLevelByIdResult>("EmploymentLevel Not Found");
      }
      else
      {
        var EmploymentLevelMapper = _mapper.Map<GetEmploymentLevelByIdResult>(EmploymentLevel);
        return Success(EmploymentLevelMapper);
      }
    }

    public async Task<Response<List<GetEmploymentLevelByIdResult>>> Handle(GetEmploymentLevelListQuery request, CancellationToken cancellationToken)
    {
      var EmploymentLevelList = await _EmploymentLevelService.GetEmploymentLevelsListAsync();

      var EmploymentLevelListMapper = _mapper.Map<List<GetEmploymentLevelByIdResult>>(EmploymentLevelList);

      return Success(EmploymentLevelListMapper);
    }
  }
}
