using Erp.Data.Dto.ApplicationRole;
using Name.Core.Features.Authorization.Quaries.Results;

namespace Name.Core.Mapping.Authorization
{
  public partial class RoleProfile
  {

    public void GetRoleByIdMapping()
    {
      CreateMap<GetApplicationRoleRequest, GetRoleByIdResponse>()
        .ForMember(destnation => destnation.Id, opt => opt.MapFrom(src => src.Id))
 .ForMember(destnation => destnation.Name, opt => opt.MapFrom(src => src.Name));
    }
  }
}
