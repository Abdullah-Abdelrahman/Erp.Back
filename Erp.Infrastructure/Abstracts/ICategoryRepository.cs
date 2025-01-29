using Erp.Data.Entities.InventoryModule;
using Name.Infrastructure.Bases;

namespace Erp.Infrastructure.Abstracts
{
  public interface ICategoryRepository : IGenericRepository<Category>
  {
    public Task<string> AddCategoryAsync(Category Category);

    public Task<Category> GetCategoryByIdAsync(int id);

    public Task<string> UpdateCategoryAsync(Category request);
  }
}
