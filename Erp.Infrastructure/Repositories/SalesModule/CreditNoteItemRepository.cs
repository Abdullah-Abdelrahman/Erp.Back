using Erp.Data.Entities.SalesModule;
using Erp.Infrastructure.Abstracts.SalesModule;
using Microsoft.EntityFrameworkCore;
using Name.Infrastructure.Bases;
using Name.Infrastructure.Data;

namespace Erp.Infrastructure.Repositories.SalesModule
{
  public class CreditNoteItemRepository : GenericRepository<CreditNoteItem>, ICreditNoteItemRepository
  {
    private readonly DbSet<CreditNoteItem> _CreditNoteItems;
    public CreditNoteItemRepository(ApplicationDBContext dbContext) : base(dbContext)
    {
      _CreditNoteItems = dbContext.Set<CreditNoteItem>();
    }

    public Task<string> AddCreditNoteItemAsync(CreditNoteItem CreditNoteItem)
    {
      throw new NotImplementedException();
    }

    public Task<CreditNoteItem> GetCreditNoteItemByIdAsync(int id)
    {
      throw new NotImplementedException();
    }

    public Task<string> UpdateCreditNoteItemAsync(CreditNoteItem request)
    {
      throw new NotImplementedException();
    }
  }
}
