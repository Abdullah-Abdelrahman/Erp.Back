using AutoMapper;

namespace Erp.Core.Mapping.CostCenter
{
  public partial class CostCenterProfile : Profile
  {
    public CostCenterProfile()
    {
      AddCostCenterMapping();


      GetPrimaryCostCenterMapping();
      GetSecondaryCostCenterMapping();
    }
  }
}
