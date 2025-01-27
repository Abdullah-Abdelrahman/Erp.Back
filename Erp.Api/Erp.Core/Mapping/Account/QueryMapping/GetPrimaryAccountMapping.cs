using Erp.Core.Features.Account.Queries.Results;
using Erp.Data.Entities.AccountsModule;

namespace Erp.Core.Mapping.Account
{
  public partial class AccountProfile
  {
    public void GetPrimaryAccountMapping()
    {
      CreateMap<PrimaryAccount, GetPrimaryAccountByIdResult>()
                .ForMember(dest => dest.ChildAccounts, opt => opt.MapFrom(src => src.ChildAccounts)).ForMember(dest => dest.Type, opt => opt.MapFrom(src => src.Type));
    }
  }
}
