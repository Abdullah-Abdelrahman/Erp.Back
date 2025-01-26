using Erp.Data.Dto.PurchaseInvoice;
using Erp.Data.Entities;

namespace Erp.Service.Abstracts
{
  public interface IPurchaseInvoiceService
  {
    public Task<List<GetPurchaseInvoiceByIdDto>> GetPurchaseInvoicesListAsync();

    public Task<GetPurchaseInvoiceByIdDto> GetPurchaseInvoiceByIdAsync(int id);

    public Task<string> AddPurchaseInvoice(AddPurchaseInvoiceRequest PurchaseInvoice);

    public Task<string> UpdateAsync(UpdatePurchaseInvoiceRequest PurchaseInvoice);

    public Task<string> DeleteAsync(PurchaseInvoice PurchaseInvoice);
    public Task<string> DeleteByIdAsync(int id);
  }
}
