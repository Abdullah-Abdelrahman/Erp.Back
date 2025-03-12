using Erp.Data.Entities.MainModule;
using Erp.Data.MetaData;
using Erp.Infrastructure.Abstracts.MainModule;
using Erp.Service.Abstracts.MainModule;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using E = Erp.Data.Entities.MainModule;
namespace Erp.Service.Implementations.MainModule
{
  public class ModuleService : IModuleService
  {
    private readonly IModuleRepository _ModuleRepository;
    public ModuleService(IModuleRepository ModuleRepository)
    {
      _ModuleRepository = ModuleRepository;
    }
    public async Task<string> AddModuleAsync(E.Module Module)
    {
      if (Module.Description == null)
      {
        Module.Description = string.Empty;
      }


      var newModule = await _ModuleRepository.AddAsync(Module);
      if (newModule != null)
      {
        return MessageCenter.CrudMessage.Success;
      }
      else
      {
        return "Somthing bad happend :";
      }
    }

    public async Task<string> DeleteAsync(E.Module Module)
    {
      try
      {
        await _ModuleRepository.DeleteAsync(Module);
        return MessageCenter.CrudMessage.Success;
      }
      catch (Exception ex)
      {
        return "There is a problem in deleteing the Module : " + ex.Message;
      }

    }

    public async Task<E.Module> GetModuleByIdAsync(int id)
    {
      var Module = await _ModuleRepository.GetTableNoTracking().Where(x => x.ModuleID == id).SingleOrDefaultAsync();

      return Module;
    }

    public async Task<List<E.Module>> GetModulesListAsync()
    {
      var Modules = await _ModuleRepository.GetTableNoTracking().ToListAsync();
      foreach (var module in Modules)
      {
        module.ClaimList = module.ClaimList.ToList();
      }

      return Modules;
    }

    public async Task<string> UpdateAsync(E.Module Module)
    {
      var transact = _ModuleRepository.BeginTransaction();
      try
      {
        await _ModuleRepository.UpdateAsync(Module);

        await transact.CommitAsync();
        return MessageCenter.CrudMessage.Success;

      }
      catch
      {
        await transact.RollbackAsync();
        return MessageCenter.CrudMessage.Falied;
      }
    }
  }
}
