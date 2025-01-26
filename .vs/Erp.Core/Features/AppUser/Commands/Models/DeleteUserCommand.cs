using Name.Core.Bases;
using MediatR;

namespace Name.Core.Features.UserBase.Commands.Models
{
    public class DeleteUserCommand : IRequest<Response<string>>
    {
        public string UserId { get; set; }

        public DeleteUserCommand(string id)
        {
            UserId = id;
        }

    }
}
