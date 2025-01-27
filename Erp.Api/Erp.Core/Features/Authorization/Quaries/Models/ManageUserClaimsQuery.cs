using Name.Core.Bases;
using Name.Data.Dto;
using MediatR;

namespace Name.Core.Features.Authorization.Quaries.Models
{
    public class ManageUserClaimsQuery : IRequest<Response<ManageUserClaimsResult>>
    {

        public string UserId { get; set; }

        public ManageUserClaimsQuery(string id)
        {
            UserId = id;
        }
    }
}
