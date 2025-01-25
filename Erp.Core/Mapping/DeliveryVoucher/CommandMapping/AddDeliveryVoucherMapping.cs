using Erp.Core.Features.DeliveryVoucher.Commands.Models;
using Erp.Data.Dto.DeliveryVoucher;

namespace Erp.Core.Mapping.DeliveryVoucher
{
  public partial class DeliveryVoucherProfile
  {
    public void AddDeliveryVoucherMapping()
    {
      CreateMap<AddDeliveryVoucherCommand, AddDeliveryVoucherRequest>()
        .ForMember(destnation => destnation.DeliveryVoucherItemDT0s, opt => opt.MapFrom(src => src.DeliveryVoucherItemDT0s));
    }
  }
}
