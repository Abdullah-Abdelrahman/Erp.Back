using Erp.Data.Entities.MainModule;

namespace Erp.Service.Abstracts.MainModule
{
  public interface IModuleService
  {
    public Task<List<Module>> GetModulesListAsync();

    public Task<Module> GetModuleByIdAsync(int id);

    public Task<string> AddModuleAsync(Module Module);

    public Task<string> UpdateAsync(Module Module);

    public Task<string> DeleteAsync(Module Module);
  }
}
