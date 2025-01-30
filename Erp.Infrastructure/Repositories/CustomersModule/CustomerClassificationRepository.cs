using Erp.Data.Entities.CustomersModule;
using Erp.Infrastructure.Abstracts.CustomersModule;
using Microsoft.EntityFrameworkCore;
using Name.Infrastructure.Bases;
using Name.Infrastructure.Data;

namespace Erp.Infrastructure.Repositories.CustomersModule
{
  public class CustomerClassificationRepository : GenericRepository<CustomerClassification>, ICustomerClassificationRepository
  {
    private readonly DbSet<CustomerClassification> _CustomerClassifications;
    public CustomerClassificationRepository(ApplicationDBContext dbContext) : base(dbContext)
    {
      _CustomerClassifications = dbContext.Set<CustomerClassification>();
    }

    public Task<string> AddCustomerClassificationAsync(CustomerClassification CustomerClassification)
    {
      throw new NotImplementedException();
    }

    public Task<CustomerClassification> GetCustomerClassificationByIdAsync(int id)
    {
      throw new NotImplementedException();
    }

    public Task<string> UpdateCustomerClassificationAsync(CustomerClassification request)
    {
      throw new NotImplementedException();
    }
  }
}
