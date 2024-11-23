using AutoMapper;

namespace Name.Core.Mapping.User
{
    public partial class UserBaseProfile : Profile
    {

        public UserBaseProfile()
        {
            AddUserMapping();
            EditUserMapping();

            GetUserListMapping();
            GetUserByIdMapping();
        }
    }
}
