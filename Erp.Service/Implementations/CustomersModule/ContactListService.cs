using Erp.Data.Entities.CustomersModule;
using Erp.Data.MetaData;
using Erp.Infrastructure.Abstracts.CustomersModule;
using Erp.Service.Abstracts.CustomersModule;
using Microsoft.EntityFrameworkCore;
using Name.Service.Abstracts;

namespace Erp.Service.Implementations.CustomersModule
{
  public class ContactListService : IContactListService
  {


    private readonly IContactListRepository _ContactListRepository;

    private readonly IFileService _FileService;
    public ContactListService(IContactListRepository ContactListRepository, IFileService fileService)
    {
      _ContactListRepository = ContactListRepository;
      _FileService = fileService;
    }

    public async Task<string> AddContactListAsync(ContactList ContactList)
    {

      var newCourse = await _ContactListRepository.AddAsync(ContactList);
      if (newCourse != null)
      {
        return MessageCenter.CrudMessage.Success;
      }
      else
      {
        return "Somthing bad happend :";
      }
    }

    public async Task<string> DeleteAsync(ContactList ContactList)
    {
      try
      {
        await _ContactListRepository.DeleteAsync(ContactList);
        return MessageCenter.CrudMessage.Success;
      }
      catch (Exception ex)
      {
        return "There is a problem in deleteing the ContactList : " + ex.Message;
      }

    }

    public async Task<ContactList> GetContactListByIdAsync(int id)
    {
      var ContactList = await _ContactListRepository.GetTableNoTracking().Where(x => x.ContactListId == id).Include(p => p.Customer).SingleOrDefaultAsync();

      return ContactList;
    }

    public async Task<List<ContactList>> GetContactListsListAsync()
    {
      var ContactLists = await _ContactListRepository.GetTableNoTracking().Include(c => c.Customer).ToListAsync();

      return ContactLists;
    }

    public async Task<string> UpdateAsync(ContactList ContactList)
    {
      var transact = _ContactListRepository.BeginTransaction();
      try
      {
        await _ContactListRepository.UpdateAsync(ContactList);

        await transact.CommitAsync();
        return MessageCenter.CrudMessage.Success;

      }
      catch
      {
        await transact.RollbackAsync();
        return MessageCenter.CrudMessage.Falied;
      }
    }
  }
}
