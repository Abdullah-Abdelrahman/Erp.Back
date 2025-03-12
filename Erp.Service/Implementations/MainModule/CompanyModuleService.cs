using Erp.Data.Entities.MainModule;
using Erp.Data.MetaData;
using Erp.Infrastructure.Abstracts.MainModule;
using Erp.Service.Abstracts.MainModule;
using Microsoft.EntityFrameworkCore;

namespace Erp.Service.Implementations.MainModule
{
  public class CompanyModuleService : ICompanyModuleService
  {
    private readonly ICompanyModuleRepository _CompanyModuleRepository;
    private readonly IModuleRepository _ModuleRepository;
    private readonly ICompanyRepository _companyRepository;



    public CompanyModuleService(ICompanyModuleRepository CompanyModuleRepository,
     IModuleRepository ModuleRepository,
     ICompanyRepository companyRepository)
    {
      _CompanyModuleRepository = CompanyModuleRepository;
      _ModuleRepository = ModuleRepository;
      _companyRepository = companyRepository;
    }
    public async Task<string> ActivateModuleAsync(int id)
    {





      var transact = _CompanyModuleRepository.BeginTransaction();
      try
      {
        var record = await _CompanyModuleRepository.AddAsync(new CompanyModule() { IsActive = true, ModuleId = id, CompanyId = 26 });
        await transact.CommitAsync();
        return MessageCenter.CrudMessage.Success;

      }
      catch
      {
        await transact.RollbackAsync();
        return MessageCenter.CrudMessage.Falied;
      }

    }

    public async Task<string> DeActivateModuleAsync(int id)
    {
      var record = await _CompanyModuleRepository.GetTableAsTracking().Where(x => x.ModuleId == id && x.CompanyId == 26).SingleOrDefaultAsync();



      var transact = _CompanyModuleRepository.BeginTransaction();
      try
      {
        await _CompanyModuleRepository.DeleteAsync(record);

        await transact.CommitAsync();
        return MessageCenter.CrudMessage.Success;

      }
      catch
      {
        await transact.RollbackAsync();
        return MessageCenter.CrudMessage.Falied;
      }
    }

    public async Task<List<Module>> GetActiveModulesListAsync()
    {
      var activeIds = await _CompanyModuleRepository.GetTableNoTracking().Where(x => x.IsActive == true).Select(x => x.ModuleId).ToListAsync();

      var models = new List<Module>();
      foreach (var id in activeIds)
      {
        models.Add(await _ModuleRepository.GetByIdAsync(id));
      }
      return models;
    }
  }
}
