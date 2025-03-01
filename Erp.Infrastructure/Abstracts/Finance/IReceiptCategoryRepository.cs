using Erp.Data.Entities.Finance;
using Name.Infrastructure.Bases;

namespace Erp.Infrastructure.Abstracts.Finance
{
  public interface IReceiptCategoryRepository : IGenericRepository<ReceiptCategory>
  {
    public Task<string> AddReceiptCategoryAsync(ReceiptCategory ReceiptCategory);

    public Task<ReceiptCategory?> GetReceiptCategoryByIdAsync(int id);

    public Task<List<ReceiptCategory>> GetReceiptCategorysListAsync();

    public Task<string> UpdateReceiptCategoryAsync(ReceiptCategory request);
  }
}
