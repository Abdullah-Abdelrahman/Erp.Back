using Erp.Core.Features.Warehouses.Commands.Models;
using Entitis = Erp.Data.Entities;

namespace Erp.Core.Mapping.Warehouses
{
  public partial class WarehouseProfile
  {
    public void AddWarehouseMapping()
    {
      CreateMap<AddWarehouseCommand, Entitis.Warehouse>()
      .ForMember(destnation => destnation.Address, opt => opt.MapFrom(src => src.Address));
    }
  }
}
