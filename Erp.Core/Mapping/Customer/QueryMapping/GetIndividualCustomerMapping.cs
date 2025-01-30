using Erp.Data.Dto.Customer;
using Erp.Data.Entities.CustomersModule;

namespace Erp.Core.Mapping.Customer
{
  public partial class CustomerProfile
  {
    public void GetIndividualCustomerMapping()
    {
      CreateMap<IndividualCustomer, GetIndividualCustomerByIdDto>()
                .ForMember(dest => dest.contactListDT0s, opt => opt.MapFrom(src => src.ContactLists));
    }
  }
}
