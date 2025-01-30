using Erp.Data.Entities.CustomersModule;
using Erp.Data.MetaData;
using Erp.Infrastructure.Abstracts.CustomersModule;
using Microsoft.EntityFrameworkCore;
using Name.Infrastructure.Bases;
using Name.Infrastructure.Data;

namespace Erp.Infrastructure.Repositories.CustomersModule
{
  public class ContactListRepository : GenericRepository<ContactList>, IContactListRepository
  {
    private readonly DbSet<ContactList> _ContactLists;
    public ContactListRepository(ApplicationDBContext dbContext) : base(dbContext)
    {
      _ContactLists = dbContext.Set<ContactList>();

    }


    public async Task<string> AddContactListAsync(ContactList ContactList)
    {
      var result = await _ContactLists.AddAsync(ContactList);

      if (result == null)
      {
        return "Cant Add";
      }
      else
      {
        return MessageCenter.CrudMessage.Success;
      }
    }

    public async Task<ContactList> GetContactListByIdAsync(int id)
    {
      return await _ContactLists.FindAsync(id);

    }

    public async Task<List<ContactList>> GetContactListsListAsync()
    {
      return await _ContactLists.ToListAsync();
    }

    public async Task<string> UpdateContactListAsync(ContactList request)
    {
      var result = _ContactLists.Update(request);

      return MessageCenter.CrudMessage.Success;
    }
  }
}
