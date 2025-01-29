using Erp.Data.Entities.PurchasesModule;
using Name.Infrastructure.Bases;

namespace Erp.Infrastructure.Abstracts
{
  public interface IPurchaseInvoiceRepository : IGenericRepository<PurchaseInvoice>
  {
    public Task<string> AddPurchaseInvoiceAsync(PurchaseInvoice PurchaseInvoice);

    public Task<PurchaseInvoice> GetPurchaseInvoiceByIdAsync(int id);

    public Task<string> UpdatePurchaseInvoiceAsync(PurchaseInvoice request);
  }
}
