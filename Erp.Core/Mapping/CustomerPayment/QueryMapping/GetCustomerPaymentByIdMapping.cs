using Erp.Core.Features.CustomerPayment.Queries.Results;
using Entitis = Erp.Data.Entities.SalesModule;
namespace Erp.Core.Mapping.CustomerPayment
{
  public partial class CustomerPaymentProfile
  {
    public void GetCustomerPaymentByIdMapping()
    {
      CreateMap<Entitis.CustomerPayment, GetCustomerPaymentByIdResult>().
        ForMember(destnation => destnation.CustomerId, opt => opt.MapFrom(src => src.Customer.CustomerId));
    }
  }
}
