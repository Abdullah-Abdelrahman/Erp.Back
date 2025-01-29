using Erp.Data.Dto.DebitNote;
using Erp.Data.Entities;
using Erp.Data.Entities.PurchasesModule;
using Erp.Data.MetaData;
using Erp.Infrastructure.Abstracts;
using Erp.Service.Abstracts;
using Microsoft.EntityFrameworkCore;

namespace Erp.Service.Implementations
{
  public class DebitNoteService : IDebitNoteService
  {
    private readonly IDebitNoteRepository _DebitNoteRepository;
    private readonly IDebitNoteItemRepository _DebitNoteItemRepository;
    private readonly IProductService _productService;
    private readonly IWarehouseService _warehouseService;



    // Isupplair
    public DebitNoteService(IDebitNoteRepository DebitNoteRepository, IProductService productService, IWarehouseService warehouseService, IDebitNoteItemRepository DebitNoteItemRepository)
    {
      _DebitNoteRepository = DebitNoteRepository;
      _DebitNoteItemRepository = DebitNoteItemRepository;
      _productService = productService;
      _warehouseService = warehouseService;
    }
    public async Task<string> AddDebitNote(AddDebitNoteRequest DebitNoteRequest)
    {
      var DebitNote = new DebitNote()
      {
        NoteDate = (DateTime)DebitNoteRequest.InvoiceDate,
        Notes = DebitNoteRequest.Notes,
        Amount = DebitNoteRequest.TotalAmount,
        SupplierId = DebitNoteRequest.SupplierId
      };


      var transact = _DebitNoteRepository.BeginTransaction();
      try
      {
        var newDebitNote = await _DebitNoteRepository.AddAsync(DebitNote);

        foreach (var item in DebitNoteRequest.DebitNoteItemDT0s)
        {
          var DebitNoteItem = new DebitNoteItem()
          {
            DebitNoteId = newDebitNote.DebitNoteId,
            Quantity = item.Quantity,
            UnitPrice = item.UnitPrice,
            ProductId = item.ProductId,
            Tax = item.Tax,
            discount = item.discount,
          };

          await _DebitNoteItemRepository.AddAsync(DebitNoteItem);
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

    public async Task<string> DeleteAsync(DebitNote DebitNote)
    {

      var transact = _DebitNoteRepository.BeginTransaction();
      try
      {
        await _DebitNoteRepository.DeleteAsync(DebitNote);

        await transact.CommitAsync();
        return MessageCenter.CrudMessage.Success;

      }
      catch
      {
        await transact.RollbackAsync();
        return MessageCenter.CrudMessage.Falied;
      }
    }

    public async Task<GetDebitNoteByIdDto> GetDebitNoteByIdAsync(int id)
    {
      var DebitNote = _DebitNoteRepository.GetTableNoTracking().Where(x => x.DebitNoteId == id).Include(x => x.Supplier).Include(x => x.Items).ThenInclude(r => r.Product).SingleOrDefault();

      var dto = new GetDebitNoteByIdDto()
      {
        DebitNoteId = DebitNote.DebitNoteId,
        InvoiceDate = DebitNote.NoteDate,
        Notes = DebitNote.Notes,
        TotalAmount = DebitNote.Amount,
        SupplierId = DebitNote.SupplierId,
        DebitNoteItemsDto = new List<DebitNoteItemDto>()
      };

      dto.DebitNoteItemsDto.AddRange(DebitNote.Items.Select(x => new DebitNoteItemDto
      {
        DebitNoteItemId = x.DebitNoteItemId,
        Quantity = x.Quantity,
        UnitPrice = x.UnitPrice,
        TotalPrice = x.TotalPrice,
        ProductId = x.ProductId

      }));

      return dto;
    }

    public async Task<List<GetDebitNoteByIdDto>> GetDebitNotesListAsync()
    {
      var DebitNotes = _DebitNoteRepository.GetTableNoTracking().Include(x => x.Supplier).ToList();

      var dtoList = new List<GetDebitNoteByIdDto>();

      dtoList.AddRange(DebitNotes.Select(x => new GetDebitNoteByIdDto()
      {
        DebitNoteId = x.DebitNoteId,
        InvoiceDate = x.NoteDate,
        Notes = x.Notes,
        TotalAmount = x.Amount,
        SupplierId = x.SupplierId

      }));

      return dtoList;
    }

    public async Task<string> UpdateAsync(UpdateDebitNoteRequest DebitNoteRequest)
    {
      var DebitNote = new DebitNote()
      {
        DebitNoteId = DebitNoteRequest.DebitNoteId,
        NoteDate = DebitNoteRequest.InvoiceDate,
        Notes = DebitNoteRequest.Notes,
        SupplierId = DebitNoteRequest.SupplierId

      };


      var transact = _DebitNoteRepository.BeginTransaction();
      try
      {
        await _DebitNoteRepository.UpdateAsync(DebitNote);

        foreach (var item in DebitNoteRequest.DebitNoteItems)
        {
          var DebitNoteItem = new DebitNoteItem()
          {
            DebitNoteId = DebitNoteRequest.DebitNoteId,
            DebitNoteItemId = item.DebitNoteItemId,
            Quantity = item.Quantity,
            UnitPrice = item.UnitPrice,
            ProductId = item.ProductId
          };

          await _DebitNoteItemRepository.UpdateAsync(DebitNoteItem);
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
      var DebitNote = _DebitNoteRepository.GetTableNoTracking().Where(x => x.DebitNoteId == id).SingleOrDefault();

      if (DebitNote == null)
      {
        return MessageCenter.CrudMessage.DoesNotExist;
      }
      var transact = _DebitNoteRepository.BeginTransaction();
      try
      {
        await _DebitNoteRepository.DeleteAsync(DebitNote);

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
