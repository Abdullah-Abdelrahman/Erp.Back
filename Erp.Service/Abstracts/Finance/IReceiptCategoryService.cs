using Erp.Data.Entities.Finance;

namespace Erp.Service.Abstracts.Finance
{
  public interface IReceiptCategoryService
  {
    public Task<List<ReceiptCategory>> GetReceiptCategorysListAsync();

    public Task<ReceiptCategory> GetReceiptCategoryByIdAsync(int id);

    public Task<string> AddReceiptCategoryAsync(ReceiptCategory ReceiptCategory);

    public Task<string> UpdateAsync(ReceiptCategory ReceiptCategory);

    public Task<string> DeleteAsync(ReceiptCategory ReceiptCategory);
  }
}
