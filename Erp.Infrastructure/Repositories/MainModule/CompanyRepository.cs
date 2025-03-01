using Erp.Data.Entities.MainModule;
using Erp.Data.MetaData;
using Erp.Infrastructure.Abstracts.MainModule;
using Microsoft.EntityFrameworkCore;
using Name.Infrastructure.Bases;
using Name.Infrastructure.Data;

namespace Erp.Infrastructure.Repositories.MainModule
{
  public class CompanyRepository : GenericRepository<Company>, ICompanyRepository
  {
    private readonly DbSet<Company> _Companys;
    public CompanyRepository(ApplicationDBContext dbContext) : base(dbContext)
    {
      _Companys = dbContext.Set<Company>();

    }


    public async Task<string> AddCompanyAsync(Company Company)
    {
      var result = await _Companys.AddAsync(Company);

      if (result == null)
      {
        return "Cant Add";
      }
      else
      {
        return MessageCenter.CrudMessage.Success;
      }
    }

    public async Task<Company> GetCompanyByIdAsync(int id)
    {
      return await _Companys.FindAsync(id);

    }

    public async Task<List<Company>> GetCompanysListAsync()
    {
      return await _Companys.ToListAsync();
    }

    public async Task<string> UpdateCompanyAsync(Company request)
    {
      var result = _Companys.Update(request);

      return MessageCenter.CrudMessage.Success;
    }
  }
}
