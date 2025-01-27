using Name.Core.Bases;
using MediatR;

namespace Name.Core.Features.UserBase.Commands.Models
{
    public class EditUserCommand : IRequest<Response<string>>
    {
        public string UserId { get; set; }
        public string? Name { get; set; }

        public string? PhoneNumber { get; set; }
        public string? UserName { get; set; }

        public string? Email { get; set; }
    }
}
