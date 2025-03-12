using Erp.Core.Features.EmploymentLevel.Commands.Models;
using Entitis = Erp.Data.Entities.HumanResources.OrganizationalStructure;
namespace Erp.Core.Mapping.EmploymentLevel
{
  public partial class EmploymentLevelProfile
  {
    public void EditEmploymentLevelMapping()
    {
      CreateMap<EditEmploymentLevelCommand, Entitis.EmploymentLevel>()
   .ForMember(destnation => destnation.ID, opt => opt.MapFrom(src => src.Id));
    }
  }
}
