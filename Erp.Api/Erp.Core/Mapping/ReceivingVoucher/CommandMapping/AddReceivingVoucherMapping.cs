using Erp.Core.Features.ReceivingVoucher.Commands.Models;
using Erp.Data.Dto.ReceivingVoucher;

namespace Erp.Core.Mapping.ReceivingVoucher
{
  public partial class ReceivingVoucherProfile
  {
    public void AddReceivingVoucherMapping()
    {
      CreateMap<AddReceivingVoucherCommand, AddReceivingVoucherRequest>()
        .ForMember(destnation => destnation.receivingVoucherItemDT0s, opt => opt.MapFrom(src => src.receivingVoucherItemDT0s));
    }
  }
}
