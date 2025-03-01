using Erp.Data.Entities.HumanResources.OrganizationalStructure;
using Erp.Data.MetaData;
using Erp.Infrastructure.Abstracts.HumanResources.OrganizationalStructure;
using Microsoft.EntityFrameworkCore;
using Name.Infrastructure.Bases;
using Name.Infrastructure.Data;

namespace Erp.Infrastructure.Repositories.HumanResources.OrganizationalStructure
{
  public class DepartmentRepository : GenericRepository<Department>, IDepartmentRepository
  {
    private readonly DbSet<Department> _Departments;
    public DepartmentRepository(ApplicationDBContext dbContext) : base(dbContext)
    {
      _Departments = dbContext.Set<Department>();

    }


    public async Task<string> AddDepartmentAsync(Department Department)
    {
      var result = await _Departments.AddAsync(Department);

      if (result == null)
      {
        return "Cant Add";
      }
      else
      {
        return MessageCenter.CrudMessage.Success;
      }
    }

    public async Task<Department?> GetDepartmentByIdAsync(int id)
    {
      return await _Departments.FindAsync(id);

    }

    public async Task<List<Department>> GetDepartmentsListAsync()
    {
      return await _Departments.ToListAsync();
    }

    public async Task<string> UpdateDepartmentAsync(Department request)
    {
      var result = _Departments.Update(request);

      return MessageCenter.CrudMessage.Success;
    }
  }
}
