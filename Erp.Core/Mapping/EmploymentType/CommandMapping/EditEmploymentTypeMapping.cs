using Erp.Core.Features.EmploymentType.Commands.Models;
using Entitis = Erp.Data.Entities.HumanResources.OrganizationalStructure;
namespace Erp.Core.Mapping.EmploymentType
{
  public partial class EmploymentTypeProfile
  {
    public void EditEmploymentTypeMapping()
    {
      CreateMap<EditEmploymentTypeCommand, Entitis.EmploymentType>()
   .ForMember(destnation => destnation.ID, opt => opt.MapFrom(src => src.Id));
    }
  }
}
