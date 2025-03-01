using Erp.Data.Entities.Finance;
using Erp.Data.MetaData;
using Erp.Infrastructure.Abstracts.Finance;
using Microsoft.EntityFrameworkCore;
using Name.Infrastructure.Bases;
using Name.Infrastructure.Data;

namespace Erp.Infrastructure.Repositories.Finance
{
  public class TreasuryRepository : GenericRepository<Treasury>, ITreasuryRepository
  {
    private readonly DbSet<Treasury> _Treasurys;
    public TreasuryRepository(ApplicationDBContext dbContext) : base(dbContext)
    {
      _Treasurys = dbContext.Set<Treasury>();

    }


    public async Task<string> AddTreasuryAsync(Treasury Treasury)
    {
      var result = await _Treasurys.AddAsync(Treasury);

      if (result == null)
      {
        return "Cant Add";
      }
      else
      {
        return MessageCenter.CrudMessage.Success;
      }
    }

    public async Task<Treasury?> GetTreasuryByIdAsync(int id)
    {
      return await _Treasurys.FindAsync(id);

    }

    public async Task<List<Treasury>> GetTreasurysListAsync()
    {
      return await _Treasurys.ToListAsync();
    }

    public async Task<string> UpdateTreasuryAsync(Treasury request)
    {
      var result = _Treasurys.Update(request);

      return MessageCenter.CrudMessage.Success;
    }
  }
}
