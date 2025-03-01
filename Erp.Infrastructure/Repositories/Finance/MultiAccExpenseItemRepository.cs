using Erp.Data.Entities;
using Erp.Data.MetaData;
using Erp.Infrastructure.Abstracts.Finance;
using Microsoft.EntityFrameworkCore;
using Name.Infrastructure.Bases;
using Name.Infrastructure.Data;

namespace Erp.Infrastructure.Repositories.Finance
{
  public class MultiAccExpenseItemRepository : GenericRepository<MultiAccExpenseItem>, IMultiAccExpenseItemRepository
  {
    private readonly DbSet<MultiAccExpenseItem> _MultiAccExpenseItems;
    public MultiAccExpenseItemRepository(ApplicationDBContext dbContext) : base(dbContext)
    {
      _MultiAccExpenseItems = dbContext.Set<MultiAccExpenseItem>();

    }


    public async Task<string> AddMultiAccExpenseItemAsync(MultiAccExpenseItem MultiAccExpenseItem)
    {
      var result = await _MultiAccExpenseItems.AddAsync(MultiAccExpenseItem);

      if (result == null)
      {
        return "Cant Add";
      }
      else
      {
        return MessageCenter.CrudMessage.Success;
      }
    }

    public async Task<MultiAccExpenseItem?> GetMultiAccExpenseItemByIdAsync(int id)
    {
      return await _MultiAccExpenseItems.FindAsync(id);

    }

    public async Task<List<MultiAccExpenseItem>> GetMultiAccExpenseItemsListAsync()
    {
      return await _MultiAccExpenseItems.ToListAsync();
    }

    public async Task<string> UpdateMultiAccExpenseItemAsync(MultiAccExpenseItem request)
    {
      var result = _MultiAccExpenseItems.Update(request);

      return MessageCenter.CrudMessage.Success;
    }
  }
}

