
using Name.Core.Bases;
using MediatR;

namespace Name.Core.Features.Authentication.Queries.Models
{
    public class ConfirmEmailQuery : IRequest<Response<string>>
    {
        public string userId { get; set; }

        public string code { get; set; }
    }
}
