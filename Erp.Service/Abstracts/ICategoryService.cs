using Erp.Data.Entities.InventoryModule;

namespace Erp.Service.Abstracts
{
  public interface ICategoryService
  {
    public Task<List<Category>> GetCategorysListAsync();

    public Task<Category> GetCategoryByIdAsync(int id);

    public Task<string> AddCategoryAsync(Category Category);

    public Task<string> UpdateAsync(Category Category);

    public Task<string> DeleteAsync(Category Category);
  }
}
