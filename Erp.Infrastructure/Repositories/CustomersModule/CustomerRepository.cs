using Erp.Data.Entities.CustomersModule;
using Erp.Data.MetaData;
using Erp.Infrastructure.Abstracts.CustomersModule;
using Microsoft.EntityFrameworkCore;
using Name.Infrastructure.Bases;
using Name.Infrastructure.Data;

namespace Erp.Infrastructure.Repositories.CustomersModule
{
  public class CustomerRepository<TCustomer> : GenericRepository<TCustomer>, ICustomerRepository<TCustomer> where TCustomer : Customer
  {
    private readonly DbSet<TCustomer> _Customers;

    public CustomerRepository(ApplicationDBContext dbContext) : base(dbContext)
    {
      _Customers = dbContext.Set<TCustomer>();
    }

    public async Task<string> AddCustomerAsync(TCustomer Customer)
    {
      await _Customers.AddAsync(Customer);
      await _dbContext.SaveChangesAsync(); // Ensure changes are saved

      return MessageCenter.CrudMessage.Success;
    }

    public async Task<TCustomer?> GetCustomerByIdAsync(int id)
    {
      return await _Customers.FindAsync(id);
    }

    public async Task<List<TCustomer>> GetCustomersListAsync()
    {
      return await _Customers.ToListAsync();
    }

    public async Task<string> UpdateCustomerAsync(TCustomer Customer)
    {
      _Customers.Update(Customer);
      await _dbContext.SaveChangesAsync();

      return MessageCenter.CrudMessage.Success;
    }

    public async Task<List<T>> GetCustomersByTypeAsync<T>() where T : Customer
    {
      return await _Customers.OfType<T>().ToListAsync();
    }

  }
}
