using Erp.Core.Features.Account.Queries.Results;
using Erp.Data.Entities.AccountsModule;

namespace Erp.Core.Mapping.Account
{
  public partial class AccountProfile
  {
    public void GetSecondaryAccountMapping()
    {
      CreateMap<SecondaryAccount, GetSecondaryAccountByIdResult>()
                .ForMember(dest => dest.journalEntryDetails, opt => opt.MapFrom(src => src.journalEntryDetails)).ForMember(dest => dest.Type, opt => opt.MapFrom(src => src.Type));
    }
  }
}
