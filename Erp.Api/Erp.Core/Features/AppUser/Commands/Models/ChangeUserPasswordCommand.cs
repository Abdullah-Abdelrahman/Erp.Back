using Name.Core.Bases;
using MediatR;

namespace Name.Core.Features.UserBase.Commands.Models
{
    public class ChangeUserPasswordCommand : IRequest<Response<string>>
    {

        public string Email { get; set; }

        public string NewPassword { get; set; }

        public string NewConfirmPassword { get; set; }




    }
}
