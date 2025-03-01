using Erp.Core.Features.ReceiptCategory.Commands.Models;
using Entitis = Erp.Data.Entities;
namespace Erp.Core.Mapping.ReceiptCategory
{
  public partial class ReceiptCategoryProfile
  {

    public void AddReceiptCategoryMapping()
    {
      CreateMap<AddReceiptCategoryCommand, Entitis.Finance.ReceiptCategory>()
       .ForMember(destnation => destnation.Name, opt => opt.MapFrom(src => src.Name));
    }
  }
}
