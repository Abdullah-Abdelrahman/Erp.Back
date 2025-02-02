using Erp.Data.Entities.SalesModule;

namespace Erp.Service.Abstracts.SalesModule
{
  public interface ICustomerPaymentService
  {
    public Task<List<CustomerPayment>> GetCustomerPaymentsListAsync();

    public Task<CustomerPayment> GetCustomerPaymentByIdAsync(int id);

    public Task<string> AddCustomerPaymentAsync(CustomerPayment CustomerPayment);

    public Task<string> UpdateAsync(CustomerPayment CustomerPayment);

    public Task<string> DeleteAsync(CustomerPayment CustomerPayment);
  }
}
