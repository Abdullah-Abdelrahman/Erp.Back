using AutoMapper;

namespace Erp.Core.Mapping.CustomerClassification
{
  public partial class CustomerClassificationProfile : Profile
  {
    public CustomerClassificationProfile()
    {
      AddCustomerClassificationMapping();

      GetCustomerClassificationByIdMapping();
    }
  }
}
