using Erp.Data.Entities.PurchasesModule;
using Erp.Infrastructure.Abstracts;
using Microsoft.EntityFrameworkCore;
using Name.Infrastructure.Bases;
using Name.Infrastructure.Data;

namespace Erp.Infrastructure.Repositories
{
  public class PurchaseInvoiceRepository : GenericRepository<PurchaseInvoice>, IPurchaseInvoiceRepository
  {
    private readonly DbSet<PurchaseInvoice> _PurchaseInvoices;
    public PurchaseInvoiceRepository(ApplicationDBContext dbContext) : base(dbContext)
    {
      _PurchaseInvoices = dbContext.Set<PurchaseInvoice>();
    }

    public Task<string> AddPurchaseInvoiceAsync(PurchaseInvoice PurchaseInvoice)
    {
      throw new NotImplementedException();
    }

    public Task<PurchaseInvoice> GetPurchaseInvoiceByIdAsync(int id)
    {
      throw new NotImplementedException();
    }

    public Task<string> UpdatePurchaseInvoiceAsync(PurchaseInvoice request)
    {
      throw new NotImplementedException();
    }
  }
}
