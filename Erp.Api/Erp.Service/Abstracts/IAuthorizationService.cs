using Name.Data.Dto;
using Name.Data.Entities;
using Microsoft.AspNetCore.Identity;

namespace Name.Service.Abstracts
{
    public interface IAuthorizationService
    {
        public Task<bool> IsRoleExistByName(string roleName);

        public Task<bool> IsRoleExistById(string roleId);

        public Task<List<IdentityRole>> GetRolesList();

        public Task<IdentityRole> GetRoleById(string id);

        public Task<string> DeleteRoleAsync(IdentityRole role);

        public Task<ManageUserRolesResult> ManageUserRolesData(UserBase user);

        public Task<string> UpdateUserRoles(UpdateUserRolesRequest request);

        public Task<ManageUserClaimsResult> ManageUserClaimData(UserBase user);

        public Task<string> UpdateUserClaims(UpdateUserClaimsRequest request);
    }
}
