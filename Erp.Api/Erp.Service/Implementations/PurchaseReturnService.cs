using Erp.Data.Dto.PurchaseReturn;
using Erp.Data.Entities;
using Erp.Data.MetaData;
using Erp.Infrastructure.Abstracts;
using Erp.Service.Abstracts;
using Microsoft.EntityFrameworkCore;

namespace Erp.Service.Implementations
{
  public class PurchaseReturnService : IPurchaseReturnService
  {
    private readonly IPurchaseReturnRepository _PurchaseReturnRepository;
    private readonly IPurchaseReturnItemRepository _PurchaseReturnItemRepository;
    private readonly IProductService _productService;
    private readonly IWarehouseService _warehouseService;



    // Isupplair
    public PurchaseReturnService(IPurchaseReturnRepository PurchaseReturnRepository, IProductService productService, IWarehouseService warehouseService, IPurchaseReturnItemRepository PurchaseReturnItemRepository)
    {
      _PurchaseReturnRepository = PurchaseReturnRepository;
      _PurchaseReturnItemRepository = PurchaseReturnItemRepository;
      _productService = productService;
      _warehouseService = warehouseService;
    }
    public async Task<string> AddPurchaseReturn(AddPurchaseReturnRequest PurchaseReturnRequest)
    {
      var PurchaseReturn = new PurchaseReturn()
      {
        ReturnDate = (DateTime)PurchaseReturnRequest.InvoiceDate,
        Notes = PurchaseReturnRequest.Notes,
        TotalAmount = PurchaseReturnRequest.TotalAmount,

      };


      var transact = _PurchaseReturnRepository.BeginTransaction();
      try
      {
        var newPurchaseReturn = await _PurchaseReturnRepository.AddAsync(PurchaseReturn);

        foreach (var item in PurchaseReturnRequest.PurchaseReturnItemDT0s)
        {
          var PurchaseReturnItem = new PurchaseReturnItem()
          {
            PurchaseReturnId = newPurchaseReturn.PurchaseReturnId,
            Quantity = item.Quantity,
            UnitPrice = item.UnitPrice,
            ProductId = item.ProductId,
            Tax = item.Tax,
            discount = item.discount,
          };

          await _PurchaseReturnItemRepository.AddAsync(PurchaseReturnItem);
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

    public async Task<string> DeleteAsync(PurchaseReturn PurchaseReturn)
    {

      var transact = _PurchaseReturnRepository.BeginTransaction();
      try
      {
        await _PurchaseReturnRepository.DeleteAsync(PurchaseReturn);

        await transact.CommitAsync();
        return MessageCenter.CrudMessage.Success;

      }
      catch
      {
        await transact.RollbackAsync();
        return MessageCenter.CrudMessage.Falied;
      }
    }

    public async Task<GetPurchaseReturnByIdDto> GetPurchaseReturnByIdAsync(int id)
    {
      var PurchaseReturn = _PurchaseReturnRepository.GetTableNoTracking().Where(x => x.PurchaseReturnId == id).Include(x => x.Items).ThenInclude(r => r.Product).SingleOrDefault();

      var dto = new GetPurchaseReturnByIdDto()
      {
        PurchaseReturnId = PurchaseReturn.PurchaseReturnId,
        InvoiceDate = PurchaseReturn.ReturnDate,
        Notes = PurchaseReturn.Notes,
        TotalAmount = PurchaseReturn.TotalAmount,
        PurchaseReturnItemsDto = new List<PurchaseReturnItemDto>()
      };

      dto.PurchaseReturnItemsDto.AddRange(PurchaseReturn.Items.Select(x => new PurchaseReturnItemDto
      {
        PurchaseReturnItemId = x.PurchaseReturnItemId,
        Quantity = x.Quantity,
        UnitPrice = x.UnitPrice,
        TotalPrice = x.TotalPrice,
        ProductId = x.ProductId

      }));

      return dto;
    }

    public async Task<List<GetPurchaseReturnByIdDto>> GetPurchaseReturnsListAsync()
    {
      var PurchaseReturns = _PurchaseReturnRepository.GetTableNoTracking().ToList();

      var dtoList = new List<GetPurchaseReturnByIdDto>();

      dtoList.AddRange(PurchaseReturns.Select(x => new GetPurchaseReturnByIdDto()
      {
        PurchaseReturnId = x.PurchaseReturnId,
        InvoiceDate = x.ReturnDate,
        Notes = x.Notes,
        TotalAmount = x.TotalAmount

      }));

      return dtoList;
    }

    public async Task<string> UpdateAsync(UpdatePurchaseReturnRequest PurchaseReturnRequest)
    {
      var PurchaseReturn = new PurchaseReturn()
      {
        PurchaseReturnId = PurchaseReturnRequest.PurchaseReturnId,
        ReturnDate = PurchaseReturnRequest.InvoiceDate,
        Notes = PurchaseReturnRequest.Notes

      };


      var transact = _PurchaseReturnRepository.BeginTransaction();
      try
      {
        await _PurchaseReturnRepository.UpdateAsync(PurchaseReturn);

        foreach (var item in PurchaseReturnRequest.PurchaseReturnItems)
        {
          var PurchaseReturnItem = new PurchaseReturnItem()
          {
            PurchaseReturnId = PurchaseReturnRequest.PurchaseReturnId,
            PurchaseReturnItemId = item.PurchaseReturnItemId,
            Quantity = item.Quantity,
            UnitPrice = item.UnitPrice,
            ProductId = item.ProductId
          };

          await _PurchaseReturnItemRepository.UpdateAsync(PurchaseReturnItem);
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
      var PurchaseReturn = _PurchaseReturnRepository.GetTableNoTracking().Where(x => x.PurchaseReturnId == id).SingleOrDefault();

      if (PurchaseReturn == null)
      {
        return MessageCenter.CrudMessage.DoesNotExist;
      }
      var transact = _PurchaseReturnRepository.BeginTransaction();
      try
      {
        await _PurchaseReturnRepository.DeleteAsync(PurchaseReturn);

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
