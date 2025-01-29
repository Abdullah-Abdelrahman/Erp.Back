using Erp.Core.Features.Warehouses.Commands.Models;
using Erp.Data.Entities.InventoryModule;
using Entitis = Erp.Data.Entities;

namespace Erp.Core.Mapping.Warehouses
{
  public partial class WarehouseProfile
  {
    public void AddWarehouseMapping()
    {
      CreateMap<AddWarehouseCommand, Warehouse>()
      .ForMember(destnation => destnation.Address, opt => opt.MapFrom(src => src.Address));
    }
  }
}
