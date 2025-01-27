using Erp.Core.Features.TransformVoucher.Commands.Models;
using Erp.Data.Dto.TransformVoucher;

namespace Erp.Core.Mapping.TransformVoucher
{
  public partial class TransformVoucherProfile
  {
    public void AddTransformVoucherMapping()
    {
      CreateMap<AddTransformVoucherCommand, AddTransformVoucherRequest>()
        .ForMember(destnation => destnation.TransformVoucherItemDT0s, opt => opt.MapFrom(src => src.TransformVoucherItemDT0s));
    }
  }
}
