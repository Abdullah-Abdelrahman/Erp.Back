using Name.Core.Bases;
using Name.Data.Dto;
using MediatR;

namespace Name.Core.Features.Authorization.Commands.Models
{
    public class UpdateUserClaimsCommand : UpdateUserClaimsRequest, IRequest<Response<string>>
    {
    }
}
