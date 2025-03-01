using Erp.Data.Entities.HumanResources.OrganizationalStructure;
using Erp.Data.MetaData;
using Erp.Infrastructure.Abstracts.HumanResources.OrganizationalStructure;
using Microsoft.EntityFrameworkCore;
using Name.Infrastructure.Bases;
using Name.Infrastructure.Data;

namespace Erp.Infrastructure.Repositories.HumanResources.OrganizationalStructure
{
  public class EmploymentTypeRepository : GenericRepository<EmploymentType>, IEmploymentTypeRepository
  {
    private readonly DbSet<EmploymentType> _EmploymentTypes;
    public EmploymentTypeRepository(ApplicationDBContext dbContext) : base(dbContext)
    {
      _EmploymentTypes = dbContext.Set<EmploymentType>();

    }


    public async Task<string> AddEmploymentTypeAsync(EmploymentType EmploymentType)
    {
      var result = await _EmploymentTypes.AddAsync(EmploymentType);

      if (result == null)
      {
        return "Cant Add";
      }
      else
      {
        return MessageCenter.CrudMessage.Success;
      }
    }

    public async Task<EmploymentType?> GetEmploymentTypeByIdAsync(int id)
    {
      return await _EmploymentTypes.FindAsync(id);

    }

    public async Task<List<EmploymentType>> GetEmploymentTypesListAsync()
    {
      return await _EmploymentTypes.ToListAsync();
    }

    public async Task<string> UpdateEmploymentTypeAsync(EmploymentType request)
    {
      var result = _EmploymentTypes.Update(request);

      return MessageCenter.CrudMessage.Success;
    }
  }
}

