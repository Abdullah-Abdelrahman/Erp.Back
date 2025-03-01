using Erp.Data.Entities.Finance;
using Erp.Data.MetaData;
using Erp.Infrastructure.Abstracts.Finance;
using Microsoft.EntityFrameworkCore;
using Name.Infrastructure.Bases;
using Name.Infrastructure.Data;

namespace Erp.Infrastructure.Repositories.Finance
{
  public class ReceiptRepository : GenericRepository<Receipt>, IReceiptRepository
  {
    private readonly DbSet<Receipt> _Receipts;
    public ReceiptRepository(ApplicationDBContext dbContext) : base(dbContext)
    {
      _Receipts = dbContext.Set<Receipt>();

    }


    public async Task<string> AddReceiptAsync(Receipt Receipt)
    {
      var result = await _Receipts.AddAsync(Receipt);

      if (result == null)
      {
        return "Cant Add";
      }
      else
      {
        return MessageCenter.CrudMessage.Success;
      }
    }

    public async Task<Receipt?> GetReceiptByIdAsync(int id)
    {
      return await _Receipts.FindAsync(id);

    }

    public async Task<List<Receipt>> GetReceiptsListAsync()
    {
      return await _Receipts.ToListAsync();
    }

    public async Task<string> UpdateReceiptAsync(Receipt request)
    {
      var result = _Receipts.Update(request);

      return MessageCenter.CrudMessage.Success;
    }
  }
}
