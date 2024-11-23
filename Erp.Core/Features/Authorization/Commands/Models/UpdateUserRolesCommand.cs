using Name.Core.Bases;
using Name.Data.Dto;
using MediatR;

namespace Name.Core.Features.Authorization.Commands.Models
{
    public class UpdateUserRolesCommand : UpdateUserRolesRequest,
        IRequest<Response<string>>
    {
    }
}
