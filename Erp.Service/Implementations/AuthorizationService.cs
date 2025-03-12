using Erp.Data.Dto.ApplicationRole;
using Erp.Data.Entities.HumanResources.Staff;
using Erp.Data.Entities.MainModule;
using Erp.Data.MetaData;
using Erp.Service.Abstracts.MainModule;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Name.Data.Dto;
using Name.Infrastructure.Data;
using Name.Service.Abstracts;
using System.Security.Claims;

namespace Name.Service.Implementations
{
  internal class AuthorizationService : IAuthorizationService
  {
    private readonly RoleManager<ApplicationRole> _roleManager;
    private readonly UserManager<UserBase> _userManager;
    private readonly ApplicationDBContext _dbContext;
    private readonly ICompanyModuleService _companyModuleService;
    private readonly IModuleService _moduleService;

    public AuthorizationService(
      RoleManager<ApplicationRole> roleManager,
      UserManager<UserBase> userManager,
      ApplicationDBContext dbContext,
      ICompanyModuleService companyModuleService,
      IModuleService moduleService)
    {
      _userManager = userManager;
      _roleManager = roleManager;
      _dbContext = dbContext;
      _companyModuleService = companyModuleService;
      _moduleService = moduleService;
    }

    public async Task<string> DeleteRoleAsync(ApplicationRole role)
    {

      var result = await _roleManager.DeleteAsync(role);


      //check if any user has this rule
      var users = _userManager.GetUsersInRoleAsync(role.Name);

      if (result.Succeeded)
      {
        return "Success";
      }
      else
      {
        return "Failed";
      }
    }

    public async Task<GetApplicationRoleRequest> GetRoleById(string id)
    {
      var role = (await _roleManager.FindByIdAsync(id));
      var clamis = await _roleManager.GetClaimsAsync(role);
      if (role == null)
      {
        return new GetApplicationRoleRequest();
      }
      var roleRes = new GetApplicationRoleRequest()
      {
        Id = id,
        Name = role.Name
      };
      var modulsIds = (await _companyModuleService.GetActiveModulesListAsync()).Select(x => x.ModuleID);

      foreach (var Mid in modulsIds)
      {
        var model = await _moduleService.GetModuleByIdAsync(Mid);

        var claimsDto = new List<ClaimDto>();
        foreach (var c in model.ClaimList)
        {
          if (clamis.Any(x => x.Type == c))
          {
            claimsDto.Add(new ClaimDto() { name = c, value = true });
          }
          else
          {
            claimsDto.Add(new ClaimDto() { name = c, value = false });

          }
        }

        roleRes.modelClaimsDtos.Add(new ModelClaimsDto()
        {
          ModelName = model.ModuleName,
          ModelId = Mid,
          claims = claimsDto
        });
      }

      return roleRes;
    }

    public Task<List<ApplicationRole>> GetRolesList()
    {
      var roles = _roleManager.Roles;

      return roles.ToListAsync();
    }

    public async Task<bool> IsRoleExistById(string roleId)
    {
      var result = await _roleManager.FindByIdAsync(roleId);
      if (result == null)
      {
        return false;
      }
      else
      {
        return true;
      }
    }

    public async Task<bool> IsRoleExistByName(string roleName)
    {
      var result = await _roleManager.FindByNameAsync(roleName);
      if (result == null)
      {
        return false;
      }
      else
      {
        return true;
      }
    }

    public async Task<ManageUserRolesResult> ManageUserRolesData(UserBase user)
    {
      var response = new ManageUserRolesResult();
      var rolesList = new List<Role>();
      //Roles
      var roles = await _roleManager.Roles.ToListAsync();
      response.UserId = user.Id;
      foreach (var role in roles)
      {
        var userrole = new Role();
        userrole.RoleId = role.Id;
        userrole.RoleName = role.Name;
        if (await _userManager.IsInRoleAsync(user, role.Name))
        {
          userrole.HasRole = true;
        }
        else
        {
          userrole.HasRole = false;
        }
        rolesList.Add(userrole);
      }
      response.Roles = rolesList;
      return response;
    }




    public async Task<string> UpdateUserRoles(UpdateUserRolesRequest request)
    {
      var transact = await _dbContext.Database.BeginTransactionAsync();
      try
      {
        //Get User
        var user = await _userManager.FindByIdAsync(request.UserId);
        if (user == null)
        {
          return "UserIsNull";
        }
        //get user Old Roles
        var userRoles = await _userManager.GetRolesAsync(user);
        //Delete OldRoles
        if (userRoles != null)
        {
          var removeResult = await _userManager.RemoveFromRolesAsync(user, userRoles);

          if (!removeResult.Succeeded)
            return "FailedToRemoveOldRoles";
        }


        var selectedRoles = request.Roles.Where(x => x.HasRole == true).Select(x => x.RoleName);

        //Add the Roles HasRole=True
        var addRolesresult = await _userManager.AddToRolesAsync(user, selectedRoles);
        if (!addRolesresult.Succeeded)
          return "FailedToAddNewRoles";
        await transact.CommitAsync();
        //return Result
        return "Success";
      }
      catch (Exception ex)
      {
        await transact.RollbackAsync();
        return "FailedToUpdateUserRoles";
      }
    }


    public async Task<ManageUserClaimsResult> ManageUserClaimData(UserBase user)
    {
      var response = new ManageUserClaimsResult();
      var usercliamsList = new List<UserClaim>();
      response.UserId = user.Id;
      //Get USer Claims
      var userClaims = await _userManager.GetClaimsAsync(user); //edit
                                                                //create edit get print
                                                                //foreach (var claim in ClaimsStore.claims)
                                                                //{
                                                                //  var userclaim = new UserClaim();
                                                                //  userclaim.Type = claim.Type;
                                                                //  if (userClaims.Any(x => x.Type == claim.Type))
                                                                //  {
                                                                //    userclaim.Value = true;
                                                                //  }
                                                                //  else
                                                                //  {
                                                                //    userclaim.Value = false;
                                                                //  }
                                                                //  usercliamsList.Add(userclaim);
                                                                //}
      response.userClaims = usercliamsList;
      //return Result
      return response;
    }



    public async Task<string> UpdateUserClaims(UpdateUserClaimsRequest request)
    {
      var transact = await _dbContext.Database.BeginTransactionAsync();
      try
      {
        var user = await _userManager.FindByIdAsync(request.UserId.ToString());
        if (user == null)
        {
          return "UserIsNull";
        }
        //remove old Claims
        var userClaims = await _userManager.GetClaimsAsync(user);
        var removeClaimsResult = await _userManager.RemoveClaimsAsync(user, userClaims);
        if (!removeClaimsResult.Succeeded)
          return "FailedToRemoveOldClaims";
        var claims = request.userClaims.Where(x => x.Value == true).Select(x => new Claim(x.Type, x.Value.ToString()));

        var addUserClaimResult = await _userManager.AddClaimsAsync(user, claims);
        if (!addUserClaimResult.Succeeded)
          return "FailedToAddNewClaims";

        await transact.CommitAsync();
        return "Success";
      }
      catch (Exception ex)
      {
        await transact.RollbackAsync();
        return "FailedToUpdateClaims";
      }
    }

    public async Task<string> CreateRoleAsync(AddApplicationRoleRequest request)
    {
      var transact = await _dbContext.Database.BeginTransactionAsync();
      try
      {

        var role = new ApplicationRole()
        {
          Name = request.Name

        };
        await _roleManager.CreateAsync(role);

        foreach (var claim in request.Claims)
        {
          await _roleManager.AddClaimAsync(role,
         new Claim(claim, true.ToString()));

        }


        await transact.CommitAsync();
        return MessageCenter.CrudMessage.Success;
      }
      catch (Exception ex)
      {
        await transact.RollbackAsync();
        return MessageCenter.CrudMessage.Falied + ex.Message;
      }


    }

    public async Task<string> UpdateRoleAsync(EditApplicationRoleRequest request)
    {
      var transact = await _dbContext.Database.BeginTransactionAsync();
      try
      {
        var role = await _roleManager.FindByIdAsync(request.RoleId);

        if (role == null)
        {
          return MessageCenter.CrudMessage.DoesNotExist;
        }
        role.Name = request.Name;


        await _roleManager.UpdateAsync(role);
        var RoleClaims = await _roleManager.GetClaimsAsync(role);
        foreach (var claim in RoleClaims)
        {
          var removeClaimsResult = await _roleManager.RemoveClaimAsync(role, claim);

        }

        foreach (var claim in request.Claims)
        {
          await _roleManager.AddClaimAsync(role,
         new Claim(claim, true.ToString()));

        }


        await transact.CommitAsync();
        return MessageCenter.CrudMessage.Success;
      }
      catch (Exception ex)
      {
        await transact.RollbackAsync();
        return MessageCenter.CrudMessage.Falied + ex.Message;
      }


    }

    public async Task<GetActiveModelsClamisRequest> GetActiveModelsClamisAsync()
    {
      var respons = new GetActiveModelsClamisRequest();

      var modulsIds = (await _companyModuleService.GetActiveModulesListAsync()).Select(x => x.ModuleID);

      foreach (var Mid in modulsIds)
      {
        var model = await _moduleService.GetModuleByIdAsync(Mid);

        respons.ActiveModelsClamis.Add(new ActiveModelClamis()
        {
          name = model.ModuleName,
          clamis = model.ClaimList
        });
      }

      return respons;
    }
  }
}
