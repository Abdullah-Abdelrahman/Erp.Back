using Erp.Data.Dto.Quotation;
using Erp.Data.Entities.SalesModule;
using Erp.Data.MetaData;
using Erp.Infrastructure.Abstracts.SalesModule;
using Erp.Service.Abstracts;
using Erp.Service.Abstracts.SalesModule;
using Microsoft.EntityFrameworkCore;

namespace Erp.Service.Implementations.SalesModule
{
  public class QuotationService : IQuotationService
  {
    private readonly IQuotationRepository _QuotationRepository;
    private readonly IQuotationItemRepository _QuotationItemRepository;
    private readonly IProductService _productService;




    // Isupplair
    public QuotationService(IQuotationRepository QuotationRepository, IProductService productService, IWarehouseService warehouseService, IQuotationItemRepository QuotationItemRepository)
    {
      _QuotationRepository = QuotationRepository;
      _QuotationItemRepository = QuotationItemRepository;
      _productService = productService;

    }
    public async Task<string> AddQuotation(AddQuotationRequest QuotationRequest)
    {
      var Quotation = new Quotation(QuotationRequest);



      var transact = _QuotationRepository.BeginTransaction();
      try
      {
        var newQuotation = await _QuotationRepository.AddAsync(Quotation);
        decimal total = 0;
        foreach (var item in QuotationRequest.QuotationItemDT0s)
        {
          var QuotationItem = new QuotationItem(item, newQuotation.QuotationId);

          total += QuotationItem.Total;
          await _QuotationItemRepository.AddAsync(QuotationItem);
        }
        newQuotation.Total = total;

        await _QuotationRepository.UpdateAsync(newQuotation);




        await transact.CommitAsync();
        return MessageCenter.CrudMessage.Success;

      }
      catch
      {
        await transact.RollbackAsync();
        return MessageCenter.CrudMessage.Falied;
      }

    }

    public async Task<string> DeleteAsync(Quotation Quotation)
    {

      var transact = _QuotationRepository.BeginTransaction();
      try
      {
        await _QuotationRepository.DeleteAsync(Quotation);

        await transact.CommitAsync();
        return MessageCenter.CrudMessage.Success;

      }
      catch
      {
        await transact.RollbackAsync();
        return MessageCenter.CrudMessage.Falied;
      }
    }

    public async Task<GetQuotationByIdDto> GetQuotationByIdAsync(int id)
    {
      var Quotation = _QuotationRepository.GetTableNoTracking().Where(x => x.QuotationId == id).Include(x => x.Customer).Include(x => x.Items).ThenInclude(r => r.Product).SingleOrDefault();

      var dto = new GetQuotationByIdDto()
      {
        QuotationId = Quotation.QuotationId,
        CustomerID = Quotation.CustomerId,
        QuoteDate = Quotation.QuoteDate,
        ExpiryDate = Quotation.ExpiryDate,
        Tax = Quotation.TaxAmount,
        Discount = Quotation.Discount,
        GrandTotal = Quotation.Total,
        Status = Quotation.Status,
        QuotationItemsDto = new List<QuotationItemDto>()
      };

      dto.QuotationItemsDto.AddRange(Quotation.Items.Select(x => new QuotationItemDto
      {
        QuotationItemId = x.Id,
        QuotationId = x.QuotationId,
        ProductId = x.ProductId,
        Description = x.Description,
        Quantity = x.Quantity,
        UnitPrice = x.UnitPrice,
        discount = x.Discount,
        Tax = x.Tax

      }));

      return dto;
    }

    public async Task<List<GetQuotationByIdDto>> GetQuotationsListAsync()
    {
      var Quotations = _QuotationRepository.GetTableNoTracking().Include(x => x.Customer).ToList();

      var dtoList = new List<GetQuotationByIdDto>();

      dtoList.AddRange(Quotations.Select(x => new GetQuotationByIdDto()
      {
        QuotationId = x.QuotationId,
        CustomerID = x.CustomerId,
        QuoteDate = x.QuoteDate,
        ExpiryDate = x.ExpiryDate,
        Tax = x.TaxAmount,
        Discount = x.Discount,
        GrandTotal = x.Total,
        Status = x.Status,

      }));

      return dtoList;
    }

    public async Task<string> UpdateAsync(UpdateQuotationRequest QuotationRequest)
    {
      var Quotation = new Quotation(QuotationRequest);



      var transact = _QuotationRepository.BeginTransaction();
      try
      {
        await _QuotationRepository.UpdateAsync(Quotation);

        foreach (var item in QuotationRequest.QuotationItems)
        {
          var QuotationItem = new QuotationItem(item);


          if (item.QuotationItemId != null)
          {
            await _QuotationItemRepository.UpdateAsync(QuotationItem);

          }
          else
          {
            await _QuotationItemRepository.AddAsync(QuotationItem);

          }
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
      var Quotation = _QuotationRepository.GetTableNoTracking().Where(x => x.QuotationId == id).SingleOrDefault();

      if (Quotation == null)
      {
        return MessageCenter.CrudMessage.DoesNotExist;
      }
      var transact = _QuotationRepository.BeginTransaction();
      try
      {
        await _QuotationRepository.DeleteAsync(Quotation);

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
