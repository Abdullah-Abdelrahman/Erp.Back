using Erp.Data.Entities.Finance;
using Erp.Data.MetaData;
using Erp.Infrastructure.Abstracts.Finance;
using Erp.Service.Abstracts.Finance;
using Microsoft.EntityFrameworkCore;

namespace Erp.Service.Implementations.Finance
{
  public class ReceiptCategoryService : IReceiptCategoryService
  {
    private readonly IReceiptCategoryRepository _ReceiptCategoryRepository;


    public ReceiptCategoryService(IReceiptCategoryRepository ReceiptCategoryRepository)
    {
      _ReceiptCategoryRepository = ReceiptCategoryRepository;
    }
    public async Task<string> AddReceiptCategoryAsync(ReceiptCategory ReceiptCategory)
    {

      var newReceiptCategory = await _ReceiptCategoryRepository.AddAsync(ReceiptCategory);
      if (newReceiptCategory != null)
      {
        return MessageCenter.CrudMessage.Success;
      }
      else
      {
        return "Somthing bad happend :";
      }
    }

    public async Task<string> DeleteAsync(ReceiptCategory ReceiptCategory)
    {
      try
      {
        await _ReceiptCategoryRepository.DeleteAsync(ReceiptCategory);
        return MessageCenter.CrudMessage.Success;
      }
      catch (Exception ex)
      {
        return "There is a problem in deleteing the ReceiptCategory : " + ex.Message;
      }

    }

    public async Task<ReceiptCategory> GetReceiptCategoryByIdAsync(int id)
    {
      var ReceiptCategory = await _ReceiptCategoryRepository.GetTableNoTracking().Where(x => x.Id == id).SingleOrDefaultAsync();

      return ReceiptCategory;
    }

    public async Task<List<ReceiptCategory>> GetReceiptCategorysListAsync()
    {
      var ReceiptCategorys = await _ReceiptCategoryRepository.GetTableNoTracking().ToListAsync();

      return ReceiptCategorys;
    }

    public async Task<string> UpdateAsync(ReceiptCategory ReceiptCategory)
    {
      var transact = _ReceiptCategoryRepository.BeginTransaction();
      try
      {
        await _ReceiptCategoryRepository.UpdateAsync(ReceiptCategory);

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

