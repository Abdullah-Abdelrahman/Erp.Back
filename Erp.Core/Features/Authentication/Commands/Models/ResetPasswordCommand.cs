using Name.Core.Bases;
using MediatR;

namespace Name.Core.Features.Authentication.Commands.Models
{
    public class ResetPasswordCommand : IRequest<Response<string>>
    {

        public string Email { get; set; }
    }
}
