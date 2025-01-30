using AutoMapper;

namespace Erp.Core.Mapping.Customer
{
  public partial class CustomerProfile : Profile
  {
    public CustomerProfile()
    {
      AddCustomerMapping();


      GetCommercialCustomerMapping();
      GetIndividualCustomerMapping();
    }
  }
}
