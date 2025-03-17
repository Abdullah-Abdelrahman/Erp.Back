using Erp.Core.Features.ProductAndService.Queries.Results;
using Erp.Core.Wrappers;
using Erp.Data.Entities.InventoryModule;
using MediatR;

namespace Erp.Core.Features.Payment.Queries.Models
{
  public class GetProductAndServicePaginatedListQuery :
    IRequest<PaginatedResult<GetProductAndServicePaginatedListResult>>
  {
    public int PageNumber { get; set; }

    public int PageSize { get; set; }

    public string[]? OrderBy { get; set; }

    public string? Search { get; set; }

    public ProductStatus? Status { get; set; }

    public int? CategoryId { get; set; }



  }
}
