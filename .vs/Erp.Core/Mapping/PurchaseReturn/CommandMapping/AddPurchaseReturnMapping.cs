using Erp.Core.Features.PurchaseReturn.Commands.Models;
using Erp.Data.Dto.PurchaseReturn;

namespace Erp.Core.Mapping.PurchaseReturn
{
  public partial class PurchaseReturnProfile
  {
    public void AddPurchaseReturnMapping()
    {
      CreateMap<AddPurchaseReturnCommand, AddPurchaseReturnRequest>()
        .ForMember(destnation => destnation.PurchaseReturnItemDT0s, opt => opt.MapFrom(src => src.PurchaseReturnItemDT0s));
    }
  }
}
