using Erp.Data.Entities.PurchasesModule;
using Erp.Infrastructure.Abstracts;
using Microsoft.EntityFrameworkCore;
using Name.Infrastructure.Bases;
using Name.Infrastructure.Data;

namespace Erp.Infrastructure.Repositories
{
  public class PurchaseInvoiceItemRepository : GenericRepository<PurchaseInvoiceItem>, IPurchaseInvoiceItemRepository
  {
    private readonly DbSet<PurchaseInvoiceItem> _PurchaseInvoiceItems;
    public PurchaseInvoiceItemRepository(ApplicationDBContext dbContext) : base(dbContext)
    {
      _PurchaseInvoiceItems = dbContext.Set<PurchaseInvoiceItem>();
    }

    public Task<string> AddPurchaseInvoiceItemAsync(PurchaseInvoiceItem PurchaseInvoiceItem)
    {
      throw new NotImplementedException();
    }

    public Task<PurchaseInvoiceItem> GetPurchaseInvoiceItemByIdAsync(int id)
    {
      throw new NotImplementedException();
    }

    public Task<string> UpdatePurchaseInvoiceItemAsync(PurchaseInvoiceItem request)
    {
      throw new NotImplementedException();
    }
  }
}
