using Erp.Data.Entities.PurchasesModule;
using Name.Infrastructure.Bases;

namespace Erp.Infrastructure.Abstracts
{
  public interface IPurchaseInvoiceItemRepository : IGenericRepository<PurchaseInvoiceItem>
  {
    public Task<string> AddPurchaseInvoiceItemAsync(PurchaseInvoiceItem PurchaseInvoiceItem);

    public Task<PurchaseInvoiceItem> GetPurchaseInvoiceItemByIdAsync(int id);

    public Task<string> UpdatePurchaseInvoiceItemAsync(PurchaseInvoiceItem request);
  }
}
