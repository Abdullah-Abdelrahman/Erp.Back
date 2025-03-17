using Erp.Data.Entities;
using Erp.Data.Entities.AccountsModule;
using Erp.Data.Entities.PurchasesModule;
using Erp.Data.Entities.SalesModule;
using Erp.Data.MetaData;
using Erp.Infrastructure.Abstracts.AccountsModule;
using Erp.Infrastructure.Abstracts.CommonUse;
using Erp.Infrastructure.Abstracts.Finance;
using Erp.Service.Abstracts;
using Erp.Service.Abstracts.CommonUse;
using Microsoft.EntityFrameworkCore;

namespace Erp.Service.Implementations.CommonUse
{
  public class PaymentService : IPaymentService
  {

    private readonly IPaymentRepository<Payment> _paymentRepository;
    private readonly IPaymentRepository<SupplierPayment> _supplierpaymentRepository;
    private readonly IPaymentRepository<ClientPayment> _clientpaymentRepository;
    private readonly IJournalEntryRepository _journalEntryRepository;
    private readonly IJournalEntryDetailRepository _journalEntryDetailRepository;
    private readonly ISupplierService _supplierService;
    private readonly IAccountRepository<SecondaryAccount> _SecondaryAccountRepository;
    private readonly ITreasuryRepository _treasuryRepository;



    public PaymentService(IPaymentRepository<Payment> paymentRepository,
      IPaymentRepository<SupplierPayment> supplierpaymentRepository,
      IPaymentRepository<ClientPayment> clientpaymentRepository,
      IJournalEntryRepository journalEntryRepository,
      IJournalEntryDetailRepository journalEntryDetailRepository,
      ISupplierService supplierService,
      IAccountRepository<SecondaryAccount> secondaryAccountRepository,
      ITreasuryRepository treasuryRepository)
    {
      _paymentRepository = paymentRepository;
      _supplierpaymentRepository = supplierpaymentRepository;
      _clientpaymentRepository = clientpaymentRepository;
      _journalEntryRepository = journalEntryRepository;
      _journalEntryDetailRepository = journalEntryDetailRepository;
      _supplierService = supplierService;
      _SecondaryAccountRepository = secondaryAccountRepository;
      _treasuryRepository = treasuryRepository;
    }

    public async Task<string> AddSupplierPaymentAsync(SupplierPayment Item)
    {
      var transact = _paymentRepository.BeginTransaction();
      try
      {

        var des = "Payment to Supplier #";
        if (Item.Amount < 0)
        {
          des = "Supplier Payment Refund";
        }
        JournalEntry journalEntry = new JournalEntry()
        {
          EntryDate = DateTime.Now,
          Description = des
        };
        var NewJournalEntry = await _journalEntryRepository.AddAsync(journalEntry);

        Item.JournalEntryID = NewJournalEntry.JournalEntryID;
        var newItem = await _supplierpaymentRepository.AddAsync(Item);


        NewJournalEntry.Description += newItem.Id.ToString();
        await _journalEntryRepository.UpdateAsync(NewJournalEntry);

        decimal Tdebit = 0.0M, Tcredit = 0.0M;
        decimal Sdebit = 0.0M, Scredit = 0.0M;


        if (newItem.Amount > 0)
        {
          Tcredit = newItem.Amount;
          Sdebit = newItem.Amount;
        }
        else if (newItem.Amount < 0)
        {

          Tdebit = -newItem.Amount;
          Scredit = -newItem.Amount;

        }

        var TresuAccId = (await _treasuryRepository.GetTableNoTracking()
          .Where(x => x.Id == newItem.treasuryId).SingleAsync()).AccountId;

        await _journalEntryDetailRepository.AddAsync(new JournalEntryDetail()
        {
          JournalEntryID = NewJournalEntry.JournalEntryID,
          Description = des + newItem.Id.ToString(),

          AccountID = TresuAccId,
          Debit = Tdebit,
          Credit = Tcredit
        });

        var supplierAccId = (await _supplierService.GetSupplierByIdAsync(newItem.SupplierId)).AccountId;

        await _journalEntryDetailRepository.AddAsync(new JournalEntryDetail()
        {
          JournalEntryID = NewJournalEntry.JournalEntryID,

          Description = des + newItem.Id.ToString(),

          AccountID = supplierAccId,
          Debit = Sdebit,
          Credit = Scredit
        });



        await transact.CommitAsync();
        return MessageCenter.CrudMessage.Success;

      }
      catch
      {
        await transact.RollbackAsync();
        return MessageCenter.CrudMessage.Falied;
      }


    }
    public async Task<string> AddClientPaymentAsync(ClientPayment Item)
    {


      var newItem = await _clientpaymentRepository.AddAsync(Item);


      if (newItem != null)
      {
        return MessageCenter.CrudMessage.Success;
      }
      else
      {
        return "Somthing bad happend :";
      }
    }

    public async Task<string> DeletePaymentAsync(int id)
    {
      try
      {
        var Item = await _paymentRepository.GetByIdAsync(id);
        if (Item != null)
        {

          await _paymentRepository.DeleteAsync(Item);
          return MessageCenter.CrudMessage.Success;
        }
        return MessageCenter.CrudMessage.DoesNotExist;
      }
      catch
      {
        return MessageCenter.CrudMessage.Falied;
      }
    }




    public async Task<SupplierPayment?> GetSupplierPaymentByIdAsync(int id)
    {
      try
      {
        var result = await _supplierpaymentRepository.GetTableNoTracking().Where(x => x.Id == id).SingleOrDefaultAsync();


        return result;
      }
      catch
      {
        return null;
      }
    }
    public async Task<ClientPayment?> GetClientPaymentByIdAsync(int id)
    {
      try
      {
        var result = await _clientpaymentRepository.GetTableNoTracking().Where(x => x.Id == id).SingleOrDefaultAsync();


        return result;
      }
      catch
      {
        return null;
      }
    }



    public async Task<List<SupplierPayment>> GetSupplierPaymentListAsync()
    {
      var result = await _supplierpaymentRepository.GetTableNoTracking().ToListAsync();

      return result;
    }

    public async Task<List<ClientPayment>> GetClientPaymentListAsync()
    {
      var result = await _clientpaymentRepository.GetTableNoTracking().ToListAsync();

      return result;
    }


    public async Task<string> GetPaymentTypeByIdAsync(int ItemId)
    {
      var SupplierPayment = await _supplierpaymentRepository.GetByIdAsync(ItemId);
      if (SupplierPayment != null) return "SupplierPayment";

      var ClientPayment = await _clientpaymentRepository.GetByIdAsync(ItemId);
      if (ClientPayment != null) return "ClientPayment";

      return "Unknown";
    }

    public async Task<List<T>> GetPaymentByTypeAsync<T>() where T : Payment
    {
      try
      {
        return await _paymentRepository.GetPaymentsByTypeAsync<T>();
      }
      catch
      {
        return new List<T>();
      }
    }

    public Task<string> UpdateSupplierPaymentAsync(SupplierPayment Item)
    {
      throw new NotImplementedException();
    }

    public Task<string> UpdateClientPaymentAsync(ClientPayment Item)
    {
      throw new NotImplementedException();
    }
  }
}
