using Erp.Data.Entities.CustomersModule;
using Name.Infrastructure.Bases;

namespace Erp.Infrastructure.Abstracts.CustomersModule
{
  public interface IContactListRepository : IGenericRepository<ContactList>
  {
    public Task<string> AddContactListAsync(ContactList ContactList);

    public Task<ContactList> GetContactListByIdAsync(int id);

    public Task<List<ContactList>> GetContactListsListAsync();

    public Task<string> UpdateContactListAsync(ContactList request);
  }
}
