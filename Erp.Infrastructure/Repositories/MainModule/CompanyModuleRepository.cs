using Erp.Data.Entities.MainModule;
using Erp.Infrastructure.Abstracts.MainModule;
using Microsoft.EntityFrameworkCore;
using Name.Infrastructure.Bases;
using Name.Infrastructure.Data;

namespace Erp.Infrastructure.Repositories.MainModule
{
  public class CompanyModuleRepository : GenericRepository<CompanyModule>, ICompanyModuleRepository
  {
    private readonly DbSet<CompanyModule> _CompanyModules;
    public CompanyModuleRepository(ApplicationDBContext dbContext) : base(dbContext)
    {
      _CompanyModules = dbContext.Set<CompanyModule>();

    }
  }
}
