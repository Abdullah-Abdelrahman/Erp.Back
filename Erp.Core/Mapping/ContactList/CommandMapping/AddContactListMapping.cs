using Erp.Core.Features.ContactList.Commands.Models;
using Entitis = Erp.Data.Entities;
namespace Erp.Core.Mapping.ContactList
{
  public partial class ContactListProfile
  {
    public void AddContactListMapping()
    {
      CreateMap<AddContactListCommand, Entitis.CustomersModule.ContactList>()
        .ForMember(destnation => destnation.FirstName, opt => opt.MapFrom(src => src.FirstName));
    }
  }
}
