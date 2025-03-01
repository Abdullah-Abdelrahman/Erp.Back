using Erp.Data.Entities.HumanResources.Staff;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Name.Core.Bases;
using Name.Core.Features.Authorization.Commands.Models;
using Name.Service.Abstracts;

namespace Name.Core.Features.Authorization.Commands.Handlers
{
  internal class ClaimsCommandHandler : ResponseHandler,
         IRequestHandler<UpdateUserClaimsCommand, Response<string>>
  {

    private readonly RoleManager<ApplicationRole> _roleManager;

    private readonly IAuthorizationService _authorizationService;
    #region ctor
    public ClaimsCommandHandler(
        RoleManager<ApplicationRole> roleManager,
        IAuthorizationService authorizationService)
    {
      _roleManager = roleManager;
      _authorizationService = authorizationService;
    }

    public async Task<Response<string>> Handle(UpdateUserClaimsCommand request, CancellationToken cancellationToken)
    {
      var result = await _authorizationService.UpdateUserClaims(request);
      switch (result)
      {
        case "UserIsNull": return NotFound<string>("User NOT FOUND");
        case "FailedToRemoveOldClaims": return BadRequest<string>("FailedToRemoveOldClaims");
        case "FailedToAddNewClaims": return BadRequest<string>("FailedToAddNewClaims");
        case "FailedToUpdateClaims": return BadRequest<string>("FailedToUpdateClaims");
      }
      return Success<string>("Success");
    }
    #endregion

  }
}
