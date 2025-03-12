using Erp.Data.Dto.Customer;
using Erp.Data.Entities.AccountsModule;
using Erp.Data.Entities.CustomersModule;
using Erp.Data.MetaData;
using Erp.Infrastructure.Abstracts.AccountsModule;
using Erp.Infrastructure.Abstracts.CustomersModule;
using Erp.Service.Abstracts.AccountsModule;
using Erp.Service.Abstracts.CustomersModule;
using Microsoft.EntityFrameworkCore;

namespace Erp.Service.Implementations.CustomersModule
{
  public class CustomerService : ICustomerService
  {
    private readonly ICustomerRepository<Customer> _CustomerRepository;
    private readonly ICustomerRepository<CommercialCustomer> _CommercialCustomerRepository;
    private readonly ICustomerRepository<IndividualCustomer> _IndividualCustomerRepository;
    private readonly IContactListRepository _contactListRepository;
    private readonly IAccountRepository<SecondaryAccount> _SecondaryAccountRepository;
    private readonly IAccountRepository<PrimaryAccount> _PrimaryAccountRepository;
    private readonly IAccountService _accountService;

    // Constructor that injects the repository
    public CustomerService(ICustomerRepository<Customer> CustomerRepository, ICustomerRepository<CommercialCustomer> CommercialCustomerRepository,
        ICustomerRepository<IndividualCustomer> IndividualCustomerRepository,
        IContactListRepository contactListRepository,
        IAccountRepository<SecondaryAccount> SecondaryAccountRepository,
        IAccountRepository<PrimaryAccount> PrimaryAccountRepository,
        IAccountService accountService)
    {
      _CustomerRepository = CustomerRepository;

      _CommercialCustomerRepository = CommercialCustomerRepository;
      _IndividualCustomerRepository = IndividualCustomerRepository;
      _contactListRepository = contactListRepository;
      _SecondaryAccountRepository = SecondaryAccountRepository;
      _PrimaryAccountRepository = PrimaryAccountRepository;
      _accountService = accountService;
    }

    public async Task<string> AddCustomerAsync(AddCustomerRequest request)
    {

      var transact = _CustomerRepository.BeginTransaction();
      try
      {
        int CustomerId;
        string CustomerName;
        if (request.commercialOrIndividual == CommercialOrIndividual.Commercial)
        {
          var customer = new IndividualCustomer(request);
          CustomerName = customer.FullName;
          var acc = new SecondaryAccount()
          {
            AccountName = CustomerName,
            Type = AccountType.debtor,
            Balance = 0,
            ParentAccountID = (await _PrimaryAccountRepository.GetTableNoTracking().Where(a => a.AccountName == "Customers").SingleOrDefaultAsync())?.AccountID,
            IsActive = true,
            CreatedDate = DateTime.UtcNow,
          };
          await _accountService.AddAccountAsync(acc);

          customer.AccountId = acc.AccountID;
          var result = await _CustomerRepository.AddAsync(customer);
          CustomerId = result.CustomerId;

        }
        else if (request.commercialOrIndividual == CommercialOrIndividual.Individual)
        {
          var customer = new CommercialCustomer(request);
          CustomerName = customer.CommercialName;

          var acc = new SecondaryAccount()
          {
            AccountName = CustomerName,
            Type = AccountType.debtor,
            Balance = 0,
            ParentAccountID = (await _PrimaryAccountRepository.GetTableNoTracking().Where(a => a.AccountName == "Customers").SingleOrDefaultAsync())?.AccountID,
            IsActive = true,
            CreatedDate = DateTime.UtcNow,
          };
          await _accountService.AddAccountAsync(acc);

          customer.AccountId = acc.AccountID;
          var result = await _CustomerRepository.AddAsync(customer);
          CustomerId = result.CustomerId;
        }
        else
        {
          return "Unknown Type of Customer ";
        }
        foreach (var item in request.contactListDT0s)
        {
          var contactList = new ContactList(item, CustomerId);

          await _contactListRepository.AddAsync(contactList);
        }

        await transact.CommitAsync();
        return MessageCenter.CrudMessage.Success;

      }
      catch (Exception ex)
      {
        await transact.RollbackAsync();
        return MessageCenter.CrudMessage.Falied + ex.Message;
      }


    }

    public async Task<CommercialCustomer?> GetCommercialCustomerByIdAsync(int id)
    {
      try
      {
        var result = await _CommercialCustomerRepository.GetTableNoTracking().Where(x => x.CustomerId == id).Include(c => c.ContactLists).SingleOrDefaultAsync();

        return result;
      }
      catch
      {
        return null;
      }
    }


    public async Task<string> UpdateCustomerAsync(UpdateCustomerRequest request)
    {
      try
      {
        int CustomerId;

        if (request.commercialOrIndividual == CommercialOrIndividual.Commercial)
        {
          var customer = new IndividualCustomer(request);
          await _CustomerRepository.UpdateAsync(customer);


        }
        else if (request.commercialOrIndividual == CommercialOrIndividual.Individual)
        {
          var customer = new CommercialCustomer(request);
          await _CustomerRepository.UpdateAsync(customer);


        }
        else
        {
          return "Unknown Type of Customer ";
        }


        foreach (var item in request.contactListDT0s)
        {
          var contactList = new ContactList(item);

          await _contactListRepository.UpdateAsync(contactList);
        }
        return MessageCenter.CrudMessage.Success;
      }
      catch (Exception ex)
      {

        return MessageCenter.CrudMessage.Falied + ex.Message;

      }
    }

    public async Task<string> DeleteCustomerAsync(int id)
    {
      try
      {
        var Customer = await _CustomerRepository.GetCustomerByIdAsync(id);
        if (Customer != null)
        {


          await _CustomerRepository.DeleteAsync(Customer);
          return MessageCenter.CrudMessage.Success;

        }
        return MessageCenter.CrudMessage.DoesNotExist;
      }
      catch (Exception ex)
      {
        return MessageCenter.CrudMessage.Falied + ex.InnerException;
      }
    }

    public async Task<List<T>> GetCustomersByTypeAsync<T>() where T : Customer
    {
      try
      {
        return await _CustomerRepository.GetCustomersByTypeAsync<T>();
      }
      catch
      {
        return new List<T>();
      }
    }

    public async Task<string> GetCustomerTypeByIdAsync(int CustomerId)
    {
      var CommercialCustomer = await _CommercialCustomerRepository.GetCustomerByIdAsync(CustomerId);
      if (CommercialCustomer != null) return "Commercial";

      var IndividualCustomer = await _IndividualCustomerRepository.GetCustomerByIdAsync(CustomerId);
      if (IndividualCustomer != null) return "Individual";

      return "Unknown";
    }

    public async Task<IndividualCustomer?> GetIndividualCustomerByIdAsync(int id)
    {
      try
      {
        var result = await _IndividualCustomerRepository.GetTableNoTracking().Where(x => x.CustomerId == id).SingleOrDefaultAsync();

        result.ContactLists = await _contactListRepository.GetTableAsTracking().Where(x => x.CustomerId == result.CustomerId).ToListAsync();


        return result;
      }
      catch
      {
        return null;
      }
    }


    public async Task<Customer?> GetCustomerByIdAsync(int id)
    {
      return await _CustomerRepository.GetByIdAsync(id);
    }

    public async Task<List<GetCustomerListResponse>> GetCustomerListAsync()
    {
      var customers = _CustomerRepository.GetTableNoTracking().ToList();

      var dtoList = new List<GetCustomerListResponse>();

      dtoList.AddRange(customers.Select(x => new GetCustomerListResponse()
      {
        CustomerId = x.CustomerId,
        Email = x.Email,
        PhoneNumber = x.PhoneNumber,
        ClassificationId = x.ClassificationId,

      }));

      return dtoList;
    }
  }
}
