using Erp.Core.Features.Supplier.Commands.Models;
using Entitis = Erp.Data.Entities;
namespace Erp.Core.Mapping.Supplier
{
  public partial class SupplierProfile
  {
    public void AddSupplierMapping()
    {
      CreateMap<AddSupplierCommand, Entitis.Supplier>()
        .ForMember(destnation => destnation.Address, opt => opt.MapFrom(src => src.Address));
    }
  }
}
