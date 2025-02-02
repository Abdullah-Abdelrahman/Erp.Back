using Erp.Data.Entities.MainModule;
using Name.Core.Features.UserBase.Queries.Results;

namespace Name.Core.Mapping.User
{
  public partial class UserBaseProfile
    {

        public void GetUserListMapping()
        {
            CreateMap<UserBase, GetUserListResponse>().ForMember(destnation => destnation.PhoneNumber, opt => opt.MapFrom(src => src.PhoneNumber))
                .ForMember(destnation => destnation.UserName, opt => opt.MapFrom(src => src.UserName))
                .ForMember(destnation => destnation.UserId, opt => opt.MapFrom(src => src.Id));
        }
    }
}
