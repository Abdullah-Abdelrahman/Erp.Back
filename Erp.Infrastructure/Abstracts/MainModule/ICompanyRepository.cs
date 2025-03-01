using Erp.Data.Entities.MainModule;
using Name.Infrastructure.Bases;

namespace Erp.Infrastructure.Abstracts.MainModule
{
  public interface ICompanyRepository : IGenericRepository<Company>
  {
    public Task<string> AddCompanyAsync(Company Company);

    public Task<Company> GetCompanyByIdAsync(int id);

    public Task<List<Company>> GetCompanysListAsync();

    public Task<string> UpdateCompanyAsync(Company request);
  }
}
