using AutoMapper;
using Erp.Data.Entities.MainModule;
using Name.Core.Features.UserBase.Queries.Results;

namespace Name.Core.Mapping.User
{
  public partial class UserBaseProfile : Profile
    {
        public void GetUserByIdMapping()
        {
            CreateMap<UserBase, GetUserByIdResponse>().ForMember(destnation => destnation.PhoneNumber, opt => opt.MapFrom(src => src.PhoneNumber)).ForMember(destnation => destnation.UserName, opt => opt.MapFrom(src => src.UserName));
        }
    }
}
