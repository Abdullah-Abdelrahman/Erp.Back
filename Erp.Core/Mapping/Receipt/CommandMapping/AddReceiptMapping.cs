using Erp.Core.Features.Receipt.Commands.Models;
using Erp.Data.Dto.Receipt;

namespace Erp.Core.Mapping.Receipt
{
  public partial class ReceiptProfile
  {
    public void AddReceiptMapping()
    {
      CreateMap<AddReceiptCommand, AddReceiptRequest>()
        .ForMember(destnation => destnation.ReceiptCostCenterDtos, opt => opt.MapFrom(src => src.ReceiptCostCenterDtos));
    }
  }
}
