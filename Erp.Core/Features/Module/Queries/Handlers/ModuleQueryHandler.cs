using AutoMapper;
using Erp.Core.Features.Module.Queries.Models;
using Erp.Core.Features.Module.Queries.Results;
using Erp.Service.Abstracts.MainModule;
using MediatR;
using Name.Core.Bases;

namespace Erp.Core.Features.Module.Queries.Handlers
{
  public class ModuleQueryHandler : ResponseHandler, IRequestHandler<GetModuleByIdQuery, Response<GetModuleByIdResult>>, IRequestHandler<GetModuleListQuery, Response<List<GetModuleByIdResult>>>
  {
    #region Fields
    private readonly IModuleService _ModuleService;
    private readonly IMapper _mapper;
    #endregion
    public ModuleQueryHandler(IModuleService ModuleService, IMapper mapper)
    {
      _mapper = mapper;
      _ModuleService = ModuleService;
    }

    public async Task<Response<GetModuleByIdResult>> Handle(GetModuleByIdQuery request, CancellationToken cancellationToken)
    {
      var Module = await _ModuleService.GetModuleByIdAsync(request.Id);


      if (Module == null)
      {
        return NotFound<GetModuleByIdResult>("Module Not Found");
      }
      else
      {
        var ModuleMapper = _mapper.Map<GetModuleByIdResult>(Module);
        return Success(ModuleMapper);
      }
    }

    public async Task<Response<List<GetModuleByIdResult>>> Handle(GetModuleListQuery request, CancellationToken cancellationToken)
    {
      var ModuleList = await _ModuleService.GetModulesListAsync();

      var ModuleListMapper = _mapper.Map<List<GetModuleByIdResult>>(ModuleList);

      return Success(ModuleListMapper);
    }
  }
}
