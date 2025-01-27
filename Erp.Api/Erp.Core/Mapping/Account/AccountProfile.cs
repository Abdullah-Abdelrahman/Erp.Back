using AutoMapper;

namespace Erp.Core.Mapping.Account
{
  public partial class AccountProfile : Profile
  {
    public AccountProfile()
    {
      AddAccountMapping();


      GetPrimaryAccountMapping();
      GetSecondaryAccountMapping();
    }
  }
}
