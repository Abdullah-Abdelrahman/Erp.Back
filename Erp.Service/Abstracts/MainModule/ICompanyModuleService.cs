using E = Erp.Data.Entities.MainModule;

namespace Erp.Service.Abstracts.MainModule
{
  public interface ICompanyModuleService
  {
    public Task<List<E.Module>> GetActiveModulesListAsync();


    public Task<string> ActivateModuleAsync(int id);

    public Task<string> DeActivateModuleAsync(int id);


  }
}
