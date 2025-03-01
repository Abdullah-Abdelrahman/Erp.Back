using Erp.Data.Entities.Finance;
using Erp.Data.MetaData;
using Erp.Infrastructure.Abstracts.Finance;
using Microsoft.EntityFrameworkCore;
using Name.Infrastructure.Bases;
using Name.Infrastructure.Data;

namespace Erp.Infrastructure.Repositories.Finance
{
  public class MultiAccReceiptItemRepository : GenericRepository<MultiAccReceiptItem>, IMultiAccReceiptItemRepository
  {
    private readonly DbSet<MultiAccReceiptItem> _MultiAccReceiptItems;
    public MultiAccReceiptItemRepository(ApplicationDBContext dbContext) : base(dbContext)
    {
      _MultiAccReceiptItems = dbContext.Set<MultiAccReceiptItem>();

    }


    public async Task<string> AddMultiAccReceiptItemAsync(MultiAccReceiptItem MultiAccReceiptItem)
    {
      var result = await _MultiAccReceiptItems.AddAsync(MultiAccReceiptItem);

      if (result == null)
      {
        return "Cant Add";
      }
      else
      {
        return MessageCenter.CrudMessage.Success;
      }
    }

    public async Task<MultiAccReceiptItem?> GetMultiAccReceiptItemByIdAsync(int id)
    {
      return await _MultiAccReceiptItems.FindAsync(id);

    }

    public async Task<List<MultiAccReceiptItem>> GetMultiAccReceiptItemsListAsync()
    {
      return await _MultiAccReceiptItems.ToListAsync();
    }

    public async Task<string> UpdateMultiAccReceiptItemAsync(MultiAccReceiptItem request)
    {
      var result = _MultiAccReceiptItems.Update(request);

      return MessageCenter.CrudMessage.Success;
    }
  }
}

