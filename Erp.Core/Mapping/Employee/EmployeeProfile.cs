using AutoMapper;

namespace Erp.Core.Mapping.Employee
{
  public partial class EmployeeProfile : Profile
  {
    public EmployeeProfile()
    {
      AddEmployeeMapping();
      EditEmployeeMapping();

      GetEmployeeByIdMapping();
    }
  }
}
