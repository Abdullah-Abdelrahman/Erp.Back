using Erp.Core.Features.Payment.Queries.Results;
using Erp.Data.Entities.PurchasesModule;
namespace Erp.Core.Mapping.Payment
{
  public partial class PaymentProfile
  {
    public void GetSupplierPaymentByIdMapping()
    {
      CreateMap<SupplierPayment, GetSupplierPaymentByIdResult>().
        ForMember(destnation => destnation.SupplierName, opt => opt.MapFrom(src => src.SupplierName));

    }
  }
}
