using Erp.Data.Entities.Finance;
using Name.Infrastructure.Bases;

namespace Erp.Infrastructure.Abstracts.Finance
{
  public interface ITreasuryRepository : IGenericRepository<Treasury>
  {
    public Task<string> AddTreasuryAsync(Treasury Treasury);

    public Task<Treasury?> GetTreasuryByIdAsync(int id);

    public Task<List<Treasury>> GetTreasurysListAsync();

    public Task<string> UpdateTreasuryAsync(Treasury request);
  }
}
