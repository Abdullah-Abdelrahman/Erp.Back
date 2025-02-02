using Erp.Core.Features.CustomerPayment.Commands.Models;
using Entitis = Erp.Data.Entities.SalesModule;
namespace Erp.Core.Mapping.CustomerPayment
{
  public partial class CustomerPaymentProfile
  {
    public void AddCustomerPaymentMapping()
    {
      CreateMap<AddCustomerPaymentCommand, Entitis.CustomerPayment>()
        .ForMember(destnation => destnation.CustomerId, opt => opt.MapFrom(src => src.CustomerId));
    }
  }
}
