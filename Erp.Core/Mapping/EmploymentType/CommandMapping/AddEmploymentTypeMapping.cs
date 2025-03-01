using Erp.Core.Features.EmploymentType.Commands.Models;
using Entitis = Erp.Data.Entities.HumanResources.OrganizationalStructure;
namespace Erp.Core.Mapping.EmploymentType
{
  public partial class EmploymentTypeProfile
  {

    public void AddEmploymentTypeMapping()
    {
      CreateMap<AddEmploymentTypeCommand, Entitis.EmploymentType>()
       .ForMember(destnation => destnation.Name, opt => opt.MapFrom(src => src.Name));
    }
  }
}
