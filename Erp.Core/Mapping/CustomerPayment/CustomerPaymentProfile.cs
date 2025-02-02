using AutoMapper;

namespace Erp.Core.Mapping.CustomerPayment
{
  public partial class CustomerPaymentProfile : Profile
  {
    public CustomerPaymentProfile()
    {
      AddCustomerPaymentMapping();



      GetCustomerPaymentByIdMapping();
    }
  }
}
