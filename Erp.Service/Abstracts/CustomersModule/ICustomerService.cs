using Erp.Data.Dto.Customer;
using Erp.Data.Entities.CustomersModule;

namespace Erp.Service.Abstracts.CustomersModule
{
  public interface ICustomerService
  {
    Task<string> AddCustomerAsync(AddCustomerRequest Customer);


    Task<CommercialCustomer?> GetCommercialCustomerByIdAsync(int id);


    Task<IndividualCustomer?> GetIndividualCustomerByIdAsync(int id);


    Task<string> UpdateCustomerAsync(UpdateCustomerRequest Customer);


    Task<string> DeleteCustomerAsync(int id);

    Task<List<T>> GetCustomersByTypeAsync<T>() where T : Customer;

    Task<string> GetCustomerTypeByIdAsync(int CustomerId);

    Task<Customer?> GetCustomerByIdAsync(int id);
  }
}
