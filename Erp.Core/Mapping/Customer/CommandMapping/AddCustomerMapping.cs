using Erp.Core.Features.Customer.Commands.Models;
using Entitis = Erp.Data.Entities;
namespace Erp.Core.Mapping.Customer
{
  public partial class CustomerProfile
  {
    public void AddCustomerMapping()
    {
      CreateMap<AddCustomerCommand, Entitis.CustomersModule.Customer>()
             .ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom(src => src.PhoneNumber));

      CreateMap<AddCustomerCommand, Entitis.CustomersModule.CommercialCustomer>()
          .ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom(src => src.PhoneNumber));

      CreateMap<AddCustomerCommand, Entitis.CustomersModule.IndividualCustomer>()
          .ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom(src => src.PhoneNumber));
    }
  }
}
