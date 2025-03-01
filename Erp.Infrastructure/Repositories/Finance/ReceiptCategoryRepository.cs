using Erp.Data.Entities.Finance;
using Erp.Data.MetaData;
using Erp.Infrastructure.Abstracts.Finance;
using Microsoft.EntityFrameworkCore;
using Name.Infrastructure.Bases;
using Name.Infrastructure.Data;

namespace Erp.Infrastructure.Repositories.Finance
{
  public class ReceiptCategoryRepository : GenericRepository<ReceiptCategory>, IReceiptCategoryRepository
  {
    private readonly DbSet<ReceiptCategory> _ReceiptCategorys;
    public ReceiptCategoryRepository(ApplicationDBContext dbContext) : base(dbContext)
    {
      _ReceiptCategorys = dbContext.Set<ReceiptCategory>();

    }


    public async Task<string> AddReceiptCategoryAsync(ReceiptCategory ReceiptCategory)
    {
      var result = await _ReceiptCategorys.AddAsync(ReceiptCategory);

      if (result == null)
      {
        return "Cant Add";
      }
      else
      {
        return MessageCenter.CrudMessage.Success;
      }
    }

    public async Task<ReceiptCategory?> GetReceiptCategoryByIdAsync(int id)
    {
      return await _ReceiptCategorys.FindAsync(id);

    }

    public async Task<List<ReceiptCategory>> GetReceiptCategorysListAsync()
    {
      return await _ReceiptCategorys.ToListAsync();
    }

    public async Task<string> UpdateReceiptCategoryAsync(ReceiptCategory request)
    {
      var result = _ReceiptCategorys.Update(request);

      return MessageCenter.CrudMessage.Success;
    }
  }
}
