using Erp.Core.Features.Employee.Queries.Results;
using Entitis = Erp.Data.Entities.HumanResources.Staff;
namespace Erp.Core.Mapping.Employee
{
  public partial class EmployeeProfile
  {

    public void GetEmployeeByIdMapping()
    {
      CreateMap<Entitis.Employee, GetEmployeeByIdResult>().
     ForMember(destnation => destnation.EmployeeID, opt => opt.MapFrom(src => src.EmployeeID)).ForMember(destnation => destnation.FirstName, opt => opt.MapFrom(src => src.FirstName));


    }
  }
}
