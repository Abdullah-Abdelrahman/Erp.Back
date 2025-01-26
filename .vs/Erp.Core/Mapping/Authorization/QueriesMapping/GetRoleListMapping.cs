using Name.Core.Features.Authorization.Quaries.Results;
using Microsoft.AspNetCore.Identity;

namespace Name.Core.Mapping.Authorization
{
    public partial class RoleProfile
    {
        public void GetRoleListMapping()
        {
            CreateMap<IdentityRole, GetRoleListResponse>().ForMember(destnation => destnation.RoleId, opt => opt.MapFrom(src => src.Id))
          .ForMember(destnation => destnation.RoleName, opt => opt.MapFrom(src => src.Name));

        }
    }
}
