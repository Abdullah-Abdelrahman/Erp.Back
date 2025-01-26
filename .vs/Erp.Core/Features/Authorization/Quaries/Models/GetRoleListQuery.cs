using Name.Core.Bases;
using Name.Core.Features.Authorization.Quaries.Results;
using MediatR;

namespace Name.Core.Features.Authorization.Quaries.Models
{
    public class GetRoleListQuery : IRequest<Response<List<GetRoleListResponse>>>
    {
    }
}
