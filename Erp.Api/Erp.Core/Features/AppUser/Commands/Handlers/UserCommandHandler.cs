using AutoMapper;
using Erp.Data.MetaData;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Name.Core.Bases;
using Name.Core.Features.UserBase.Commands.Models;
using Name.Service.Abstracts;
using US = Name.Data.Entities;



namespace Name.Core.Features.UserBase.Commands.Handlers
{



  public class UserCommandHandler : ResponseHandler,
         IRequestHandler<AddUserCommand, Response<string>>,
         IRequestHandler<EditUserCommand, Response<string>>,
        IRequestHandler<DeleteUserCommand, Response<string>>,
        IRequestHandler<ChangeUserPasswordCommand, Response<string>>

  {

    private readonly IMapper _mapper;
    private readonly IUserBaseService _UserBaseService;

    private readonly UserManager<US.UserBase> _userManager;

    public UserCommandHandler(IMapper mapper, IUserBaseService UserBaseService, UserManager<US.UserBase> userManager)
    {
      _UserBaseService = UserBaseService;
      _userManager = userManager;
      _mapper = mapper;
    }

    public async Task<Response<string>> Handle(AddUserCommand request, CancellationToken cancellationToken)
    {

      var user = _mapper.Map<AddUserCommand, US.UserBase>(request);

      var result = await _UserBaseService.AddUserAsync(user, request.Password);

      switch (result)
      {
        case "Success": return Success<string>(result);
        case "EmailAlredyExist": return BadRequest<string>(result);
        case "UserNameAlredyExist": return BadRequest<string>(result);
        case "UserCreatedSuccessfullyButNotAddedTo[user]Role": return BadRequest<string>(result);

      }

      return BadRequest<string>(result);
    }

    public async Task<Response<string>> Handle(EditUserCommand request, CancellationToken cancellationToken)
    {
      var user = await _userManager.FindByIdAsync(request.UserId);

      if (user == null)
      {
        return NotFound<string>($"ther is no user with id ={request.UserId}");
      }
      else
      {
        var userMapper = _mapper.Map(request, user);

        var NewuserNameExtist = _userManager.Users.Any(u => u.UserName == user.UserName && u.Id != user.Id);
        if (NewuserNameExtist)
        {
          return BadRequest<string>("there is a user with the same UserName");

        }
        var NewEmailExtist = _userManager.Users.Any(u => u.Email == user.Email && u.Id != user.Id);
        if (NewEmailExtist)
        {
          return BadRequest<string>("there is a user with the same Email");

        }
        var result = await _userManager.UpdateAsync(userMapper);

        if (result == IdentityResult.Success)
        {
          return Success<string>("Success");
        }
        else
        {
          return BadRequest<string>("Somthing bad happend");
        }
      }
    }

    public async Task<Response<string>> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
    {
      var courseInDB = await _userManager.FindByIdAsync(request.UserId);


      if (courseInDB == null)
      {
        return NotFound<string>($"There is no user with  id ={request.UserId}");
      }
      else
      {

        var result = await _userManager.DeleteAsync(courseInDB);

        if (result == IdentityResult.Success)
        {
          return Deleted<string>();
        }
        else
        {
          return BadRequest<string>("Error Equired");
        }



      }
    }

    public async Task<Response<string>> Handle(ChangeUserPasswordCommand request, CancellationToken cancellationToken)
    {


      var result = await _UserBaseService.ChangePasswordAsync(request.Email, request.NewPassword);


      if (result == "UserNotFound")
      {
        return NotFound<string>($"there is no user with Email ={request.Email}");
      }
      else if (result == MessageCenter.CrudMessage.Success)
      {
        return Success<string>("Password Updateted successfuly");

      }
      return BadRequest<string>("Somthing bad happend");


    }
  }
}
