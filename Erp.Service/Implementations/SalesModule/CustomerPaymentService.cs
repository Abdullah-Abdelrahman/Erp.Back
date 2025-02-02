using Erp.Data.Entities.SalesModule;
using Erp.Data.MetaData;
using Erp.Infrastructure.Abstracts.SalesModule;
using Erp.Service.Abstracts.SalesModule;
using Microsoft.EntityFrameworkCore;
using Name.Service.Abstracts;

namespace Erp.Service.Implementations.SalesModule
{
  public class CustomerPaymentService : ICustomerPaymentService
  {


    private readonly ICustomerPaymentRepository _CustomerPaymentRepository;

    private readonly IFileService _FileService;
    public CustomerPaymentService(ICustomerPaymentRepository CustomerPaymentRepository, IFileService fileService)
    {
      _CustomerPaymentRepository = CustomerPaymentRepository;
      _FileService = fileService;
    }

    public async Task<string> AddCustomerPaymentAsync(CustomerPayment CustomerPayment)
    {

      var newCourse = await _CustomerPaymentRepository.AddAsync(CustomerPayment);
      if (newCourse != null)
      {
        return MessageCenter.CrudMessage.Success;
      }
      else
      {
        return "Somthing bad happend :";
      }
    }

    public async Task<string> DeleteAsync(CustomerPayment CustomerPayment)
    {
      try
      {
        await _CustomerPaymentRepository.DeleteAsync(CustomerPayment);
        return MessageCenter.CrudMessage.Success;
      }
      catch (Exception ex)
      {
        return "There is a problem in deleteing the CustomerPayment : " + ex.Message;
      }

    }

    public async Task<CustomerPayment> GetCustomerPaymentByIdAsync(int id)
    {
      var CustomerPayment = await _CustomerPaymentRepository.GetTableNoTracking().Where(x => x.Id == id).Include(p => p.Customer).SingleOrDefaultAsync();

      return CustomerPayment;
    }

    public async Task<List<CustomerPayment>> GetCustomerPaymentsListAsync()
    {
      var CustomerPayments = await _CustomerPaymentRepository.GetTableNoTracking().Include(c => c.Customer).ToListAsync();

      return CustomerPayments;
    }

    public async Task<string> UpdateAsync(CustomerPayment CustomerPayment)
    {
      var transact = _CustomerPaymentRepository.BeginTransaction();
      try
      {
        await _CustomerPaymentRepository.UpdateAsync(CustomerPayment);

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
