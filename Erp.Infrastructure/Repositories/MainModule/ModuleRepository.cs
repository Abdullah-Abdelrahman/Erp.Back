using Erp.Data.Entities.MainModule;
using Erp.Infrastructure.Abstracts.MainModule;
using Microsoft.EntityFrameworkCore;
using Name.Infrastructure.Bases;
using Name.Infrastructure.Data;

namespace Erp.Infrastructure.Repositories.MainModule
{
  public class ModuleRepository : GenericRepository<Module>, IModuleRepository
  {
    private readonly DbSet<Module> _Modules;
    public ModuleRepository(ApplicationDBContext dbContext) : base(dbContext)
    {
      _Modules = dbContext.Set<Module>();

    }
  }

}
