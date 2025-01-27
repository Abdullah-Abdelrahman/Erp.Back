using Erp.Core.Features.Account.Commands.Models;
using Entitis = Erp.Data.Entities;
namespace Erp.Core.Mapping.Account
{
  public partial class AccountProfile
  {
    public void AddAccountMapping()
    {
      CreateMap<AddAccountCommand, Entitis.AccountsModule.Account>()
             .ForMember(dest => dest.AccountName, opt => opt.MapFrom(src => src.AccountName));

      CreateMap<AddAccountCommand, Entitis.AccountsModule.PrimaryAccount>()
          .ForMember(dest => dest.AccountName, opt => opt.MapFrom(src => src.AccountName));

      CreateMap<AddAccountCommand, Entitis.AccountsModule.SecondaryAccount>()
          .ForMember(dest => dest.AccountName, opt => opt.MapFrom(src => src.AccountName));
    }
  }
}
