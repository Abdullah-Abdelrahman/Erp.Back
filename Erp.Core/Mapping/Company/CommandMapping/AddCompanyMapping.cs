using Erp.Core.Features.Company.Commands.Models;
using Entitis = Erp.Data.Entities;
namespace Erp.Core.Mapping.Company
{
  public partial class CompanyProfile
  {
    public void AddCompanyMapping()
    {
      CreateMap<AddCompanyCommand, Entitis.MainModule.Company>()
        .ForMember(destnation => destnation.CompanyName, opt => opt.MapFrom(src => src.CompanyName));
    }
  }
}
