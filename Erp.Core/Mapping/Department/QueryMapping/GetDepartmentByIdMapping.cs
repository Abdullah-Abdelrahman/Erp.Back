using Erp.Core.Features.Department.Queries.Results;
using Entitis = Erp.Data.Entities.HumanResources.OrganizationalStructure;
namespace Erp.Core.Mapping.Department
{
  public partial class DepartmentProfile
  {

    public void GetDepartmentByIdMapping()
    {
      CreateMap<Entitis.Department, GetDepartmentByIdResult>().
     ForMember(destnation => destnation.Id, opt => opt.MapFrom(src => src.DepartmentID)).ForMember(destnation => destnation.Name, opt => opt.MapFrom(src => src.DepartmentName));


    }
  }
}
