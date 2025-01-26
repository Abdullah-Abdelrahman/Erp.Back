using Name.Core.Features.UserBase.Commands.Models;
using Name.Data.Entities;

namespace Name.Core.Mapping.User
{
    public partial class UserBaseProfile
    {

        public void AddUserMapping()
        {
            CreateMap<AddUserCommand, UserBase>().ForMember(destnation => destnation.PhoneNumber, opt => opt.MapFrom(src => src.PhoneNumber)).ForMember(destnation => destnation.UserName, opt => opt.MapFrom(src => src.UserName));
        }
    }
}
