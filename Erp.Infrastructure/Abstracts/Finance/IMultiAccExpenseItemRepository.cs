using Erp.Data.Entities;
using Name.Infrastructure.Bases;

namespace Erp.Infrastructure.Abstracts.Finance
{
  public interface IMultiAccExpenseItemRepository : IGenericRepository<MultiAccExpenseItem>
  {
    public Task<string> AddMultiAccExpenseItemAsync(MultiAccExpenseItem MultiAccExpenseItem);

    public Task<MultiAccExpenseItem?> GetMultiAccExpenseItemByIdAsync(int id);

    public Task<List<MultiAccExpenseItem>> GetMultiAccExpenseItemsListAsync();

    public Task<string> UpdateMultiAccExpenseItemAsync(MultiAccExpenseItem request);
  }
}
