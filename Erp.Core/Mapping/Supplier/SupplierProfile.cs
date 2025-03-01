using AutoMapper;

namespace Erp.Core.Mapping.Supplier
{
  public partial class SupplierProfile : Profile
  {
    public SupplierProfile()
    {
      AddSupplierMapping();
      EditSupplierMapping();


      GetSupplierByIdMapping();
    }
  }
}
