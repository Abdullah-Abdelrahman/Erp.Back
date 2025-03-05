using Erp.Data.Entities.CustomersModule;
using Erp.Data.MetaData;
using Erp.Infrastructure.Abstracts.CustomersModule;
using Erp.Service.Abstracts.CustomersModule;
using Microsoft.EntityFrameworkCore;

namespace Erp.Service.Implementations.CustomersModule
{
  public class CustomerClassificationService : ICustomerClassificationService
  {
    private readonly ICustomerClassificationRepository _CustomerClassificationRepository;


    public CustomerClassificationService(ICustomerClassificationRepository CustomerClassificationRepository)
    {
      _CustomerClassificationRepository = CustomerClassificationRepository;
    }
    public async Task<string> AddCustomerClassificationAsync(CustomerClassification CustomerClassification)
    {

      var newCustomerClassification = await _CustomerClassificationRepository.AddAsync(CustomerClassification);
      if (newCustomerClassification != null)
      {
        return MessageCenter.CrudMessage.Success;
      }
      else
      {
        return "Somthing bad happend :";
      }
    }

    public async Task<string> DeleteAsync(CustomerClassification CustomerClassification)
    {
      try
      {
        await _CustomerClassificationRepository.DeleteAsync(CustomerClassification);
        return MessageCenter.CrudMessage.Success;
      }
      catch (Exception ex)
      {
        return "There is a problem in deleteing the CustomerClassification : " + ex.Message;
      }

    }

    public async Task<string> DeleteByIdAsync(int id)
    {
      var CustomerClassification = await _CustomerClassificationRepository.GetByIdAsync(id);

      if (CustomerClassification == null)
      {
        return MessageCenter.CrudMessage.DoesNotExist;
      }
      var transact = _CustomerClassificationRepository.BeginTransaction();

      try
      {
        await _CustomerClassificationRepository.DeleteAsync(CustomerClassification);

        await transact.CommitAsync();
        return MessageCenter.CrudMessage.Success;

      }
      catch
      {
        await transact.RollbackAsync();
        return MessageCenter.CrudMessage.Falied;
      }
    }

    public async Task<CustomerClassification> GetCustomerClassificationByIdAsync(int id)
    {
      var CustomerClassification = await _CustomerClassificationRepository.GetTableNoTracking().Where(x => x.Id == id).SingleOrDefaultAsync();

      return CustomerClassification;
    }

    public async Task<List<CustomerClassification>> GetCustomerClassificationsListAsync()
    {
      var CustomerClassifications = await _CustomerClassificationRepository.GetTableNoTracking().ToListAsync();

      return CustomerClassifications;
    }

    public async Task<string> UpdateAsync(CustomerClassification CustomerClassification)
    {
      var transact = _CustomerClassificationRepository.BeginTransaction();
      try
      {
        await _CustomerClassificationRepository.UpdateAsync(CustomerClassification);

        await transact.CommitAsync();
        return MessageCenter.CrudMessage.Success;

      }
      catch
      {
        await transact.RollbackAsync();
        return MessageCenter.CrudMessage.Falied;
      }
    }
  }
}
