using Erp.Core.Features.Department.Commands.Models;
using Entitis = Erp.Data.Entities.HumanResources.OrganizationalStructure;
namespace Erp.Core.Mapping.Department
{
  public partial class DepartmentProfile
  {

    public void AddDepartmentMapping()
    {
      CreateMap<AddDepartmentCommand, Entitis.Department>()
       .ForMember(destnation => destnation.DepartmentName, opt => opt.MapFrom(src => src.Name));
    }
  }
}
