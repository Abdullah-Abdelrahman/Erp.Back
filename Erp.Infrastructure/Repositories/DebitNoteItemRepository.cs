using Erp.Data.Entities.PurchasesModule;
using Erp.Infrastructure.Abstracts;
using Microsoft.EntityFrameworkCore;
using Name.Infrastructure.Bases;
using Name.Infrastructure.Data;

namespace Erp.Infrastructure.Repositories
{
  public class DebitNoteItemRepository : GenericRepository<DebitNoteItem>, IDebitNoteItemRepository
  {
    private readonly DbSet<DebitNoteItem> _DebitNoteItems;
    public DebitNoteItemRepository(ApplicationDBContext dbContext) : base(dbContext)
    {
      _DebitNoteItems = dbContext.Set<DebitNoteItem>();
    }

    public Task<string> AddDebitNoteItemAsync(DebitNoteItem DebitNoteItem)
    {
      throw new NotImplementedException();
    }

    public Task<DebitNoteItem> GetDebitNoteItemByIdAsync(int id)
    {
      throw new NotImplementedException();
    }

    public Task<string> UpdateDebitNoteItemAsync(DebitNoteItem request)
    {
      throw new NotImplementedException();
    }
  }
}
