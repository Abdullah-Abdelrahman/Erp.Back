using Erp.Data.Dto.Receipt;
using Erp.Data.Entities.Finance;

namespace Erp.Service.Abstracts.Finance
{
  public interface IReceiptService
  {
    public Task<List<GetReceiptByIdDto>> GetReceiptsListAsync();

    public Task<GetReceiptByIdDto> GetReceiptByIdAsync(int id);

    public Task<string> AddReceipt(AddReceiptRequest Receipt);

    public Task<string> UpdateAsync(UpdateReceiptRequest Receipt);

    public Task<string> DeleteAsync(Receipt Receipt);
    public Task<string> DeleteByIdAsync(int id);
  }
}
