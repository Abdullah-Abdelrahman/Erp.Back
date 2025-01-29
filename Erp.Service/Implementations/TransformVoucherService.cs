using Erp.Data.Dto.TransformVoucher;
using Erp.Data.Dto.TransformVoucher.cs;
using Erp.Data.Entities;
using Erp.Data.Entities.InventoryModule;
using Erp.Data.MetaData;
using Erp.Infrastructure.Abstracts;
using Erp.Service.Abstracts;
using Microsoft.EntityFrameworkCore;

namespace Erp.Service.Implementations
{
  public class TransformVoucherService : ITransformVoucherService
  {
    private readonly ITransformVoucherRepository _TransformVoucherRepository;
    private readonly ITransformVoucherItemRepository _TransformVoucherItemRepository;
    private readonly IProductService _productService;
    private readonly IWarehouseService _warehouseService;



    // Isupplair
    public TransformVoucherService(ITransformVoucherRepository TransformVoucherRepository, IProductService productService, IWarehouseService warehouseService, ITransformVoucherItemRepository TransformVoucherItemRepository)
    {
      _TransformVoucherRepository = TransformVoucherRepository;
      _TransformVoucherItemRepository = TransformVoucherItemRepository;
      _productService = productService;
      _warehouseService = warehouseService;
    }


    public async Task<string> AddTransformVoucher(AddTransformVoucherRequest TransformVoucherRequest)
    {
      var TransformVoucher = new TransformVoucher()
      {
        TransformDate = (DateTime)TransformVoucherRequest.TransformDate,
        Notes = TransformVoucherRequest.Notes,
        FromWarehouseId = TransformVoucherRequest.FromWarehouseId,
        ToWarehouseId = TransformVoucherRequest.ToWarehouseId
      };


      var transact = _TransformVoucherRepository.BeginTransaction();
      try
      {
        var newTransformVoucher = await _TransformVoucherRepository.AddAsync(TransformVoucher);

        foreach (var item in TransformVoucherRequest.TransformVoucherItemDT0s)
        {
          var TransformVoucherItem = new TransformVoucherItem()
          {
            transformVoucherId = newTransformVoucher.TransformVoucherId,
            Quantity = item.Quantity,
            ProductId = item.ProductId
          };

          await _TransformVoucherItemRepository.AddAsync(TransformVoucherItem);
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

    public async Task<string> DeleteAsync(TransformVoucher TransformVoucher)
    {

      var transact = _TransformVoucherRepository.BeginTransaction();
      try
      {
        await _TransformVoucherRepository.DeleteAsync(TransformVoucher);

        await transact.CommitAsync();
        return MessageCenter.CrudMessage.Success;

      }
      catch
      {
        await transact.RollbackAsync();
        return MessageCenter.CrudMessage.Falied;
      }
    }

    public async Task<GetTransformVoucherByIdDto> GetTransformVoucherByIdAsync(int id)
    {
      var TransformVoucher = _TransformVoucherRepository.GetTableNoTracking().Where(x => x.TransformVoucherId == id).Include(x => x.FromWarehouse).Include(x => x.ToWarehouse).Include(x => x.TransformItems).ThenInclude(r => r.Product).SingleOrDefault();

      var dto = new GetTransformVoucherByIdDto()
      {
        TransformVoucherId = TransformVoucher.TransformVoucherId,
        TransformDate = TransformVoucher.TransformDate,
        Notes = TransformVoucher.Notes,
        FromWarehouse = TransformVoucher.FromWarehouse,
        ToWarehouse = TransformVoucher.ToWarehouse,
        transformVoucherItemsDto = new List<TransformVoucherItemDto>()
      };

      dto.transformVoucherItemsDto.AddRange(TransformVoucher.TransformItems.Select(x => new TransformVoucherItemDto
      {
        TransformVoucherItemId = x.TransformVoucherItemId,
        Quantity = x.Quantity,
        Product = x.Product

      }));

      return dto;
    }

    public async Task<List<GetTransformVoucherByIdDto>> GetTransformVouchersListAsync()
    {
      var TransformVouchers = _TransformVoucherRepository.GetTableNoTracking().Include(x => x.FromWarehouse).Include(x => x.ToWarehouse).ToList();

      var dtoList = new List<GetTransformVoucherByIdDto>();

      dtoList.AddRange(TransformVouchers.Select(x => new GetTransformVoucherByIdDto()
      {
        TransformVoucherId = x.TransformVoucherId,
        TransformDate = x.TransformDate,
        Notes = x.Notes,
        FromWarehouse = x.FromWarehouse,
        ToWarehouse = x.ToWarehouse

      }));

      return dtoList;
    }

    public async Task<string> UpdateAsync(UpdateTransformVoucherRequest TransformVoucherRequest)
    {
      var TransformVoucher = new TransformVoucher()
      {
        TransformVoucherId = TransformVoucherRequest.TransformVoucherId,
        TransformDate = TransformVoucherRequest.TransformDate,
        Notes = TransformVoucherRequest.Notes,
        FromWarehouseId = TransformVoucherRequest.FromWarehouseId,
        ToWarehouseId = TransformVoucherRequest.ToWarehouseId
      };


      var transact = _TransformVoucherRepository.BeginTransaction();
      try
      {
        await _TransformVoucherRepository.UpdateAsync(TransformVoucher);

        foreach (var item in TransformVoucherRequest.TransformVoucherItems)
        {
          var TransformVoucherItem = new TransformVoucherItem()
          {
            transformVoucherId = TransformVoucherRequest.TransformVoucherId,
            TransformVoucherItemId = item.TransformVoucherItemId,
            Quantity = item.Quantity,
            ProductId = item.ProductId
          };

          await _TransformVoucherItemRepository.UpdateAsync(TransformVoucherItem);
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
      var TransformVoucher = _TransformVoucherRepository.GetTableNoTracking().Where(x => x.TransformVoucherId == id).SingleOrDefault();

      if (TransformVoucher == null)
      {
        return MessageCenter.CrudMessage.DoesNotExist;
      }
      var transact = _TransformVoucherRepository.BeginTransaction();
      try
      {
        await _TransformVoucherRepository.DeleteAsync(TransformVoucher);

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
