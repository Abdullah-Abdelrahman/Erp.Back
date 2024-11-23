using Name.Core.Bases;
using Name.Core.Features.UserBase.Queries.Results;
using MediatR;

namespace Name.Core.Features.UserBase.Queries.Models
{
    public class GetUserByIdQuery : IRequest<Response<GetUserByIdResponse>>
    {

        public string Id { get; set; }

        public GetUserByIdQuery(string id)
        {
            Id = id;
        }
    }
}
