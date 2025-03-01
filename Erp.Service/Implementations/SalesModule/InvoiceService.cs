using Erp.Data.Dto.Invoice;
using Erp.Data.Entities.SalesModule;
using Erp.Data.MetaData;
using Erp.Infrastructure.Abstracts.SalesModule;
using Erp.Service.Abstracts;
using Erp.Service.Abstracts.SalesModule;
using Microsoft.EntityFrameworkCore;

namespace Erp.Service.Implementations.SalesModule
{
  public class InvoiceService : IInvoiceService
  {
    private readonly IInvoiceRepository _InvoiceRepository;
    private readonly IInvoiceItemRepository _InvoiceItemRepository;
    private readonly IProductService _productService;




    // Isupplair
    public InvoiceService(IInvoiceRepository InvoiceRepository, IProductService productService, IWarehouseService warehouseService, IInvoiceItemRepository InvoiceItemRepository)
    {
      _InvoiceRepository = InvoiceRepository;
      _InvoiceItemRepository = InvoiceItemRepository;
      _productService = productService;

    }
    public async Task<string> AddInvoice(AddInvoiceRequest InvoiceRequest)
    {
      var invoice = new Invoice(InvoiceRequest);



      var transact = _InvoiceRepository.BeginTransaction();
      try
      {
        var newInvoice = await _InvoiceRepository.AddAsync(invoice);
        decimal total = 0;
        foreach (var item in InvoiceRequest.InvoiceItemDT0s)
        {
          var InvoiceItem = new InvoiceItem(item, newInvoice.InvoiceID);
          total += InvoiceItem.Total;

          await _InvoiceItemRepository.AddAsync(InvoiceItem);
        }

        newInvoice.Total = total;

        await _InvoiceRepository.UpdateAsync(newInvoice);


        await transact.CommitAsync();
        return MessageCenter.CrudMessage.Success;

      }
      catch (Exception ex)
      {
        await transact.RollbackAsync();
        return MessageCenter.CrudMessage.Falied + ex.InnerException;
      }

    }

    public async Task<string> DeleteAsync(Invoice Invoice)
    {

      var transact = _InvoiceRepository.BeginTransaction();
      try
      {
        await _InvoiceRepository.DeleteAsync(Invoice);

        await transact.CommitAsync();
        return MessageCenter.CrudMessage.Success;

      }
      catch
      {
        await transact.RollbackAsync();
        return MessageCenter.CrudMessage.Falied;
      }
    }

    public async Task<GetInvoiceByIdDto> GetInvoiceByIdAsync(int id)
    {
      var Invoice = _InvoiceRepository.GetTableNoTracking().Where(x => x.InvoiceID == id).Include(x => x.Customer).Include(x => x.Items).ThenInclude(r => r.product).SingleOrDefault();

      var dto = new GetInvoiceByIdDto()
      {
        InvoiceId = Invoice.InvoiceID,
        CustomerID = Invoice.CustomerID,
        InvoiceDate = Invoice.InvoiceDate,
        ReleaseDate = Invoice.ReleaseDate,
        PaymentTerms = Invoice.PaymentTerms,
        Tax = Invoice.Tax,
        Discount = Invoice.Discount,
        Total = Invoice.Total,
        Status = Invoice.Status,
        InvoiceItemsDto = new List<InvoiceItemDto>()
      };

      dto.InvoiceItemsDto.AddRange(Invoice.Items.Select(x => new InvoiceItemDto
      {
        InvoiceItemId = x.InvoiceItemID,
        InvoiceId = x.InvoiceID,
        ProductId = x.productID,
        Description = x.Description,
        Quantity = x.Quantity,
        UnitPrice = x.UnitPrice,
        discount = x.Discount,
        Tax = x.Tax,
        TotalPrice = x.Total

      }));

      return dto;
    }

    public async Task<List<GetInvoiceByIdDto>> GetInvoicesListAsync()
    {
      var Invoices = _InvoiceRepository.GetTableNoTracking().Include(x => x.Customer).ToList();

      var dtoList = new List<GetInvoiceByIdDto>();

      dtoList.AddRange(Invoices.Select(x => new GetInvoiceByIdDto()
      {
        InvoiceId = x.InvoiceID,
        CustomerID = x.CustomerID,
        InvoiceDate = x.InvoiceDate,
        ReleaseDate = x.ReleaseDate,
        PaymentTerms = x.PaymentTerms,
        Tax = x.Tax,
        Discount = x.Discount,
        Total = x.Total,
        Status = x.Status,

      }));

      return dtoList;
    }

    public async Task<string> UpdateAsync(UpdateInvoiceRequest InvoiceRequest)
    {
      var Invoice = new Invoice(InvoiceRequest);



      var transact = _InvoiceRepository.BeginTransaction();
      try
      {
        await _InvoiceRepository.UpdateAsync(Invoice);

        decimal total = 0;

        foreach (var item in InvoiceRequest.InvoiceItems)
        {
          var InvoiceItem = new InvoiceItem(item);
          total += InvoiceItem.Total;
          if (item.InvoiceItemId != null)
          {
            await _InvoiceItemRepository.UpdateAsync(InvoiceItem);

          }
          else
          {
            await _InvoiceItemRepository.AddAsync(InvoiceItem);

          }
        }

        Invoice.Total = total;
        await _InvoiceRepository.UpdateAsync(Invoice);


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
      var Invoice = _InvoiceRepository.GetTableNoTracking().Where(x => x.InvoiceID == id).SingleOrDefault();

      if (Invoice == null)
      {
        return MessageCenter.CrudMessage.DoesNotExist;
      }
      var transact = _InvoiceRepository.BeginTransaction();
      try
      {
        await _InvoiceRepository.DeleteAsync(Invoice);

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
