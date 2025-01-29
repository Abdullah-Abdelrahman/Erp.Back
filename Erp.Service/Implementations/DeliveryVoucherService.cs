using Erp.Data.Dto.DeliveryVoucher;
using Erp.Data.Entities;
using Erp.Data.Entities.InventoryModule;
using Erp.Data.MetaData;
using Erp.Infrastructure.Abstracts;
using Erp.Service.Abstracts;
using Microsoft.EntityFrameworkCore;

namespace Erp.Service.Implementations
{
  public class DeliveryVoucherService : IDeliveryVoucherService
  {
    private readonly IDeliveryVoucherRepository _DeliveryVoucherRepository;
    private readonly IDeliveryVoucherItemRepository _DeliveryVoucherItemRepository;
    private readonly IProductService _productService;
    private readonly IWarehouseService _warehouseService;



    // Isupplair
    public DeliveryVoucherService(IDeliveryVoucherRepository DeliveryVoucherRepository, IProductService productService, IWarehouseService warehouseService, IDeliveryVoucherItemRepository DeliveryVoucherItemRepository)
    {
      _DeliveryVoucherRepository = DeliveryVoucherRepository;
      _DeliveryVoucherItemRepository = DeliveryVoucherItemRepository;
      _productService = productService;
      _warehouseService = warehouseService;
    }


    public async Task<string> AddDeliveryVoucher(AddDeliveryVoucherRequest DeliveryVoucherRequest)
    {
      var DeliveryVoucher = new DeliveryVoucher()
      {
        DeliveryDate = (DateTime)DeliveryVoucherRequest.DeliveryDate,
        Notes = DeliveryVoucherRequest.Notes,
        WarehouseId = DeliveryVoucherRequest.WarehouseId

      };


      var transact = _DeliveryVoucherRepository.BeginTransaction();
      try
      {
        var newDeliveryVoucher = await _DeliveryVoucherRepository.AddAsync(DeliveryVoucher);

        foreach (var item in DeliveryVoucherRequest.DeliveryVoucherItemDT0s)
        {
          var DeliveryVoucherItem = new DeliveryVoucherItem()
          {
            deliveryVoucherId = newDeliveryVoucher.DeliveryVoucherId,
            Quantity = item.Quantity,
            UnitPrice = item.UnitPrice,
            ProductId = item.ProductId
          };

          await _DeliveryVoucherItemRepository.AddAsync(DeliveryVoucherItem);
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

    public async Task<string> DeleteAsync(DeliveryVoucher DeliveryVoucher)
    {

      var transact = _DeliveryVoucherRepository.BeginTransaction();
      try
      {
        await _DeliveryVoucherRepository.DeleteAsync(DeliveryVoucher);

        await transact.CommitAsync();
        return MessageCenter.CrudMessage.Success;

      }
      catch
      {
        await transact.RollbackAsync();
        return MessageCenter.CrudMessage.Falied;
      }
    }

    public async Task<GetDeliveryVoucherByIdDto> GetDeliveryVoucherByIdAsync(int id)
    {
      var DeliveryVoucher = _DeliveryVoucherRepository.GetTableNoTracking().Where(x => x.DeliveryVoucherId == id).Include(x => x.Warehouse).Include(x => x.deliveryVoucherItems).ThenInclude(r => r.Product).SingleOrDefault();

      var dto = new GetDeliveryVoucherByIdDto()
      {
        DeliveryVoucherId = DeliveryVoucher.DeliveryVoucherId,
        DeliveryDate = DeliveryVoucher.DeliveryDate,
        Notes = DeliveryVoucher.Notes,
        Warehouse = DeliveryVoucher.Warehouse,
        deliveryVoucherItemDto = new List<DeliveryVoucherItemDto>()
      };

      dto.deliveryVoucherItemDto.AddRange(DeliveryVoucher.deliveryVoucherItems.Select(x => new DeliveryVoucherItemDto
      {
        DeliveryVoucherItemId = x.DeliveryVoucherItemId,
        Quantity = x.Quantity,
        UnitPrice = x.UnitPrice,
        TotalPrice = x.TotalPrice,
        Product = x.Product

      }));

      return dto;
    }

    public async Task<List<GetDeliveryVoucherByIdDto>> GetDeliveryVouchersListAsync()
    {
      var DeliveryVouchers = _DeliveryVoucherRepository.GetTableNoTracking().Include(x => x.Warehouse).ToList();

      var dtoList = new List<GetDeliveryVoucherByIdDto>();

      dtoList.AddRange(DeliveryVouchers.Select(x => new GetDeliveryVoucherByIdDto()
      {
        DeliveryVoucherId = x.DeliveryVoucherId,
        DeliveryDate = x.DeliveryDate,
        Notes = x.Notes,
        Warehouse = x.Warehouse


      }));

      return dtoList;
    }

    public async Task<string> UpdateAsync(UpdateDeliveryVoucherRequest DeliveryVoucherRequest)
    {
      var DeliveryVoucher = new DeliveryVoucher()
      {
        DeliveryVoucherId = DeliveryVoucherRequest.DeliveryVoucherId,
        DeliveryDate = DeliveryVoucherRequest.DeliveryDate,
        Notes = DeliveryVoucherRequest.Notes,
        WarehouseId = DeliveryVoucherRequest.WarehouseId
      };


      var transact = _DeliveryVoucherRepository.BeginTransaction();
      try
      {
        await _DeliveryVoucherRepository.UpdateAsync(DeliveryVoucher);

        foreach (var item in DeliveryVoucherRequest.DeliveryVoucherItems)
        {
          var DeliveryVoucherItem = new DeliveryVoucherItem()
          {
            deliveryVoucherId = DeliveryVoucherRequest.DeliveryVoucherId,
            DeliveryVoucherItemId = item.DeliveryVoucherItemId,
            Quantity = item.Quantity,
            UnitPrice = item.UnitPrice,
            ProductId = item.ProductId
          };

          await _DeliveryVoucherItemRepository.UpdateAsync(DeliveryVoucherItem);
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
      var DeliveryVoucher = _DeliveryVoucherRepository.GetTableNoTracking().Where(x => x.DeliveryVoucherId == id).SingleOrDefault();

      if (DeliveryVoucher == null)
      {
        return MessageCenter.CrudMessage.DoesNotExist;
      }
      var transact = _DeliveryVoucherRepository.BeginTransaction();
      try
      {
        await _DeliveryVoucherRepository.DeleteAsync(DeliveryVoucher);

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
