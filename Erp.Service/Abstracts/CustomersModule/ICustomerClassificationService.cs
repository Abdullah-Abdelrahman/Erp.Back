using Erp.Data.Entities.CustomersModule;

namespace Erp.Service.Abstracts.CustomersModule
{
  public interface ICustomerClassificationService
  {
    public Task<List<CustomerClassification>> GetCustomerClassificationsListAsync();

    public Task<CustomerClassification> GetCustomerClassificationByIdAsync(int id);

    public Task<string> AddCustomerClassificationAsync(CustomerClassification CustomerClassification);

    public Task<string> UpdateAsync(CustomerClassification CustomerClassification);

    public Task<string> DeleteAsync(CustomerClassification CustomerClassification);
  }
}
