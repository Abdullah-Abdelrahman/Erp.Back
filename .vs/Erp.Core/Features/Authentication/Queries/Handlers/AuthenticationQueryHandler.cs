using Name.Core.Bases;
using Name.Core.Features.Authentication.Queries.Models;
using Name.Service.Abstracts;
using MediatR;

namespace Name.Core.Features.Authentication.Queries.Handlers
{
    public class AuthenticationQueryHandler : ResponseHandler,
         IRequestHandler<ConfirmEmailQuery, Response<string>>,
         IRequestHandler<CanResetPasswordQuery, Response<string>>

    {

        private readonly IAuthenticationService _authenticationService;

        public AuthenticationQueryHandler(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }
        public async Task<Response<string>> Handle(ConfirmEmailQuery request, CancellationToken cancellationToken)
        {
            var result = await _authenticationService.ConfirmEmail(request.userId, request.code);
            if (result == "Success")
            {
                return Success<string>(result);
            }
            return BadRequest<string>(result);
        }

        public async Task<Response<string>> Handle(CanResetPasswordQuery request, CancellationToken cancellationToken)
        {
            var result = await _authenticationService.ResetPassword(request.Email, request.code);

            if (result == "Success")
            {
                return Success<string>(result);
            }
            else
            {
                return BadRequest<string>(result);
            }
        }
    }
}
