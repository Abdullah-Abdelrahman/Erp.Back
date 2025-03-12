using AutoMapper;
using Erp.Data.Entities.HumanResources.Staff;
using Erp.Data.MetaData;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Name.Core.Bases;
using Name.Core.Features.Authorization.Commands.Models;
using Name.Service.Abstracts;
namespace Name.Core.Features.Authorization.Commands.Handlers
{
  public class RoleCommandHandler : ResponseHandler,
         IRequestHandler<AddRoleCommand, Response<string>>,
        IRequestHandler<EditRoleCommand, Response<string>>,
        IRequestHandler<DeleteRoleCommand, Response<string>>,
        IRequestHandler<UpdateUserRolesCommand, Response<string>>

  {
    private readonly IMapper _mapper;
    private readonly RoleManager<ApplicationRole> _roleManager;

    private readonly IAuthorizationService _authorizationService;
    #region ctor
    public RoleCommandHandler(IMapper mapper,
        RoleManager<ApplicationRole> roleManager,
        IAuthorizationService authorizationService)
    {
      _roleManager = roleManager;
      _mapper = mapper;
      _authorizationService = authorizationService;
    }
    #endregion







    public async Task<Response<string>> Handle(AddRoleCommand request, CancellationToken cancellationToken)
    {
      var result = await _authorizationService.CreateRoleAsync(request);


      if (result == MessageCenter.CrudMessage.Success)
      {
        return Created<string>($"{request.Name} : Role Created Successfuly");
      }
      else
      {
        return BadRequest<string>("Somthing Bad happened");
      }
    }

    public async Task<Response<string>> Handle(EditRoleCommand request, CancellationToken cancellationToken)
    {
      var result = await _authorizationService.UpdateRoleAsync(request);

      if (result == MessageCenter.CrudMessage.DoesNotExist)
      {
        return NotFound<string>($"there is no role with id ={request.RoleId}");
      }
      else if (result == MessageCenter.CrudMessage.Success)
      {



        return Success<string>("Updated Successfuly");


      }
      else
      {
        return BadRequest<string>("Somthing Bad happened" + result);
      }
    }

    public async Task<Response<string>> Handle(DeleteRoleCommand request, CancellationToken cancellationToken)
    {
      var role = await _roleManager.FindByIdAsync(request.RoleId);

      if (role == null)
      {
        return NotFound<string>($"there is no role with id ={request.RoleId}");
      }
      else
      {
        var result = await _authorizationService.DeleteRoleAsync(role);

        if (result == MessageCenter.CrudMessage.Success)
        {
          return Success<string>("Deleted Successfuly");
        }
        else if (result == "Failed")
        {
          return BadRequest<string>("Somthing Bad happened");
        }
        else
        {
          return BadRequest<string>();

        }


      }

    }

    public async Task<Response<string>> Handle(UpdateUserRolesCommand request, CancellationToken cancellationToken)
    {
      var result = await _authorizationService.UpdateUserRoles(request);

      switch (result)
      {
        case "UserIsNull": return NotFound<string>("UserIsNull");
        case "FailedToRemoveOldRoles": return BadRequest<string>("FailedToRemoveOldRoles");
        case "FailedToAddNewRoles": return BadRequest<string>("FailedToAddNewRoles");
        case "FailedToUpdateUserRoles": return BadRequest<string>("FailedToUpdateUserRoles");
      }
      return Success<string>("Success");
    }
  }
}
