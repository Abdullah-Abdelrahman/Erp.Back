using Erp.Core.Features.CustomerClassification.Commands.Models;
using Entitis = Erp.Data.Entities;
namespace Erp.Core.Mapping.CustomerClassification
{
  public partial class CustomerClassificationProfile
  {

    public void AddCustomerClassificationMapping()
    {
      CreateMap<AddCustomerClassificationCommand, Entitis.CustomersModule.CustomerClassification>()
       .ForMember(destnation => destnation.Name, opt => opt.MapFrom(src => src.CustomerClassificationName));
    }
  }
}
