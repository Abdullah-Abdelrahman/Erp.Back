using Erp.Core.Features.CostCenter.Queries.Results;
using Erp.Data.Entities.AccountsModule;

namespace Erp.Core.Mapping.CostCenter
{
  public partial class CostCenterProfile
  {
    public void GetSecondaryCostCenterMapping()
    {
      CreateMap<SecondaryCostCenter, GetSecondaryCostCenterByIdResult>()
                .ForMember(dest => dest.journalEntryDetails, opt => opt.MapFrom(src => src.journalEntryDetails)).
                ForMember(dest => dest.CostCenterName, opt => opt.MapFrom(src => src.Name));
    }
  }
}
