using MediatR;
using Microsoft.AspNetCore.Identity;
using Name.Core.Bases;
using Name.Core.Features.Authorization.Quaries.Models;
using Name.Data.Dto;
using Name.Service.Abstracts;


namespace Name.Core.Features.Authorization.Quaries.Handlers
{
  public class ClaimsQueryHandler : ResponseHandler,
        IRequestHandler<ManageUserClaimsQuery, Response<ManageUserClaimsResult>>
  {

    #region Fileds
    private readonly IAuthorizationService _authorizationService;
    private readonly UserManager<Erp.Data.Entities.MainModule.UserBase> _userManager;
    #endregion

    public ClaimsQueryHandler(IAuthorizationService authorizationService, UserManager<Erp.Data.Entities.MainModule.UserBase> userManager)
    {
      _authorizationService = authorizationService;
      _userManager = userManager;
    }


    public async Task<Response<ManageUserClaimsResult>> Handle(ManageUserClaimsQuery request, CancellationToken cancellationToken)
    {
      var user = await _userManager.FindByIdAsync(request.UserId.ToString());
      if (user == null) return NotFound<ManageUserClaimsResult>();
      var result = await _authorizationService.ManageUserClaimData(user);
      return Success(result);
    }


  }
}
