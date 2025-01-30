using Erp.Data.Entities.CustomersModule;
using Name.Infrastructure.Bases;

namespace Erp.Infrastructure.Abstracts.CustomersModule
{
  public interface ICustomerRepository<TCustomer> : IGenericRepository<TCustomer> where TCustomer : Customer
  {
    Task<string> AddCustomerAsync(TCustomer Customer);
    Task<TCustomer?> GetCustomerByIdAsync(int id);
    Task<List<TCustomer>> GetCustomersListAsync();
    Task<string> UpdateCustomerAsync(TCustomer Customer);
    Task<List<T>> GetCustomersByTypeAsync<T>() where T : Customer;
  }
}
