using Erp.Core.Features.Supplier.Queries.Results;
using Entitis = Erp.Data.Entities;
namespace Erp.Core.Mapping.Supplier
{
  public partial class SupplierProfile
  {
    public void GetSupplierListMapping()
    {
      CreateMap<Entitis.PurchasesModule.Supplier, GetSupplierListResult>().
  ForMember(destnation => destnation.SupplierId, opt => opt.MapFrom(src => src.SupplierId));
    }
  }
}
