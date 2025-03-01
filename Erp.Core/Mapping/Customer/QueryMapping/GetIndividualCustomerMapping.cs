using Erp.Data.Dto.Customer;
using Erp.Data.Entities.CustomersModule;
using E = Erp.Data.Entities.CustomersModule;
namespace Erp.Core.Mapping.Customer
{
  public partial class CustomerProfile
  {
    public void GetIndividualCustomerMapping()
    {
      CreateMap<E.ContactList, GetContactListDT0>()
                .ForMember(dest => dest.CustomerId, opt => opt.MapFrom(src => src.CustomerId));
      CreateMap<IndividualCustomer, GetIndividualCustomerByIdDto>()
                .ForMember(dest => dest.contactListDT0s, opt => opt.MapFrom(src => src.ContactLists.ToList()));
    }
  }
}
