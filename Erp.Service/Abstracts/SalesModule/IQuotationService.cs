using Erp.Data.Dto.Quotation;
using Erp.Data.Entities.SalesModule;

namespace Erp.Service.Abstracts.SalesModule
{
  public interface IQuotationService
  {
    public Task<List<GetQuotationByIdDto>> GetQuotationsListAsync();

    public Task<GetQuotationByIdDto> GetQuotationByIdAsync(int id);

    public Task<string> AddQuotation(AddQuotationRequest Quotation);

    public Task<string> UpdateAsync(UpdateQuotationRequest Quotation);

    public Task<string> DeleteAsync(Quotation Quotation);
    public Task<string> DeleteByIdAsync(int id);
  }
}
