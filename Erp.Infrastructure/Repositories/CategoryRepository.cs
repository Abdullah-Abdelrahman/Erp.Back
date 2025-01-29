using Erp.Data.Entities.InventoryModule;
using Erp.Infrastructure.Abstracts;
using Microsoft.EntityFrameworkCore;
using Name.Infrastructure.Bases;
using Name.Infrastructure.Data;

namespace Erp.Infrastructure.Repositories
{
  public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
  {
    private readonly DbSet<Category> _Categorys;
    public CategoryRepository(ApplicationDBContext dbContext) : base(dbContext)
    {
      _Categorys = dbContext.Set<Category>();
    }

    public Task<string> AddCategoryAsync(Category Category)
    {
      throw new NotImplementedException();
    }

    public Task<Category> GetCategoryByIdAsync(int id)
    {
      throw new NotImplementedException();
    }

    public Task<string> UpdateCategoryAsync(Category request)
    {
      throw new NotImplementedException();
    }
  }
}
