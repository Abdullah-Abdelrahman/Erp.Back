using Erp.Data.Dto.ProductAndService;
using Erp.Data.Entities.InventoryModule;

namespace Erp.Core.Features.ProductAndService.Queries.Results
{
  public class GetProductAndServicePaginatedListResult : GetProductAndServicePaginatedListRequest
  {

    public GetProductAndServicePaginatedListResult(
     int id,
     string name,
     string description,
     string internalNotes,
     decimal purchasePrice,
     decimal sellPrice,
     decimal lowestSellingPrice,
     ProductStatus status,
     string? imagePath,
     List<int> categoriesIds,
     ProductOrService productOrService,
     int? stockQuantity,
     int? minAmountBeforNotefy, int? supplierId)
    {
      Id = id;
      Name = name;
      Description = description;
      InternalNotes = internalNotes;
      PurchasePrice = purchasePrice;
      SellPrice = sellPrice;
      LowestSellingPrice = lowestSellingPrice;
      Status = status;
      ImagePath = imagePath;
      CategoriesIds = categoriesIds;
      ProductOrService = productOrService;
      StockQuantity = stockQuantity;
      MinAmountBeforNotefy = minAmountBeforNotefy;
      SupplierId = supplierId;
    }
  }


}
