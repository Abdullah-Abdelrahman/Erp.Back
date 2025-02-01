using Erp.Core.Features.Invoice.Commands.Models;
using Erp.Data.Dto.Invoice;

namespace Erp.Core.Mapping.Invoice
{
  public partial class InvoiceProfile
  {
    public void AddInvoiceMapping()
    {
      CreateMap<AddInvoiceCommand, AddInvoiceRequest>()
        .ForMember(destnation => destnation.InvoiceItemDT0s, opt => opt.MapFrom(src => src.InvoiceItemDT0s));
    }
  }
}
