using Erp.Data.Dto.Receipt;
using Erp.Data.Entities.AccountsModule;
using Erp.Data.Entities.Finance;
using Erp.Data.MetaData;
using Erp.Infrastructure.Abstracts.AccountsModule;
using Erp.Infrastructure.Abstracts.Finance;
using Erp.Service.Abstracts.Finance;
using Microsoft.EntityFrameworkCore;

namespace Erp.Service.Implementations.Finance
{
  public class ReceiptService : IReceiptService
  {
    private readonly IReceiptRepository _ReceiptRepository;
    private readonly IReceiptCategoryRepository _ReceiptCategoryRepository;

    private readonly IAccountRepository<SecondaryAccount> _accountRepository;

    private readonly ITreasuryRepository _treasuryRepository;

    private readonly IMultiAccReceiptItemRepository _multiAccReceiptItemRepository;


    public ReceiptService(IReceiptRepository ReceiptRepository
      , IAccountRepository<SecondaryAccount> accountRepository,
IReceiptCategoryRepository ReceiptCategoryRepository,
ITreasuryRepository treasuryRepository,
IMultiAccReceiptItemRepository multiAccReceiptItemRepository)
    {
      _ReceiptRepository = ReceiptRepository;
      _accountRepository = accountRepository;
      _ReceiptCategoryRepository = ReceiptCategoryRepository;
      _treasuryRepository = treasuryRepository;
      _multiAccReceiptItemRepository = multiAccReceiptItemRepository;
    }
    // ملحوظة: في حال لم يتم اختيار الحساب الفرعي؛ سيقوم النظام بتوجيه المصروف إلى حساب “مصروفات أخرى”.

    private async Task<int> GetMainTreasuryId()
    {
      var tras = (await _treasuryRepository.
         GetTableNoTracking().FirstOrDefaultAsync());

      if (tras == null)
      {
        return 0;
      }
      return tras.Id;
    }
    private async Task<int> GetDefaultSubAccountId()
    {
      var Acc = (await _accountRepository.GetTableNoTracking().
        Where(a => a.AccountName == "Other Receipts").SingleOrDefaultAsync());
      if (Acc == null)
      {
        return 0;
      }
      return Acc.AccountID;
    }
    public async Task<string> AddReceipt(AddReceiptRequest ReceiptRequest)
    {

      var Tid = await GetMainTreasuryId();

      var SubAccId = await GetDefaultSubAccountId();


      var Receipt = new Receipt()
      {
        CodeNumber = ReceiptRequest.CodeNumber,
        Amount = ReceiptRequest.Amount,
        Currency = ReceiptRequest.Currency,
        Date = ReceiptRequest.Date is null ? DateTime.Now : (DateTime)ReceiptRequest.Date,
        Description = ReceiptRequest.Description == null ? string.Empty : ReceiptRequest.Description,
        TreasuryId = ReceiptRequest.TreasuryId == 0 ? Tid
        : ReceiptRequest.TreasuryId,
        Isfrequent = ReceiptRequest.Isfrequent,
        IsMultiAccount = ReceiptRequest.IsMultiAccount,
        WithCostCenter = ReceiptRequest.WithCostCenter,
        SubAccountId = ReceiptRequest.SubAccountId == null ? SubAccId : (int)ReceiptRequest.SubAccountId

      };





      var transact = _ReceiptRepository.BeginTransaction();
      try
      {
        var newReceipt = await _ReceiptRepository.AddAsync(Receipt);

        foreach (var item in ReceiptRequest.CategoriesIds)
        {
          var category = await _ReceiptCategoryRepository.GetByIdAsync(item);
          if (category == null) throw new Exception($"ReceiptCategory with ID {item} not found.");
          newReceipt.receiptCategories.Add(category);
        }
        decimal total = 0;

        if (newReceipt.WithCostCenter)
        {
          foreach (var item in ReceiptRequest.ReceiptCostCenterDtos)
          {
            var ReceiptCostCenterItem = new ReceiptCostCenter()
            {
              ReceiptId = newReceipt.Id,
              CostCenterId = item.CostCenterId,
              Amount = item.Amount,
              Percentage = item.Percentage

            };
            total += ReceiptCostCenterItem.Amount;
            newReceipt.ReceiptCostCenters.Add(ReceiptCostCenterItem);
          }
        }

        if (newReceipt.IsMultiAccount)
        {
          total = 0;
          foreach (var item in ReceiptRequest.multiAccReceiptItems)
          {
            var ReceiptCostCenterItem = new MultiAccReceiptItem()
            {
              receiptId = newReceipt.Id,
              SecondaryAccountId = newReceipt.SubAccountId == null ? SubAccId : newReceipt.SubAccountId,
              CostCenterId = item.CostCenterId,
              Amount = item.Amount,
              Tax = item.Tax

            };
            total += ReceiptCostCenterItem.Amount;
            await _multiAccReceiptItemRepository.AddAsync(ReceiptCostCenterItem);
          }

        }

        newReceipt.Amount = total;

        await _ReceiptRepository.UpdateAsync(newReceipt);
        await transact.CommitAsync();
        return MessageCenter.CrudMessage.Success;

      }
      catch (Exception ex)
      {
        await transact.RollbackAsync();
        return MessageCenter.CrudMessage.Falied + ex.Message;
      }

    }

    public async Task<string> DeleteAsync(Receipt Receipt)
    {

      var transact = _ReceiptRepository.BeginTransaction();
      try
      {
        await _ReceiptRepository.DeleteAsync(Receipt);

        await transact.CommitAsync();
        return MessageCenter.CrudMessage.Success;

      }
      catch
      {
        await transact.RollbackAsync();
        return MessageCenter.CrudMessage.Falied;
      }
    }

    public async Task<GetReceiptByIdDto> GetReceiptByIdAsync(int id)
    {
      var Receipt = _ReceiptRepository.GetTableNoTracking().Where(x => x.Id == id)
        .Include(x => x.receiptCategories)
        .Include(x => x.SubAccount)
        .Include(x => x.Treasury)
        .Include(x => x.ReceiptCostCenters)
        .Include(x => x.multiAccReceiptItems).SingleOrDefault();
      if (Receipt == null)
      {
        return new GetReceiptByIdDto();
      }

      var dto = new GetReceiptByIdDto()
      {
        Id = Receipt.Id,
        CodeNumber = Receipt.CodeNumber,
        Amount = Receipt.Amount,
        Currency = Receipt.Currency,
        Date = Receipt.Date,
        Description = Receipt.Description,
        CategoriesIds = Receipt.receiptCategories.Select(x => x.Id).ToList(),
        SubAccountId = Receipt.SubAccountId,
        TreasuryId = Receipt.TreasuryId,
        Isfrequent = Receipt.Isfrequent,
        IsMultiAccount = Receipt.IsMultiAccount,
        WithCostCenter = Receipt.WithCostCenter
      };


      if (dto.WithCostCenter)
      {
        foreach (var item in Receipt.ReceiptCostCenters)
        {
          var ReceiptCostCenterItem = new ReceiptCostCenterGetDto()
          {
            ReceiptId = item.ReceiptId,
            CostCenterId = item.CostCenterId,
            Amount = item.Amount,
            Percentage = item.Percentage

          };
          dto.ReceiptCostCenterDtos.Add(ReceiptCostCenterItem);
        }
      }

      if (dto.IsMultiAccount)
      {
        foreach (var item in Receipt.multiAccReceiptItems)
        {
          var multiAccReceiptItem = new MultiAccReceiptItemGetDto()
          {
            Id = item.Id,
            SecondaryAccountId = item.SecondaryAccountId,
            CostCenterId = item.CostCenterId,
            Amount = item.Amount,
            Tax = item.Tax

          };
          dto.multiAccReceiptItems.Add(multiAccReceiptItem);
        }
      }


      return dto;
    }

    public async Task<List<GetReceiptByIdDto>> GetReceiptsListAsync()
    {
      var Receipts = await _ReceiptRepository.GetTableNoTracking().ToListAsync();

      var dtoList = new List<GetReceiptByIdDto>();

      dtoList.AddRange(Receipts.Select(x => new GetReceiptByIdDto()
      {
        Id = x.Id,
        CodeNumber = x.CodeNumber,
        Amount = x.Amount,
        Currency = x.Currency,
        Date = x.Date,
        Description = x.Description,
        CategoriesIds = x.receiptCategories.Select(x => x.Id).ToList(),
        SubAccountId = x.SubAccountId,
        TreasuryId = x.TreasuryId,
        Isfrequent = x.Isfrequent,
        IsMultiAccount = x.IsMultiAccount,
        WithCostCenter = x.WithCostCenter

      }));

      return dtoList;
    }

    public async Task<string> UpdateAsync(UpdateReceiptRequest ReceiptRequest)
    {


      var Receipt = await _ReceiptRepository.GetReceiptByIdAsync(ReceiptRequest.Id);
      if (Receipt == null)
      {
        return MessageCenter.CrudMessage.DoesNotExist;
      }

      Receipt.CodeNumber = ReceiptRequest.CodeNumber;
      Receipt.Amount = ReceiptRequest.Amount;
      Receipt.Currency = ReceiptRequest.Currency;
      Receipt.Date = ReceiptRequest.Date is null ? DateTime.Now : (DateTime)ReceiptRequest.Date;
      Receipt.Description = ReceiptRequest.Description == null ? string.Empty : ReceiptRequest.Description;
      Receipt.TreasuryId = ReceiptRequest.TreasuryId;
      Receipt.Isfrequent = ReceiptRequest.Isfrequent;
      Receipt.IsMultiAccount = ReceiptRequest.IsMultiAccount;
      Receipt.WithCostCenter = ReceiptRequest.WithCostCenter;





      var transact = _ReceiptRepository.BeginTransaction();
      try
      {
        await _ReceiptRepository.UpdateAsync(Receipt);


        foreach (var item in Receipt.receiptCategories.ToList())
        {
          if (!ReceiptRequest.CategoriesIds.Contains(item.Id))
          {
            Receipt.receiptCategories.Remove(item);
          }

        }

        foreach (var item in ReceiptRequest.CategoriesIds)
        {
          if (!Receipt.receiptCategories.Any(x => x.Id == item))
          {
            var category = await _ReceiptCategoryRepository.GetByIdAsync(item);
            if (category == null) throw new Exception($"ReceiptCategory with ID {item} not found.");
            Receipt.receiptCategories.Add(category);
          }



        }
        decimal total = 0;

        if (Receipt.WithCostCenter)
        {

          foreach (var item in Receipt.ReceiptCostCenters.ToList())
          {
            Receipt.ReceiptCostCenters.Remove(item);
          }
          foreach (var item in ReceiptRequest.ReceiptCostCenterDtos)
          {
            var ReceiptCostCenterItem = new ReceiptCostCenter()
            {
              ReceiptId = Receipt.Id,
              CostCenterId = item.CostCenterId,
              Amount = item.Amount,
              Percentage = item.Percentage

            };
            total += ReceiptCostCenterItem.Amount;
            Receipt.ReceiptCostCenters.Add(ReceiptCostCenterItem);
          }
        }

        if (Receipt.IsMultiAccount)
        {
          total = 0;
          await _multiAccReceiptItemRepository.GetTableAsTracking().Where(x => x.receiptId == Receipt.Id).ExecuteDeleteAsync();
          foreach (var item in ReceiptRequest.multiAccReceiptItems)
          {
            var ReceiptCostCenterItem = new MultiAccReceiptItem()
            {
              SecondaryAccountId = Receipt.SubAccountId,
              CostCenterId = item.CostCenterId,
              Amount = item.Amount,
              Tax = item.Tax

            };
            total += ReceiptCostCenterItem.Amount;
            Receipt.multiAccReceiptItems.Add(ReceiptCostCenterItem);
          }

        }
        Receipt.Amount = total;


        await _ReceiptRepository.UpdateAsync(Receipt);

        await transact.CommitAsync();
        return MessageCenter.CrudMessage.Success;

      }
      catch (Exception ex)
      {
        await transact.RollbackAsync();
        return MessageCenter.CrudMessage.Falied + ex.Message;
      }
    }



    public async Task<string> DeleteByIdAsync(int id)
    {
      var Receipt = _ReceiptRepository.GetTableNoTracking().Where(x => x.Id == id).SingleOrDefault();

      if (Receipt == null)
      {
        return MessageCenter.CrudMessage.DoesNotExist;
      }
      var transact = _ReceiptRepository.BeginTransaction();
      try
      {
        await _ReceiptRepository.DeleteAsync(Receipt);

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
