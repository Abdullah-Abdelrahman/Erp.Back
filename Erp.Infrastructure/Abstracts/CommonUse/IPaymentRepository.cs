using Erp.Data.Entities;
using Name.Infrastructure.Bases;

namespace Erp.Infrastructure.Abstracts.CommonUse
{
  public interface IPaymentRepository<TP> : IGenericRepository<TP> where TP : Payment
  {
    Task<string> AddPaymentAsync(TP Item);
    Task<TP?> GetPaymentByIdAsync(int id);
    Task<List<TP>> GetPaymentsListAsync();
    Task<string> UpdatePaymentAsync(TP Item);
    Task<List<T>> GetPaymentsByTypeAsync<T>() where T : Payment;
  }

}
