using Name.Core.Bases;
using Name.Data.Dto;
using MediatR;

namespace Name.Core.Features.Authorization.Quaries.Models
{
    public class ManageUserRolesQuery : IRequest<Response<ManageUserRolesResult>>
    {
        public string UserId { get; set; }

        public ManageUserRolesQuery(string id)
        {
            UserId = id;
        }
    }
}
