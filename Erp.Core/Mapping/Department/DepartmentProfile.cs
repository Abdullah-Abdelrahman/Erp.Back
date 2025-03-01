using AutoMapper;

namespace Erp.Core.Mapping.Department
{
  public partial class DepartmentProfile : Profile
  {
    public DepartmentProfile()
    {
      AddDepartmentMapping();
      EditDepartmentMapping();

      GetDepartmentByIdMapping();
    }
  }
}
