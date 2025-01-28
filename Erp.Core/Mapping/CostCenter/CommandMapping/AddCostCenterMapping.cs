using Erp.Core.Features.CostCenter.Commands.Models;
using Entitis = Erp.Data.Entities;
namespace Erp.Core.Mapping.CostCenter
{
  public partial class CostCenterProfile
  {
    public void AddCostCenterMapping()
    {
      CreateMap<AddCostCenterCommand, Entitis.AccountsModule.CostCenter>()
             .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.CostCenterName));

      CreateMap<AddCostCenterCommand, Entitis.AccountsModule.PrimaryCostCenter>()
          .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.CostCenterName));

      CreateMap<AddCostCenterCommand, Entitis.AccountsModule.SecondaryCostCenter>()
          .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.CostCenterName));
    }
  }
}
