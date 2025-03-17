using Erp.Data.Entities;
using Erp.Data.Entities.PurchasesModule;
using Erp.Data.Entities.SalesModule;

namespace Erp.Service.Abstracts.CommonUse
{
  public interface IPaymentService
  {
    Task<string> AddSupplierPaymentAsync(SupplierPayment Item);
    Task<string> AddClientPaymentAsync(ClientPayment Item);


    Task<SupplierPayment?> GetSupplierPaymentByIdAsync(int id);

    Task<ClientPayment?> GetClientPaymentByIdAsync(int id);



    Task<List<SupplierPayment>> GetSupplierPaymentListAsync();

    Task<List<ClientPayment>> GetClientPaymentListAsync();


    Task<List<T>> GetPaymentByTypeAsync<T>() where T : Payment;



    Task<string> UpdateSupplierPaymentAsync(SupplierPayment Item);
    Task<string> UpdateClientPaymentAsync(ClientPayment Item);



    Task<string> DeletePaymentAsync(int id);




    Task<string> GetPaymentTypeByIdAsync(int ItemId);




  }
}
