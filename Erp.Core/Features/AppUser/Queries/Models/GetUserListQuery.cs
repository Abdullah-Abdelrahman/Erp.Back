using Name.Core.Bases;
using Name.Core.Features.UserBase.Queries.Results;
using MediatR;

namespace Name.Core.Features.UserBase.Queries.Models
{
    public class GetUserListQuery : IRequest<Response<List<GetUserListResponse>>>
    {

    }
}
