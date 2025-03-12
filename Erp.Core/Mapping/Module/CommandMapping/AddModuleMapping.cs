using Erp.Core.Features.Module.Commands.Models;
using Entitis = Erp.Data.Entities.MainModule;
namespace Erp.Core.Mapping.Module
{
  public partial class ModuleProfile
  {

    public void AddModuleMapping()
    {
      CreateMap<AddModuleCommand, Entitis.Module>()
       .ForMember(destnation => destnation.ModuleName, opt => opt.MapFrom(src => src.Name));
    }
  }
}
