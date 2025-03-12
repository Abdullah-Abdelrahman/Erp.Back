using Erp.Core.Features.Employee.Commands.Models;
using Entitis = Erp.Data.Entities.HumanResources.Staff;
namespace Erp.Core.Mapping.Employee
{
  public partial class EmployeeProfile
  {
    public void EditEmployeeMapping()
    {
      CreateMap<EditEmployeeCommand, Entitis.Employee>()
   .ForMember(destnation => destnation.FirstName, opt => opt.MapFrom(src => src.FirstName))
   .ForMember(destnation => destnation.Status, opt => opt.MapFrom(src => src.Status));
    }
  }
}
