using Erp.Core.Features.Supplier.Queries.Results;
using Entitis = Erp.Data.Entities;
namespace Erp.Core.Mapping.Supplier
{
  public partial class SupplierProfile
  {
    public void GetSupplierByIdMapping()
    {
      CreateMap<Entitis.PurchasesModule.Supplier, GetSupplierByIdResult>().
        ForMember(destnation => destnation.SupplierId, opt => opt.MapFrom(src => src.SupplierId)).
        ForMember(destnation => destnation.PurchaseInvoices, opt => opt.MapFrom(src => src.PurchaseInvoices)).
        ForMember(destnation => destnation.supplierPayments, opt => opt.MapFrom(src => src.supplierPayments));
    }
  }
}

