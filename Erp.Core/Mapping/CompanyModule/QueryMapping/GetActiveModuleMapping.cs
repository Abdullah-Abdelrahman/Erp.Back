using Erp.Core.Features.CompanyModule.Queries.Results;
using Entitis = Erp.Data.Entities.MainModule;
namespace Erp.Core.Mapping.CompanyModule
{
  public partial class CompanyModuleProfile
  {

    public void GetActiveModuleMapping()
    {
      CreateMap<Entitis.Module, GetActiveModuleResult>().
     ForMember(destnation => destnation.Id, opt => opt.MapFrom(src => src.ModuleID))
     .ForMember(destnation => destnation.Name, opt => opt.MapFrom(src => src.ModuleName)).
     ForMember(destnation => destnation.Description, opt => opt.MapFrom(src => src.Description));


    }
  }
}
