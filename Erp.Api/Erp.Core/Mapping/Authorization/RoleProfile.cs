using AutoMapper;

namespace Name.Core.Mapping.Authorization
{
    public partial class RoleProfile : Profile
    {
        public RoleProfile()
        {
            GetRoleListMapping();


            GetRoleByIdMapping();
        }
    }
}
