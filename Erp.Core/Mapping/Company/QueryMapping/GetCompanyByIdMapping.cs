using Erp.Core.Features.Company.Queries.Results;
using Entitis = Erp.Data.Entities;
namespace Erp.Core.Mapping.Company
{
  public partial class CompanyProfile
  {
    public void GetCompanyByIdMapping()
    {
      CreateMap<Entitis.MainModule.Company, GetCompanyByIdResult>().
        ForMember(destnation => destnation.CompanyID, opt => opt.MapFrom(src => src.CompanyID));
    }
  }
}
