using Erp.Core.Features.PurchaseInvoice.Commands.Models;
using Erp.Data.Dto.PurchaseInvoice;

namespace Erp.Core.Mapping.PurchaseInvoice
{
  public partial class PurchaseInvoiceProfile
  {
    public void AddPurchaseInvoiceMapping()
    {
      CreateMap<AddPurchaseInvoiceCommand, AddPurchaseInvoiceRequest>()
        .ForMember(destnation => destnation.PurchaseInvoiceItemDT0s, opt => opt.MapFrom(src => src.PurchaseInvoiceItemDT0s));
    }
  }
}
