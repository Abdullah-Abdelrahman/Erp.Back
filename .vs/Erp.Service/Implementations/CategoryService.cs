using Erp.Data.Entities;
using Erp.Data.MetaData;
using Erp.Infrastructure.Abstracts;
using Erp.Service.Abstracts;

namespace Erp.Service.Implementations
{
  public class CategoryService : ICategoryService
  {
    private readonly ICategoryRepository _categoryRepository;


    public CategoryService(ICategoryRepository categoryRepository)
    {
      _categoryRepository = categoryRepository;
    }
    public async Task<string> AddCategoryAsync(Category Category)
    {

      var newCategory = await _categoryRepository.AddAsync(Category);
      if (newCategory != null)
      {
        return MessageCenter.CrudMessage.Success;
      }
      else
      {
        return "Somthing bad happend :";
      }
    }

    public async Task<string> DeleteAsync(Category Category)
    {
      try
      {
        await _categoryRepository.DeleteAsync(Category);
        return MessageCenter.CrudMessage.Success;
      }
      catch (Exception ex)
      {
        return "There is a problem in deleteing the Category : " + ex.Message;
      }

    }

    public async Task<Category> GetCategoryByIdAsync(int id)
    {
      var Category = _categoryRepository.GetTableNoTracking().Where(x => x.CategoryId == id).SingleOrDefault();

      return Category;
    }

    public async Task<List<Category>> GetCategorysListAsync()
    {
      var Categorys = _categoryRepository.GetTableNoTracking().ToList();

      return Categorys;
    }

    public async Task<string> UpdateAsync(Category Category)
    {
      var transact = _categoryRepository.BeginTransaction();
      try
      {
        await _categoryRepository.UpdateAsync(Category);

        await transact.CommitAsync();
        return MessageCenter.CrudMessage.Success;

      }
      catch
      {
        await transact.RollbackAsync();
        return MessageCenter.CrudMessage.Falied;
      }
    }
  }
}
