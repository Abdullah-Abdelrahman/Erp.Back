using Erp.Data.Dto.ApplicationRole;
using Erp.Data.Entities.HumanResources.Staff;
using Erp.Data.Entities.MainModule;
using Name.Data.Dto;

namespace Name.Service.Abstracts
{
  public interface IAuthorizationService
  {
    public Task<bool> IsRoleExistByName(string roleName);

    public Task<bool> IsRoleExistById(string roleId);

    public Task<string> CreateRoleAsync(AddApplicationRoleRequest role);

    public Task<List<ApplicationRole>> GetRolesList();

    public Task<GetApplicationRoleRequest> GetRoleById(string id);

    public Task<string> DeleteRoleAsync(ApplicationRole role);

    public Task<ManageUserRolesResult> ManageUserRolesData(UserBase user);

    public Task<string> UpdateUserRoles(UpdateUserRolesRequest request);

    public Task<ManageUserClaimsResult> ManageUserClaimData(UserBase user);

    public Task<string> UpdateUserClaims(UpdateUserClaimsRequest request);

    public Task<GetActiveModelsClamisRequest> GetActiveModelsClamisAsync();

    public Task<string> UpdateRoleAsync(EditApplicationRoleRequest request);

  }
}
