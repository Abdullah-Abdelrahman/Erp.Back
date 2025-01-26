using AutoMapper;

namespace Erp.Core.Mapping.Warehouses
{
  public partial class WarehouseProfile : Profile
  {
    public WarehouseProfile()
    {
      AddWarehouseMapping();

      GetWarehouseByIdMapping();
    }

  }
}
