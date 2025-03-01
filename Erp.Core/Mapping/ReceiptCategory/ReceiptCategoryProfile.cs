using AutoMapper;

namespace Erp.Core.Mapping.ReceiptCategory
{
  public partial class ReceiptCategoryProfile : Profile
  {
    public ReceiptCategoryProfile()
    {
      AddReceiptCategoryMapping();
      EditReceiptCategoryMapping();


      GetReceiptCategoryByIdMapping();
    }
  }
}
