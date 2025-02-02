using Erp.Data.Entities.SalesModule;
using Erp.Data.MetaData;
using Erp.Infrastructure.Abstracts.SalesModule;
using Microsoft.EntityFrameworkCore;
using Name.Infrastructure.Bases;
using Name.Infrastructure.Data;

namespace Erp.Infrastructure.Repositories.SalesModule
{
  public class CustomerPaymentRepository : GenericRepository<CustomerPayment>, ICustomerPaymentRepository
  {
    private readonly DbSet<CustomerPayment> _CustomerPayments;
    public CustomerPaymentRepository(ApplicationDBContext dbContext) : base(dbContext)
    {
      _CustomerPayments = dbContext.Set<CustomerPayment>();

    }


    public async Task<string> AddCustomerPaymentAsync(CustomerPayment CustomerPayment)
    {
      var result = await _CustomerPayments.AddAsync(CustomerPayment);

      if (result == null)
      {
        return "Cant Add";
      }
      else
      {
        return MessageCenter.CrudMessage.Success;
      }
    }

    public async Task<CustomerPayment> GetCustomerPaymentByIdAsync(int id)
    {
      return await _CustomerPayments.FindAsync(id);

    }

    public async Task<List<CustomerPayment>> GetCustomerPaymentsListAsync()
    {
      return await _CustomerPayments.ToListAsync();
    }

    public async Task<string> UpdateCustomerPaymentAsync(CustomerPayment request)
    {
      var result = _CustomerPayments.Update(request);

      return MessageCenter.CrudMessage.Success;
    }
  }
}
