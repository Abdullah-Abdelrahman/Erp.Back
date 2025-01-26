using Erp.Data.Dto.ReceivingVoucher;
using Erp.Data.Entities;
using Erp.Data.MetaData;
using Erp.Infrastructure.Abstracts;
using Erp.Service.Abstracts;
using Microsoft.EntityFrameworkCore;

namespace Erp.Service.Implementations
{
  public class ReceivingVoucherService : IReceivingVoucherService
  {
    private readonly IReceivingVoucherRepository _receivingVoucherRepository;
    private readonly IReceivingVoucherItemRepository _receivingVoucherItemRepository;
    private readonly IProductService _productService;
    private readonly IWarehouseService _warehouseService;



    // Isupplair
    public ReceivingVoucherService(IReceivingVoucherRepository receivingVoucherRepository, IProductService productService, IWarehouseService warehouseService, IReceivingVoucherItemRepository receivingVoucherItemRepository)
    {
      _receivingVoucherRepository = receivingVoucherRepository;
      _receivingVoucherItemRepository = receivingVoucherItemRepository;
      _productService = productService;
      _warehouseService = warehouseService;
    }
    public async Task<string> AddReceivingVoucher(AddReceivingVoucherRequest ReceivingVoucherRequest)
    {
      var ReceivingVoucher = new ReceivingVoucher()
      {
        ReceivingDate = (DateTime)ReceivingVoucherRequest.ReceivingDate,
        Notes = ReceivingVoucherRequest.Notes,
        WarehouseId = ReceivingVoucherRequest.WarehouseId,
        SupplierId = ReceivingVoucherRequest.SupplierId
      };


      var transact = _receivingVoucherRepository.BeginTransaction();
      try
      {
        var newReceivingVoucher = await _receivingVoucherRepository.AddAsync(ReceivingVoucher);

        foreach (var item in ReceivingVoucherRequest.receivingVoucherItemDT0s)
        {
          var receivingVoucherItem = new ReceivingVoucherItem()
          {
            receivingVoucherId = newReceivingVoucher.ReceivingVoucherId,
            Quantity = item.Quantity,
            UnitPrice = item.UnitPrice,
            ProductId = item.ProductId
          };

          await _receivingVoucherItemRepository.AddAsync(receivingVoucherItem);
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

    public async Task<string> DeleteAsync(ReceivingVoucher ReceivingVoucher)
    {

      var transact = _receivingVoucherRepository.BeginTransaction();
      try
      {
        await _receivingVoucherRepository.DeleteAsync(ReceivingVoucher);

        await transact.CommitAsync();
        return MessageCenter.CrudMessage.Success;

      }
      catch
      {
        await transact.RollbackAsync();
        return MessageCenter.CrudMessage.Falied;
      }
    }

    public async Task<GetReceivingVoucherByIdDto> GetReceivingVoucherByIdAsync(int id)
    {
      var ReceivingVoucher = _receivingVoucherRepository.GetTableNoTracking().Where(x => x.ReceivingVoucherId == id).Include(x => x.Warehouse).Include(x => x.Supplier).Include(x => x.receivingVoucherItems).ThenInclude(r => r.Product).SingleOrDefault();

      var dto = new GetReceivingVoucherByIdDto()
      {
        ReceivingVoucherId = ReceivingVoucher.ReceivingVoucherId,
        ReceivingDate = ReceivingVoucher.ReceivingDate,
        Notes = ReceivingVoucher.Notes,
        Warehouse = ReceivingVoucher.Warehouse,
        Supplier = ReceivingVoucher.Supplier,
        receivingVoucherItemsDto = new List<ReceivingVoucherItemDto>()
      };

      dto.receivingVoucherItemsDto.AddRange(ReceivingVoucher.receivingVoucherItems.Select(x => new ReceivingVoucherItemDto
      {
        ReceivingVoucherItemId = x.ReceivingVoucherItemId,
        Quantity = x.Quantity,
        UnitPrice = x.UnitPrice,
        TotalPrice = x.TotalPrice,
        Product = x.Product

      }));

      return dto;
    }

    public async Task<List<GetReceivingVoucherByIdDto>> GetReceivingVouchersListAsync()
    {
      var ReceivingVouchers = _receivingVoucherRepository.GetTableNoTracking().Include(x => x.Warehouse).Include(x => x.Supplier).ToList();

      var dtoList = new List<GetReceivingVoucherByIdDto>();

      dtoList.AddRange(ReceivingVouchers.Select(x => new GetReceivingVoucherByIdDto()
      {
        ReceivingVoucherId = x.ReceivingVoucherId,
        ReceivingDate = x.ReceivingDate,
        Notes = x.Notes,
        Warehouse = x.Warehouse,
        Supplier = x.Supplier

      }));

      return dtoList;
    }

    public async Task<string> UpdateAsync(UpdateReceivingVoucherRequest ReceivingVoucherRequest)
    {
      var ReceivingVoucher = new ReceivingVoucher()
      {
        ReceivingVoucherId = ReceivingVoucherRequest.ReceivingVoucherId,
        ReceivingDate = ReceivingVoucherRequest.ReceivingDate,
        Notes = ReceivingVoucherRequest.Notes,
        WarehouseId = ReceivingVoucherRequest.WarehouseId,
        SupplierId = ReceivingVoucherRequest.SupplierId
      };


      var transact = _receivingVoucherRepository.BeginTransaction();
      try
      {
        await _receivingVoucherRepository.UpdateAsync(ReceivingVoucher);

        foreach (var item in ReceivingVoucherRequest.receivingVoucherItems)
        {
          var receivingVoucherItem = new ReceivingVoucherItem()
          {
            receivingVoucherId = ReceivingVoucherRequest.ReceivingVoucherId,
            ReceivingVoucherItemId = item.ReceivingVoucherItemId,
            Quantity = item.Quantity,
            UnitPrice = item.UnitPrice,
            ProductId = item.ProductId
          };

          await _receivingVoucherItemRepository.UpdateAsync(receivingVoucherItem);
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
      var ReceivingVoucher = _receivingVoucherRepository.GetTableNoTracking().Where(x => x.ReceivingVoucherId == id).SingleOrDefault();

      if (ReceivingVoucher == null)
      {
        return MessageCenter.CrudMessage.DoesNotExist;
      }
      var transact = _receivingVoucherRepository.BeginTransaction();
      try
      {
        await _receivingVoucherRepository.DeleteAsync(ReceivingVoucher);

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
