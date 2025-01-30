using AutoMapper;

namespace Erp.Core.Mapping.ContactList
{
  public partial class ContactListProfile : Profile
  {
    public ContactListProfile()
    {
      AddContactListMapping();



      GetContactListByIdMapping();
    }
  }
}
