using Erp.Core.Features.Module.Queries.Results;
using Entitis = Erp.Data.Entities.MainModule;
namespace Erp.Core.Mapping.Module
{
  public partial class ModuleProfile
  {

    public void GetModuleByIdMapping()
    {
      CreateMap<Entitis.Module, GetModuleByIdResult>().
     ForMember(destnation => destnation.ModuleID, opt => opt.MapFrom(src => src.ModuleID))
     .ForMember(destnation => destnation.Name, opt => opt.MapFrom(src => src.ModuleName))
     .ForMember(destnation => destnation.ClaimList, opt => opt.MapFrom(src => src.ClaimList));


    }
  }
}
