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

    private readonly ITenantService _tenantService;


    public int? CompanyId { get; set; }

    public CompanyModuleService(ICompanyModuleRepository CompanyModuleRepository,
     IModuleRepository ModuleRepository,
     ICompanyRepository companyRepository,
     ITenantService tenantService)
    {
      _CompanyModuleRepository = CompanyModuleRepository;
      _ModuleRepository = ModuleRepository;
      _companyRepository = companyRepository;
      _tenantService = tenantService;

      CompanyId = _companyRepository.GetTableAsTracking().Where(x => x.TenantId == _tenantService.TenantId).Select(x => x.CompanyID).FirstOrDefault();
    }
    public async Task<string> ActivateModuleAsync(int id)
    {



      if (CompanyId == null)
      {
        return "Company Id is not find";
      }

      var transact = _CompanyModuleRepository.BeginTransaction();
      try
      {

        var record = await _CompanyModuleRepository.AddAsync(new CompanyModule() { IsActive = true, ModuleId = id, CompanyId = (int)CompanyId });
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
      if (CompanyId == null)
      {
        return "Company Id is not find";
      }



      var transact = _CompanyModuleRepository.BeginTransaction();
      try
      {
        var record = await _CompanyModuleRepository.GetTableAsTracking().Where(x => x.ModuleId == id && x.CompanyId == (int)CompanyId).SingleOrDefaultAsync();


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
