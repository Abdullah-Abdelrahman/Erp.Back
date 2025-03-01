using Erp.Data.Entities.Finance;
using Name.Infrastructure.Bases;

namespace Erp.Infrastructure.Abstracts.Finance
{
  public interface IReceiptRepository : IGenericRepository<Receipt>
  {
    public Task<string> AddReceiptAsync(Receipt Receipt);

    public Task<Receipt?> GetReceiptByIdAsync(int id);

    public Task<List<Receipt>> GetReceiptsListAsync();

    public Task<string> UpdateReceiptAsync(Receipt request);
  }
}
