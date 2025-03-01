using Erp.Data.Entities.Finance;
using Name.Infrastructure.Bases;

namespace Erp.Infrastructure.Abstracts.Finance
{
  public interface IMultiAccReceiptItemRepository : IGenericRepository<MultiAccReceiptItem>
  {
    public Task<string> AddMultiAccReceiptItemAsync(MultiAccReceiptItem MultiAccReceiptItem);

    public Task<MultiAccReceiptItem?> GetMultiAccReceiptItemByIdAsync(int id);

    public Task<List<MultiAccReceiptItem>> GetMultiAccReceiptItemsListAsync();

    public Task<string> UpdateMultiAccReceiptItemAsync(MultiAccReceiptItem request);
  }
}
