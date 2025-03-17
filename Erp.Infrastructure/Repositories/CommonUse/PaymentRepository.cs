using Erp.Data.Entities;
using Erp.Data.MetaData;
using Erp.Infrastructure.Abstracts.CommonUse;
using Microsoft.EntityFrameworkCore;
using Name.Infrastructure.Bases;
using Name.Infrastructure.Data;

namespace Erp.Infrastructure.Repositories.CommonUse
{
  public class PaymentRepository<TP> : GenericRepository<TP>, IPaymentRepository<TP> where TP : Payment
  {
    private readonly DbSet<TP> _Items;

    public PaymentRepository(ApplicationDBContext dbContext) : base(dbContext)
    {
      _Items = dbContext.Set<TP>();
    }

    public async Task<string> AddPaymentAsync(TP Item)
    {
      await _Items.AddAsync(Item);
      await _dbContext.SaveChangesAsync(); // Ensure changes are saved

      return MessageCenter.CrudMessage.Success;
    }

    public async Task<TP?> GetPaymentByIdAsync(int id)
    {
      return await _Items.FindAsync(id);
    }

    public async Task<List<T>> GetPaymentsByTypeAsync<T>() where T : Payment
    {
      return await _Items.OfType<T>().ToListAsync();
    }

    public async Task<List<TP>> GetPaymentsListAsync()
    {
      return await _Items.ToListAsync();
    }

    public async Task<string> UpdatePaymentAsync(TP Item)
    {
      _Items.Update(Item);
      await _dbContext.SaveChangesAsync();

      return MessageCenter.CrudMessage.Success;
    }
  }
}
