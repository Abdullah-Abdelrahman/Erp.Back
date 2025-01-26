using Name.Core.Bases;
using MediatR;

namespace Name.Core.Features.Authentication.Queries.Models
{
    public class CanResetPasswordQuery : IRequest<Response<string>>
    {
        public string code { get; set; }

        public string Email { get; set; }

    }
}
