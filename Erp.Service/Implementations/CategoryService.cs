using Erp.Data.Entities.InventoryModule;
using Erp.Data.MetaData;
using Erp.Infrastructure.Abstracts;
using Erp.Service.Abstracts;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Name.Service.Abstracts;

namespace Erp.Service.Implementations
{
  public class CategoryService : ICategoryService
  {
    private readonly ICategoryRepository _categoryRepository;
    private readonly IFileService _FileService;


    public CategoryService(ICategoryRepository categoryRepository, IFileService fileService)
    {
      _categoryRepository = categoryRepository;
      _FileService = fileService;
    }
    public async Task<string> AddCategoryAsync(Category Category, IFormFile? ImageFile,
      string? webRootPath)
    {

      Category.ImagePath = (await _FileService.UploadFile(ImageFile, webRootPath));
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
      var Category = await _categoryRepository.GetTableNoTracking().Where(x => x.CategoryId == id).SingleOrDefaultAsync();
      if (Category != null)
      {
        Category.ImageFile = await _FileService.GetFileAsync(Category.ImagePath);

      }
      return Category;
    }

    public async Task<List<Category>> GetCategorysListAsync()
    {
      var Categorys = await _categoryRepository.GetTableNoTracking().ToListAsync();

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
      catch (Exception ex)
      {
        await transact.RollbackAsync();
        return MessageCenter.CrudMessage.Falied + ex.Message;
      }
    }
  }
}
