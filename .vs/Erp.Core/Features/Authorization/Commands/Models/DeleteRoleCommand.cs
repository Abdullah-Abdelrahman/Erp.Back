using Name.Core.Bases;
using MediatR;

namespace Name.Core.Features.Authorization.Commands.Models
{
    public class DeleteRoleCommand : IRequest<Response<string>>
    {

        public string RoleId { get; set; }
        public DeleteRoleCommand(string id)
        {
            RoleId = id;
        }
    }
}
