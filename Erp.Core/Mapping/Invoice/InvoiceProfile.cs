using AutoMapper;

namespace Erp.Core.Mapping.Invoice
{
  public partial class InvoiceProfile : Profile
  {
    public InvoiceProfile()
    {
      AddInvoiceMapping();
    }
  }
}
