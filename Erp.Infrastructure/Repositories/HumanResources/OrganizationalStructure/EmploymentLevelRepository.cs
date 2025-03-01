using Erp.Data.Entities.HumanResources.OrganizationalStructure;
using Erp.Data.MetaData;
using Erp.Infrastructure.Abstracts.HumanResources.OrganizationalStructure;
using Microsoft.EntityFrameworkCore;
using Name.Infrastructure.Bases;
using Name.Infrastructure.Data;

namespace Erp.Infrastructure.Repositories.HumanResources.OrganizationalStructure
{
  public class EmploymentLevelRepository : GenericRepository<EmploymentLevel>, IEmploymentLevelRepository
  {
    private readonly DbSet<EmploymentLevel> _EmploymentLevels;
    public EmploymentLevelRepository(ApplicationDBContext dbContext) : base(dbContext)
    {
      _EmploymentLevels = dbContext.Set<EmploymentLevel>();

    }


    public async Task<string> AddEmploymentLevelAsync(EmploymentLevel EmploymentLevel)
    {
      var result = await _EmploymentLevels.AddAsync(EmploymentLevel);

      if (result == null)
      {
        return "Cant Add";
      }
      else
      {
        return MessageCenter.CrudMessage.Success;
      }
    }

    public async Task<EmploymentLevel?> GetEmploymentLevelByIdAsync(int id)
    {
      return await _EmploymentLevels.FindAsync(id);

    }

    public async Task<List<EmploymentLevel>> GetEmploymentLevelsListAsync()
    {
      return await _EmploymentLevels.ToListAsync();
    }

    public async Task<string> UpdateEmploymentLevelAsync(EmploymentLevel request)
    {
      var result = _EmploymentLevels.Update(request);

      return MessageCenter.CrudMessage.Success;
    }
  }
}
