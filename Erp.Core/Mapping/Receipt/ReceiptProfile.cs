using AutoMapper;

namespace Erp.Core.Mapping.Receipt
{
  public partial class ReceiptProfile : Profile
  {
    public ReceiptProfile()
    {
      AddReceiptMapping();
    }
  }
}
