using Erp.Data.Dto.Treasury;
using Erp.Data.Entities.Finance;

namespace Erp.Service.Abstracts.Finance
{
  public interface ITreasuryService
  {
    public Task<List<GetTreasuryByIdDto>> GetTreasurysListAsync();

    public Task<GetTreasuryByIdDto> GetTreasuryByIdAsync(int id);

    public Task<string> AddTreasury(AddTreasuryRequest Treasury);

    public Task<string> UpdateAsync(UpdateTreasuryRequest Treasury);

    public Task<string> DeleteAsync(Treasury Treasury);
    public Task<string> DeleteByIdAsync(int id);
  }
}
