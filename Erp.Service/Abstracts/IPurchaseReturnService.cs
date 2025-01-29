using Erp.Data.Dto.PurchaseReturn;
using Erp.Data.Entities.PurchasesModule;

namespace Erp.Service.Abstracts
{
  public interface IPurchaseReturnService
  {
    public Task<List<GetPurchaseReturnByIdDto>> GetPurchaseReturnsListAsync();

    public Task<GetPurchaseReturnByIdDto> GetPurchaseReturnByIdAsync(int id);

    public Task<string> AddPurchaseReturn(AddPurchaseReturnRequest PurchaseReturn);

    public Task<string> UpdateAsync(UpdatePurchaseReturnRequest PurchaseReturn);

    public Task<string> DeleteAsync(PurchaseReturn PurchaseReturn);
    public Task<string> DeleteByIdAsync(int id);
  }
}
