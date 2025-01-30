using Erp.Data.Entities.CustomersModule;
using Name.Infrastructure.Bases;

namespace Erp.Infrastructure.Abstracts.CustomersModule
{
  public interface ICustomerClassificationRepository : IGenericRepository<CustomerClassification>
  {
    public Task<string> AddCustomerClassificationAsync(CustomerClassification CustomerClassification);

    public Task<CustomerClassification> GetCustomerClassificationByIdAsync(int id);

    public Task<string> UpdateCustomerClassificationAsync(CustomerClassification request);
  }
}
