using Erp.Data.Dto.JournalEntry;
using Erp.Data.Entities.AccountsModule;
using Erp.Data.MetaData;
using Erp.Infrastructure.Abstracts.AccountsModule;
using Erp.Service.Abstracts;
using Erp.Service.Abstracts.AccountsModule;
using Microsoft.EntityFrameworkCore;

namespace Erp.Service.Implementations.AccountsModule
{
  public class JournalEntryService : IJournalEntryService
  {
    private readonly IJournalEntryRepository _JournalEntryRepository;
    private readonly IJournalEntryDetailRepository _JournalEntryDetailRepository;
    private readonly IProductService _productService;
    private readonly IWarehouseService _warehouseService;



    // Isupplair
    public JournalEntryService(IJournalEntryRepository JournalEntryRepository, IProductService productService, IWarehouseService warehouseService, IJournalEntryDetailRepository JournalEntryDetailRepository)
    {
      _JournalEntryRepository = JournalEntryRepository;
      _JournalEntryDetailRepository = JournalEntryDetailRepository;
      _productService = productService;
      _warehouseService = warehouseService;
    }
    public async Task<string> AddJournalEntry(AddJournalEntryRequest JournalEntryRequest)
    {
      var journalEntry = new JournalEntry()
      {
        EntryDate = (DateTime)JournalEntryRequest.EntryDate,
        Description = JournalEntryRequest.Description
      };


      var transact = _JournalEntryRepository.BeginTransaction();
      try
      {
        var newJournalEntry = await _JournalEntryRepository.AddAsync(journalEntry);

        foreach (var Detail in JournalEntryRequest.JournalEntryItemDT0s)
        {
          var JournalEntryDetail = new JournalEntryDetail()
          {
            JournalEntryID = newJournalEntry.JournalEntryID,
            AccountID = Detail.AccountID,
            Description = Detail.Description,
            Debit = Detail.Debit,
            Credit = Detail.Credit,
            CostCenterId = Detail.CostCenterId,
          };

          await _JournalEntryDetailRepository.AddAsync(JournalEntryDetail);
        }




        await transact.CommitAsync();
        return MessageCenter.CrudMessage.Success;

      }
      catch
      {
        await transact.RollbackAsync();
        return MessageCenter.CrudMessage.Falied;
      }

    }

    public async Task<string> DeleteAsync(JournalEntry JournalEntry)
    {

      var transact = _JournalEntryRepository.BeginTransaction();
      try
      {
        await _JournalEntryRepository.DeleteAsync(JournalEntry);

        await transact.CommitAsync();
        return MessageCenter.CrudMessage.Success;

      }
      catch
      {
        await transact.RollbackAsync();
        return MessageCenter.CrudMessage.Falied;
      }
    }

    public async Task<GetJournalEntryByIdDto> GetJournalEntryByIdAsync(int id)
    {
      var JournalEntry = await _JournalEntryRepository.GetTableNoTracking().Where(x => x.JournalEntryID == id).Include(x => x.details).ThenInclude(r => r.CostCenter).SingleOrDefaultAsync();

      var dto = new GetJournalEntryByIdDto()
      {
        JournalEntryID = JournalEntry.JournalEntryID,
        EntryDate = JournalEntry.EntryDate,
        Description = JournalEntry.Description,
        JournalEntryItemsDto = new List<JournalEntryItemDto>()
      };

      dto.JournalEntryItemsDto.AddRange(JournalEntry.details.Select(x => new JournalEntryItemDto
      {
        JournalEntryDetailID = x.JournalEntryDetailID,
        JournalEntryID = x.JournalEntryID,
        Description = x.Description,
        AccountID = x.AccountID,
        CostCenterId = x.CostCenterId,
        Debit = x.Debit,
        Credit = x.Credit

      }));

      return dto;
    }

    public async Task<List<GetJournalEntryByIdDto>> GetJournalEntrysListAsync()
    {
      var JournalEntrys = _JournalEntryRepository.GetTableNoTracking().ToList();

      var dtoList = new List<GetJournalEntryByIdDto>();

      dtoList.AddRange(JournalEntrys.Select(x => new GetJournalEntryByIdDto()
      {
        JournalEntryID = x.JournalEntryID,
        EntryDate = x.EntryDate,
        Description = x.Description


      }));

      return dtoList;
    }

    public async Task<string> UpdateAsync(UpdateJournalEntryRequest JournalEntryRequest)
    {
      var JournalEntry = new JournalEntry()
      {
        JournalEntryID = JournalEntryRequest.JournalEntryID,
        EntryDate = JournalEntryRequest.EntryDate,
        Description = JournalEntryRequest.Description

      };


      var transact = _JournalEntryRepository.BeginTransaction();
      try
      {
        await _JournalEntryRepository.UpdateAsync(JournalEntry);

        foreach (var Detail in JournalEntryRequest.JournalEntryItems)
        {
          var JournalEntryDetail = new JournalEntryDetail()
          {
            JournalEntryID = JournalEntryRequest.JournalEntryID,
            JournalEntryDetailID = Detail.JournalEntryDetailID,
            AccountID = Detail.AccountID,
            CostCenterId = Detail.CostCenterId,
            Credit = Detail.Credit,
            Debit = Detail.Debit
          };

          await _JournalEntryDetailRepository.UpdateAsync(JournalEntryDetail);
        }




        await transact.CommitAsync();
        return MessageCenter.CrudMessage.Success;

      }
      catch
      {
        await transact.RollbackAsync();
        return MessageCenter.CrudMessage.Falied;
      }
    }



    public async Task<string> DeleteByIdAsync(int id)
    {
      var JournalEntry = _JournalEntryRepository.GetTableNoTracking().Where(x => x.JournalEntryID == id).SingleOrDefault();

      if (JournalEntry == null)
      {
        return MessageCenter.CrudMessage.DoesNotExist;
      }
      var transact = _JournalEntryRepository.BeginTransaction();
      try
      {
        await _JournalEntryRepository.DeleteAsync(JournalEntry);

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
