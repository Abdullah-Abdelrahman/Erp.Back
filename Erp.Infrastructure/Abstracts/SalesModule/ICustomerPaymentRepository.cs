using Erp.Data.Entities.SalesModule;
using Name.Infrastructure.Bases;

namespace Erp.Infrastructure.Abstracts.SalesModule
{
  public interface ICustomerPaymentRepository : IGenericRepository<CustomerPayment>
  {
    public Task<string> AddCustomerPaymentAsync(CustomerPayment CustomerPayment);

    public Task<CustomerPayment> GetCustomerPaymentByIdAsync(int id);

    public Task<List<CustomerPayment>> GetCustomerPaymentsListAsync();

    public Task<string> UpdateCustomerPaymentAsync(CustomerPayment request);
  }
}
