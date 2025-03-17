using Erp.Data.Entities.MainModule;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Name.Infrastructure.Data;
using Name.Service.Abstracts;

namespace Name.Service.Implementations
{
  public class UserBaseService : IUserBaseService
  {
    private readonly UserManager<UserBase> _userManager;
    private readonly IEmailService _emailService;

    private readonly ApplicationDBContext _dbContext;
    //Used to get the host and schema(http or https)
    private readonly IHttpContextAccessor _contextAccessor;


    public UserBaseService(UserManager<UserBase> userManager,
        IHttpContextAccessor httpContextAccessor,
        IEmailService emailService,
        ApplicationDBContext applicationDBContext)
    {
      _contextAccessor = httpContextAccessor;
      _dbContext = applicationDBContext;
      _userManager = userManager;
      _emailService = emailService;
    }
    public async Task<string> AddUserAsync(UserBase UserBase, string password)
    {

      var transact = _dbContext.Database.BeginTransaction();
      try
      {
        //if email Exist before

        var Emailresult = await _userManager.FindByEmailAsync(UserBase.Email);

        if (Emailresult == null)
        {
          var UserNameresult = await _userManager.FindByNameAsync(UserBase.UserName);

          if (UserNameresult == null)
          {

            //remove this line in publish
            UserBase.EmailConfirmed = true;
            var result = await _userManager.CreateAsync(UserBase, password);

            if (result == IdentityResult.Success)
            {
              //var addRoleResult = await _userManager.AddToRoleAsync(UserBase, "User");



              //if (addRoleResult == IdentityResult.Success)
              //{
              //send Confirm Email
              var code = await _userManager.GenerateEmailConfirmationTokenAsync(UserBase);
              var encodedCode = Uri.EscapeDataString(code);
              var requestAccessor = _contextAccessor.HttpContext.Request;
              var returnUrl = requestAccessor.Scheme + "://" + requestAccessor.Host + $"/Api/Authentication/ConfirmEmail?userId={UserBase.Id}&code={encodedCode}";
              //send the confirmation email

              var message = $"To confirm Your Email Click the link <a href='{returnUrl}'>Go</a>";
              await _emailService.SendEmailAsync(UserBase.Email, message, "Confirm Email");


              await transact.CommitAsync();
              return "Success";

              //}
              //else
              //{
              //  return "UserCreatedSuccessfullyButNotAddedTo[user]Role";
              //}
            }
            else
            {
              return string.Join(",", result.Errors.Select(x => x.Description).ToList());
            }

          }
          else
          {
            return "UserNameAlredyExist";
          }
        }
        else
        {
          return "EmailAlredyExist";
        }



        await transact.CommitAsync();
        return "Success";

      }
      catch (Exception ex)
      {
        await transact.RollbackAsync();
        return "Falied :" + ex.Message;
      }


    }

    public async Task<string> ChangePasswordAsync(string Email, string password)
    {
      var transact = _dbContext.Database.BeginTransaction();
      try
      {
        var user = await _userManager.FindByEmailAsync(Email);

        if (user == null)
        {
          return "UserNotFound";
        }


        await _userManager.RemovePasswordAsync(user);
        await _userManager.AddPasswordAsync(user, password);
        await transact.CommitAsync();
        return "Success";
      }
      catch
      {
        await transact.RollbackAsync();
        return "Falied";
      }

    }
  }
}
