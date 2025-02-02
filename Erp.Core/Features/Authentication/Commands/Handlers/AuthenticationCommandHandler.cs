using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Name.Core.Bases;
using Name.Core.Features.Authentication.Commands.Models;
using Au = Name.Service.Abstracts;
namespace Name.Core.Features.Authentication.Commands.Handlers
{
  public class AuthenticationCommandHandler : ResponseHandler,
         IRequestHandler<SignInCommand, Response<string>>,
         IRequestHandler<ResetPasswordCommand, Response<string>>

  {


    private readonly IMapper _mapper;
    private readonly UserManager<Erp.Data.Entities.MainModule.UserBase> _userManager;
    private readonly SignInManager<Erp.Data.Entities.MainModule.UserBase> _signInManager;
    private readonly Au.IAuthenticationService _authenticationService;
    public AuthenticationCommandHandler(IMapper mapper,
        UserManager<Erp.Data.Entities.MainModule.UserBase> userManager,
        SignInManager<Erp.Data.Entities.MainModule.UserBase> signInManager,
        Au.IAuthenticationService authenticationService)
    {
      _userManager = userManager;
      _mapper = mapper;
      _signInManager = signInManager;
      _authenticationService = authenticationService;
    }
    public async Task<Response<string>> Handle(SignInCommand request, CancellationToken cancellationToken)
    {
      var user = await _userManager.FindByEmailAsync(request.Email);

      if (user == null)
      {
        return BadRequest<string>("There is no user with this email");
      }
      else
      {
        var result = await _userManager.CheckPasswordAsync(user, request.Password);



        if (result == false)
        {
          return BadRequest<string>("password and Email MissMatch");
        }
        else
        {
          if (user.EmailConfirmed == false)
          {
            return BadRequest<string>("Account is Not Confirmed");

          }

          //Login
          await _signInManager.SignInAsync(user, false);
          // biuld token



          //return the token
          return Success<string>(await _authenticationService.GetJWTtoken(user));
        }

      }


    }

    public async Task<Response<string>> Handle(ResetPasswordCommand request, CancellationToken cancellationToken)
    {
      var result = await _authenticationService.SendResetPassword(request.Email);

      switch (result)
      {
        case "Success": return Success<string>(result);
        case "UserNotFound": return NotFound<string>(result);
        case "ErrorInUpdateUserCode": return BadRequest<string>(result);


      }

      return BadRequest<string>(result);
    }
  }
}
