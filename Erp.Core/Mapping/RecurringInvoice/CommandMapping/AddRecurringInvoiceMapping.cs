using Erp.Core.Features.RecurringInvoice.Commands.Models;
using Erp.Data.Dto.RecurringInvoice;

namespace Erp.Core.Mapping.RecurringInvoice
{
  public partial class RecurringInvoiceProfile
  {
    public void AddRecurringInvoiceMapping()
    {
      CreateMap<AddRecurringInvoiceCommand, AddRecurringInvoiceRequest>()
        .ForMember(destnation => destnation.RecurringInvoiceItemDT0s, opt => opt.MapFrom(src => src.RecurringInvoiceItemDT0s));
    }
  }
}
