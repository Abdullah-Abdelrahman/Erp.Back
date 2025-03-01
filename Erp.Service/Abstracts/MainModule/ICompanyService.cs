using Erp.Data.Entities.MainModule;

namespace Erp.Service.Abstracts.MainModule
{
  public interface ICompanyService
  {
    public Task<List<Company>> GetCompanysListAsync();

    public Task<Company> GetCompanyByIdAsync(int id);

    public Task<string> AddCompanyAsync(Company Company);

    public Task<string> UpdateAsync(Company Company);

    public Task<string> DeleteAsync(Company Company);
  }
}
