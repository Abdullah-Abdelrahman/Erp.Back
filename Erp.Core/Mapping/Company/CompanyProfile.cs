using AutoMapper;

namespace Erp.Core.Mapping.Company
{
  public partial class CompanyProfile : Profile
  {
    public CompanyProfile()
    {
      AddCompanyMapping();



      GetCompanyByIdMapping();
    }
  }
}
