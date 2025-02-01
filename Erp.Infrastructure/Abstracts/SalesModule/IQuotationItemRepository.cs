using Erp.Data.Entities.SalesModule;
using Name.Infrastructure.Bases;

namespace Erp.Infrastructure.Abstracts.SalesModule
{
  public interface IQuotationItemRepository : IGenericRepository<QuotationItem>
  {
    public Task<string> AddQuotationItemAsync(QuotationItem QuotationItem);

    public Task<QuotationItem> GetQuotationItemByIdAsync(int id);

    public Task<string> UpdateQuotationItemAsync(QuotationItem request);
  }
}
