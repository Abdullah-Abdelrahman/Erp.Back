using Erp.Data.Dto.RecurringInvoice;
using Erp.Data.Entities.SalesModule;
using Erp.Data.MetaData;
using Erp.Infrastructure.Abstracts.SalesModule;
using Erp.Service.Abstracts;
using Erp.Service.Abstracts.SalesModule;
using Microsoft.EntityFrameworkCore;

namespace Erp.Service.Implementations.SalesModule
{
  public class RecurringInvoiceService : IRecurringInvoiceService
  {
    private readonly IRecurringInvoiceRepository _RecurringInvoiceRepository;
    private readonly IRecurringInvoiceItemRepository _RecurringInvoiceItemRepository;
    private readonly IProductService _productService;




    // Isupplair
    public RecurringInvoiceService(IRecurringInvoiceRepository RecurringInvoiceRepository, IProductService productService, IWarehouseService warehouseService, IRecurringInvoiceItemRepository RecurringInvoiceItemRepository)
    {
      _RecurringInvoiceRepository = RecurringInvoiceRepository;
      _RecurringInvoiceItemRepository = RecurringInvoiceItemRepository;
      _productService = productService;

    }
    public async Task<string> AddRecurringInvoice(AddRecurringInvoiceRequest RecurringInvoiceRequest)
    {
      var RecurringInvoice = new RecurringInvoice(RecurringInvoiceRequest);



      var transact = _RecurringInvoiceRepository.BeginTransaction();
      try
      {
        var newRecurringInvoice = await _RecurringInvoiceRepository.AddAsync(RecurringInvoice);

        foreach (var item in RecurringInvoiceRequest.RecurringInvoiceItemDT0s)
        {
          var RecurringInvoiceItem = new RecurringInvoiceItem(item, newRecurringInvoice.Id);


          await _RecurringInvoiceItemRepository.AddAsync(RecurringInvoiceItem);
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

    public async Task<string> DeleteAsync(RecurringInvoice RecurringInvoice)
    {

      var transact = _RecurringInvoiceRepository.BeginTransaction();
      try
      {
        await _RecurringInvoiceRepository.DeleteAsync(RecurringInvoice);

        await transact.CommitAsync();
        return MessageCenter.CrudMessage.Success;

      }
      catch
      {
        await transact.RollbackAsync();
        return MessageCenter.CrudMessage.Falied;
      }
    }

    public async Task<GetRecurringInvoiceByIdDto> GetRecurringInvoiceByIdAsync(int id)
    {
      var RecurringInvoice = _RecurringInvoiceRepository.GetTableNoTracking().Where(x => x.Id == id).Include(x => x.Customer).Include(x => x.Items).ThenInclude(r => r.product).SingleOrDefault();

      var dto = new GetRecurringInvoiceByIdDto()
      {
        RecurringInvoiceId = RecurringInvoice.Id,
        CustomerId = RecurringInvoice.CustomerId,
        StartDate = RecurringInvoice.StartDate,
        NextInvoiceDate = RecurringInvoice.NextInvoiceDate,
        Frequency = RecurringInvoice.Frequency,
        sendEmail = RecurringInvoice.sendEmail,
        automaticPayment = RecurringInvoice.automaticPayment,
        DisplayRange = RecurringInvoice.DisplayRange,
        IsActive = RecurringInvoice.IsActive,
        Tax = RecurringInvoice.Tax,
        Discount = RecurringInvoice.Discount,
        Total = RecurringInvoice.Total,
        RecurringInvoiceItemsDto = new List<RecurringInvoiceItemDto>()
      };

      dto.RecurringInvoiceItemsDto.AddRange(RecurringInvoice.Items.Select(x => new RecurringInvoiceItemDto
      {
        RecurringInvoiceItemId = x.ID,
        RecurringInvoiceId = x.RInvoiceID,
        ProductId = x.productID,
        Description = x.Description,
        Quantity = x.Quantity,
        UnitPrice = x.UnitPrice,
        discount = x.Discount,
        Tax = x.Tax

      }));

      return dto;
    }

    public async Task<List<GetRecurringInvoiceByIdDto>> GetRecurringInvoicesListAsync()
    {
      var RecurringInvoices = _RecurringInvoiceRepository.GetTableNoTracking().Include(x => x.Customer).ToList();

      var dtoList = new List<GetRecurringInvoiceByIdDto>();

      dtoList.AddRange(RecurringInvoices.Select(x => new GetRecurringInvoiceByIdDto()
      {
        RecurringInvoiceId = x.Id,
        CustomerId = x.CustomerId,
        StartDate = x.StartDate,
        NextInvoiceDate = x.NextInvoiceDate,
        Frequency = x.Frequency,
        sendEmail = x.sendEmail,
        automaticPayment = x.automaticPayment,
        DisplayRange = x.DisplayRange,
        IsActive = x.IsActive,
        Tax = x.Tax,
        Discount = x.Discount,
        Total = x.Total,

      }));

      return dtoList;
    }

    public async Task<string> UpdateAsync(UpdateRecurringInvoiceRequest RecurringInvoiceRequest)
    {
      var RecurringInvoice = new RecurringInvoice(RecurringInvoiceRequest);



      var transact = _RecurringInvoiceRepository.BeginTransaction();
      try
      {
        await _RecurringInvoiceRepository.UpdateAsync(RecurringInvoice);

        foreach (var item in RecurringInvoiceRequest.RecurringInvoiceItems)
        {
          var RecurringInvoiceItem = new RecurringInvoiceItem(item);


          await _RecurringInvoiceItemRepository.UpdateAsync(RecurringInvoiceItem);
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
      var RecurringInvoice = _RecurringInvoiceRepository.GetTableNoTracking().Where(x => x.Id == id).SingleOrDefault();

      if (RecurringInvoice == null)
      {
        return MessageCenter.CrudMessage.DoesNotExist;
      }
      var transact = _RecurringInvoiceRepository.BeginTransaction();
      try
      {
        await _RecurringInvoiceRepository.DeleteAsync(RecurringInvoice);

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
