using Erp.Data.Dto.CreditNote;
using Erp.Data.Entities.SalesModule;
using Erp.Data.MetaData;
using Erp.Infrastructure.Abstracts.SalesModule;
using Erp.Service.Abstracts;
using Erp.Service.Abstracts.SalesModule;
using Microsoft.EntityFrameworkCore;

namespace Erp.Service.Implementations.SalesModule
{
  public class CreditNoteService : ICreditNoteService
  {
    private readonly ICreditNoteRepository _CreditNoteRepository;
    private readonly ICreditNoteItemRepository _CreditNoteItemRepository;
    private readonly IProductService _productService;




    // Isupplair
    public CreditNoteService(ICreditNoteRepository CreditNoteRepository, IProductService productService, IWarehouseService warehouseService, ICreditNoteItemRepository CreditNoteItemRepository)
    {
      _CreditNoteRepository = CreditNoteRepository;
      _CreditNoteItemRepository = CreditNoteItemRepository;
      _productService = productService;

    }
    public async Task<string> AddCreditNote(AddCreditNoteRequest CreditNoteRequest)
    {
      var CreditNote = new CreditNote(CreditNoteRequest);



      var transact = _CreditNoteRepository.BeginTransaction();
      try
      {
        var newCreditNote = await _CreditNoteRepository.AddAsync(CreditNote);

        foreach (var item in CreditNoteRequest.CreditNoteItemDT0s)
        {
          var CreditNoteItem = new CreditNoteItem(item, newCreditNote.CreditNoteID);


          await _CreditNoteItemRepository.AddAsync(CreditNoteItem);
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

    public async Task<string> DeleteAsync(CreditNote CreditNote)
    {

      var transact = _CreditNoteRepository.BeginTransaction();
      try
      {
        await _CreditNoteRepository.DeleteAsync(CreditNote);

        await transact.CommitAsync();
        return MessageCenter.CrudMessage.Success;

      }
      catch
      {
        await transact.RollbackAsync();
        return MessageCenter.CrudMessage.Falied;
      }
    }

    public async Task<GetCreditNoteByIdDto> GetCreditNoteByIdAsync(int id)
    {
      var CreditNote = _CreditNoteRepository.GetTableNoTracking().Where(x => x.CreditNoteID == id).Include(x => x.Customer).Include(x => x.Items).ThenInclude(r => r.product).SingleOrDefault();

      var dto = new GetCreditNoteByIdDto()
      {
        CreditNoteId = CreditNote.CreditNoteID,
        CustomerID = CreditNote.CustomerID,
        CreditNoteDate = CreditNote.CreditNoteDate,
        ReleaseDate = CreditNote.ReleaseDate,
        Discount = CreditNote.Discount,
        Total = CreditNote.Total,
        Reason = CreditNote.Reason,
        CreditNoteItemsDto = new List<CreditNoteItemDto>()
      };

      dto.CreditNoteItemsDto.AddRange(CreditNote.Items.Select(x => new CreditNoteItemDto
      {
        CreditNoteItemId = x.CreditNoteItemID,
        CreditNoteId = x.CreditNoteID,
        ProductId = x.productID,
        Description = x.Description,
        Quantity = x.Quantity,
        UnitPrice = x.UnitPrice,
        discount = x.Discount,
        Tax = x.Tax

      }));

      return dto;
    }

    public async Task<List<GetCreditNoteByIdDto>> GetCreditNotesListAsync()
    {
      var CreditNotes = _CreditNoteRepository.GetTableNoTracking().Include(x => x.Customer).ToList();

      var dtoList = new List<GetCreditNoteByIdDto>();

      dtoList.AddRange(CreditNotes.Select(x => new GetCreditNoteByIdDto()
      {
        CreditNoteId = x.CreditNoteID,
        CustomerID = x.CustomerID,
        CreditNoteDate = x.CreditNoteDate,
        ReleaseDate = x.ReleaseDate,
        Discount = x.Discount,
        Total = x.Total,
        Reason = x.Reason,

      }));

      return dtoList;
    }

    public async Task<string> UpdateAsync(UpdateCreditNoteRequest CreditNoteRequest)
    {
      var CreditNote = new CreditNote(CreditNoteRequest);



      var transact = _CreditNoteRepository.BeginTransaction();
      try
      {
        await _CreditNoteRepository.UpdateAsync(CreditNote);

        foreach (var item in CreditNoteRequest.CreditNoteItems)
        {
          var CreditNoteItem = new CreditNoteItem(item);


          await _CreditNoteItemRepository.UpdateAsync(CreditNoteItem);
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
      var CreditNote = _CreditNoteRepository.GetTableNoTracking().Where(x => x.CreditNoteID == id).SingleOrDefault();

      if (CreditNote == null)
      {
        return MessageCenter.CrudMessage.DoesNotExist;
      }
      var transact = _CreditNoteRepository.BeginTransaction();
      try
      {
        await _CreditNoteRepository.DeleteAsync(CreditNote);

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
