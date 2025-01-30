using Erp.Core.Features.ContactList.Queries.Results;
using Entitis = Erp.Data.Entities;
namespace Erp.Core.Mapping.ContactList
{
  public partial class ContactListProfile
  {
    public void GetContactListByIdMapping()
    {
      CreateMap<Entitis.CustomersModule.ContactList, GetContactListByIdResult>().
        ForMember(destnation => destnation.Customer, opt => opt.MapFrom(src => src.Customer));

    }
  }
}
