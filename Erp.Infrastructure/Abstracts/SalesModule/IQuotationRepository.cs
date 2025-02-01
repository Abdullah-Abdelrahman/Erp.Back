using Erp.Data.Entities.SalesModule;
using Name.Infrastructure.Bases;

namespace Erp.Infrastructure.Abstracts.SalesModule
{
  public interface IQuotationRepository : IGenericRepository<Quotation>
  {
    public Task<string> AddQuotationAsync(Quotation Quotation);

    public Task<Quotation> GetQuotationByIdAsync(int id);

    public Task<string> UpdateQuotationAsync(Quotation request);
  }
}
