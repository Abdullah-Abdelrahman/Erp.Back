using Erp.Core.Features.CostCenter.Queries.Results;
using Erp.Data.Entities.AccountsModule;

namespace Erp.Core.Mapping.CostCenter
{
  public partial class CostCenterProfile
  {
    public void GetPrimaryCostCenterMapping()
    {
      CreateMap<PrimaryCostCenter, GetPrimaryCostCenterByIdResult>()
                .ForMember(dest => dest.ChildCostCenters, opt => opt.MapFrom(src => src.costCenters));
    }
  }
}
