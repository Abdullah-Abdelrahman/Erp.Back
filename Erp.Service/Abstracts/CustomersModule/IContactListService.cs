using Erp.Data.Entities.CustomersModule;

namespace Erp.Service.Abstracts.CustomersModule
{
  public interface IContactListService
  {
    public Task<List<ContactList>> GetContactListsListAsync();

    public Task<ContactList> GetContactListByIdAsync(int id);

    public Task<string> AddContactListAsync(ContactList ContactList);

    public Task<string> UpdateAsync(ContactList ContactList);

    public Task<string> DeleteAsync(ContactList ContactList);
  }
}
