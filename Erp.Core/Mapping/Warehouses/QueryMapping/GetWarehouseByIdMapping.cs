using Erp.Core.Features.Warehouses.Queries.Results;
using Entitis = Erp.Data.Entities;

namespace Erp.Core.Mapping.Warehouses
{
  public partial class WarehouseProfile
  {
    public void GetWarehouseByIdMapping()
    {
      CreateMap<Entitis.Warehouse, GetWarehouseByIdResult>().
      ForMember(destnation => destnation.WarehouseId, opt => opt.MapFrom(src => src.WarehouseId)).ForMember(destnation => destnation.StockTransactions, opt => opt.MapFrom(src => src.StockTransactions));
    }
  }
}
