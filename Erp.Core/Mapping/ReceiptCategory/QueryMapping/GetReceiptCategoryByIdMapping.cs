using Erp.Core.Features.ReceiptCategory.Queries.Results;
using Entitis = Erp.Data.Entities.Finance;
namespace Erp.Core.Mapping.ReceiptCategory
{
  public partial class ReceiptCategoryProfile
  {

    public void GetReceiptCategoryByIdMapping()
    {
      CreateMap<Entitis.ReceiptCategory, GetReceiptCategoryByIdResult>().
     ForMember(destnation => destnation.Id, opt => opt.MapFrom(src => src.Id)).ForMember(destnation => destnation.Name, opt => opt.MapFrom(src => src.Name));


    }
  }
}
