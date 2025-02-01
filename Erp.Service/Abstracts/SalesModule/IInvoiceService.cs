using Erp.Data.Dto.Invoice;
using Erp.Data.Entities.SalesModule;

namespace Erp.Service.Abstracts.SalesModule
{
  public interface IInvoiceService
  {
    public Task<List<GetInvoiceByIdDto>> GetInvoicesListAsync();

    public Task<GetInvoiceByIdDto> GetInvoiceByIdAsync(int id);

    public Task<string> AddInvoice(AddInvoiceRequest Invoice);

    public Task<string> UpdateAsync(UpdateInvoiceRequest Invoice);

    public Task<string> DeleteAsync(Invoice Invoice);
    public Task<string> DeleteByIdAsync(int id);
  }
}
