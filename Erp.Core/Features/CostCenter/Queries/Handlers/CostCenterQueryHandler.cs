using AutoMapper;
using Erp.Core.Features.CostCenter.Queries.Models;
using Erp.Core.Features.CostCenter.Queries.Results;
using Erp.Service.Abstracts.CostCentersModule;
using MediatR;
using Name.Core.Bases;

namespace Erp.Core.Features.CostCenter.Queries.Handlers
{
  public class CostCenterQueryHandler : ResponseHandler, IRequestHandler<GetMainCostCentersListQuery, Response<List<GetPrimaryCostCenterByIdResult>>>, IRequestHandler<GetPrimaryCostCenterByIdQuery, Response<GetPrimaryCostCenterByIdResult>>,
    IRequestHandler<GetCostCenterTypeByIdQuery, Response<string>>,
    IRequestHandler<GetSecondaryCostCenterByIdQuery, Response<GetSecondaryCostCenterByIdResult>>
  {
    #region Fields
    private readonly ICostCenterService _CostCenterService;

    private readonly IMapper _mapper;
    #endregion
    public CostCenterQueryHandler(ICostCenterService CostCenterService, IMapper mapper)
    {
      _mapper = mapper;
      _CostCenterService = CostCenterService;
    }



    public async Task<Response<string>> Handle(GetCostCenterTypeByIdQuery request, CancellationToken cancellationToken)
    {
      var CostCenterType = await _CostCenterService.GetCostCenterTypeByIdAsync(request.Id);
      return Success(CostCenterType);
    }

    public async Task<Response<List<GetPrimaryCostCenterByIdResult>>> Handle(GetMainCostCentersListQuery request, CancellationToken cancellationToken)
    {
      var primaryCostCenters = await _CostCenterService.GetMainCostCenterListAsync();
      var result = _mapper.Map<List<GetPrimaryCostCenterByIdResult>>(primaryCostCenters);
      return Success(result);
    }

    public async Task<Response<GetPrimaryCostCenterByIdResult>> Handle(GetPrimaryCostCenterByIdQuery request, CancellationToken cancellationToken)
    {
      var primaryCostCenter = await _CostCenterService.
        GetPrimaryCostCenterByIdAsync(request.Id);


      if (primaryCostCenter == null)
      {
        return NotFound<GetPrimaryCostCenterByIdResult>("Primary CostCenter Not Found");
      }

      var result = _mapper.Map<GetPrimaryCostCenterByIdResult>(primaryCostCenter);
      return Success(result);
    }

    public async Task<Response<GetSecondaryCostCenterByIdResult>> Handle(GetSecondaryCostCenterByIdQuery request, CancellationToken cancellationToken)
    {
      var secondaryCostCenter = await _CostCenterService.GetSecondaryCostCenterByIdAsync(request.Id);
      if (secondaryCostCenter == null)
      {
        return NotFound<GetSecondaryCostCenterByIdResult>("Secondary CostCenter Not Found");
      }

      var result = _mapper.Map<GetSecondaryCostCenterByIdResult>(secondaryCostCenter);
      return Success(result);
    }
  }
}
