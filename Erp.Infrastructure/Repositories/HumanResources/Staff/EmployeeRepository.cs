using Erp.Data.Entities.HumanResources.Staff;
using Erp.Infrastructure.Abstracts.HumanResources.Staff;
using Microsoft.EntityFrameworkCore;
using Name.Infrastructure.Bases;
using Name.Infrastructure.Data;

namespace Erp.Infrastructure.Repositories.HumanResources.Staff
{
  public class EmployeeRepository : GenericRepository<Employee>, IEmployeeRepository
  {
    private readonly DbSet<Employee> _employees;
    public EmployeeRepository(ApplicationDBContext dbContext) : base(dbContext)
    {
      _employees = dbContext.Set<Employee>();
    }
  }
}
