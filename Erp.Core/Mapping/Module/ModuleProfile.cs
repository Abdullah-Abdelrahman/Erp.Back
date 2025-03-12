using AutoMapper;

namespace Erp.Core.Mapping.Module
{
  public partial class ModuleProfile : Profile
  {
    public ModuleProfile()
    {
      AddModuleMapping();
      EditModuleMapping();

      GetModuleByIdMapping();
    }
  }
}
