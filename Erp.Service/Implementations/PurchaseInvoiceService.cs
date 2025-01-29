using Erp.Data.Dto.PurchaseInvoice;
using Erp.Data.Entities;
using Erp.Data.Entities.PurchasesModule;
using Erp.Data.MetaData;
using Erp.Infrastructure.Abstracts;
using Erp.Service.Abstracts;
using Microsoft.EntityFrameworkCore;

namespace Erp.Service.Implementations
{
  public class PurchaseInvoiceService : IPurchaseInvoiceService
  {
    private readonly IPurchaseInvoiceRepository _PurchaseInvoiceRepository;
    private readonly IPurchaseInvoiceItemRepository _PurchaseInvoiceItemRepository;
    private readonly IProductService _productService;
    private readonly IWarehouseService _warehouseService;



    // Isupplair
    public PurchaseInvoiceService(IPurchaseInvoiceRepository PurchaseInvoiceRepository, IProductService productService, IWarehouseService warehouseService, IPurchaseInvoiceItemRepository PurchaseInvoiceItemRepository)
    {
      _PurchaseInvoiceRepository = PurchaseInvoiceRepository;
      _PurchaseInvoiceItemRepository = PurchaseInvoiceItemRepository;
      _productService = productService;
      _warehouseService = warehouseService;
    }
    public async Task<string> AddPurchaseInvoice(AddPurchaseInvoiceRequest PurchaseInvoiceRequest)
    {
      var PurchaseInvoice = new PurchaseInvoice()
      {
        InvoiceDate = (DateTime)PurchaseInvoiceRequest.InvoiceDate,
        Notes = PurchaseInvoiceRequest.Notes,
        TotalAmount = PurchaseInvoiceRequest.TotalAmount,
        SupplierId = PurchaseInvoiceRequest.SupplierId
      };


      var transact = _PurchaseInvoiceRepository.BeginTransaction();
      try
      {
        var newPurchaseInvoice = await _PurchaseInvoiceRepository.AddAsync(PurchaseInvoice);

        foreach (var item in PurchaseInvoiceRequest.PurchaseInvoiceItemDT0s)
        {
          var PurchaseInvoiceItem = new PurchaseInvoiceItem()
          {
            PurchaseInvoiceId = newPurchaseInvoice.PurchaseInvoiceId,
            Quantity = item.Quantity,
            UnitPrice = item.UnitPrice,
            ProductId = item.ProductId,
            Tax = item.Tax,
            discount = item.discount,
          };

          await _PurchaseInvoiceItemRepository.AddAsync(PurchaseInvoiceItem);
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

    public async Task<string> DeleteAsync(PurchaseInvoice PurchaseInvoice)
    {

      var transact = _PurchaseInvoiceRepository.BeginTransaction();
      try
      {
        await _PurchaseInvoiceRepository.DeleteAsync(PurchaseInvoice);

        await transact.CommitAsync();
        return MessageCenter.CrudMessage.Success;

      }
      catch
      {
        await transact.RollbackAsync();
        return MessageCenter.CrudMessage.Falied;
      }
    }

    public async Task<GetPurchaseInvoiceByIdDto> GetPurchaseInvoiceByIdAsync(int id)
    {
      var PurchaseInvoice = _PurchaseInvoiceRepository.GetTableNoTracking().Where(x => x.PurchaseInvoiceId == id).Include(x => x.Supplier).Include(x => x.Items).ThenInclude(r => r.Product).SingleOrDefault();

      var dto = new GetPurchaseInvoiceByIdDto()
      {
        PurchaseInvoiceId = PurchaseInvoice.PurchaseInvoiceId,
        InvoiceDate = PurchaseInvoice.InvoiceDate,
        Notes = PurchaseInvoice.Notes,
        TotalAmount = PurchaseInvoice.TotalAmount,
        SupplierId = PurchaseInvoice.SupplierId,
        PurchaseInvoiceItemsDto = new List<PurchaseInvoiceItemDto>()
      };

      dto.PurchaseInvoiceItemsDto.AddRange(PurchaseInvoice.Items.Select(x => new PurchaseInvoiceItemDto
      {
        PurchaseInvoiceItemId = x.PurchaseInvoiceItemId,
        Quantity = x.Quantity,
        UnitPrice = x.UnitPrice,
        TotalPrice = x.TotalPrice,
        ProductId = x.ProductId

      }));

      return dto;
    }

    public async Task<List<GetPurchaseInvoiceByIdDto>> GetPurchaseInvoicesListAsync()
    {
      var PurchaseInvoices = _PurchaseInvoiceRepository.GetTableNoTracking().Include(x => x.Supplier).ToList();

      var dtoList = new List<GetPurchaseInvoiceByIdDto>();

      dtoList.AddRange(PurchaseInvoices.Select(x => new GetPurchaseInvoiceByIdDto()
      {
        PurchaseInvoiceId = x.PurchaseInvoiceId,
        InvoiceDate = x.InvoiceDate,
        Notes = x.Notes,
        TotalAmount = x.TotalAmount,
        SupplierId = x.SupplierId

      }));

      return dtoList;
    }

    public async Task<string> UpdateAsync(UpdatePurchaseInvoiceRequest PurchaseInvoiceRequest)
    {
      var PurchaseInvoice = new PurchaseInvoice()
      {
        PurchaseInvoiceId = PurchaseInvoiceRequest.PurchaseInvoiceId,
        InvoiceDate = PurchaseInvoiceRequest.InvoiceDate,
        Notes = PurchaseInvoiceRequest.Notes,
        SupplierId = PurchaseInvoiceRequest.SupplierId

      };


      var transact = _PurchaseInvoiceRepository.BeginTransaction();
      try
      {
        await _PurchaseInvoiceRepository.UpdateAsync(PurchaseInvoice);

        foreach (var item in PurchaseInvoiceRequest.PurchaseInvoiceItems)
        {
          var PurchaseInvoiceItem = new PurchaseInvoiceItem()
          {
            PurchaseInvoiceId = PurchaseInvoiceRequest.PurchaseInvoiceId,
            PurchaseInvoiceItemId = item.PurchaseInvoiceItemId,
            Quantity = item.Quantity,
            UnitPrice = item.UnitPrice,
            ProductId = item.ProductId
          };

          await _PurchaseInvoiceItemRepository.UpdateAsync(PurchaseInvoiceItem);
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
      var PurchaseInvoice = _PurchaseInvoiceRepository.GetTableNoTracking().Where(x => x.PurchaseInvoiceId == id).SingleOrDefault();

      if (PurchaseInvoice == null)
      {
        return MessageCenter.CrudMessage.DoesNotExist;
      }
      var transact = _PurchaseInvoiceRepository.BeginTransaction();
      try
      {
        await _PurchaseInvoiceRepository.DeleteAsync(PurchaseInvoice);

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
