using AutoMapper;

namespace Erp.Core.Mapping.EmploymentType
{
  public partial class EmploymentTypeProfile : Profile
  {
    public EmploymentTypeProfile()
    {
      AddEmploymentTypeMapping();
      EditEmploymentTypeMapping();

      GetEmploymentTypeByIdMapping();
    }
  }
}
