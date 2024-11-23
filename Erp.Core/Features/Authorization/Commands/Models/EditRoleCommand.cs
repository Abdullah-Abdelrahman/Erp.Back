using Name.Core.Bases;
using MediatR;

namespace Name.Core.Features.Authorization.Commands.Models
{
    public class EditRoleCommand : IRequest<Response<string>>
    {
        public string RoleId { get; set; }

        public string RoleName { get; set; }

    }
}
