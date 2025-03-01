using AutoMapper;

namespace Erp.Core.Mapping.EmploymentLevel
{
  public partial class EmploymentLevelProfile : Profile
  {
    public EmploymentLevelProfile()
    {
      AddEmploymentLevelMapping();
      EditEmploymentLevelMapping();

      GetEmploymentLevelByIdMapping();
    }
  }
}
