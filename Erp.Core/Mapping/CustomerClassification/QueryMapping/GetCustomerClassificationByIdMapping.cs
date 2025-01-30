using Erp.Core.Features.CustomerClassification.Queries.Results;
using Entitis = Erp.Data.Entities;
namespace Erp.Core.Mapping.CustomerClassification
{
  public partial class CustomerClassificationProfile
  {

    public void GetCustomerClassificationByIdMapping()
    {
      CreateMap<Entitis.CustomersModule.CustomerClassification, GetCustomerClassificationByIdResult>().
     ForMember(destnation => destnation.CustomerClassificationId, opt => opt.MapFrom(src => src.Id)).ForMember(destnation => destnation.CustomerClassificationName, opt => opt.MapFrom(src => src.Name));


    }
  }
}
