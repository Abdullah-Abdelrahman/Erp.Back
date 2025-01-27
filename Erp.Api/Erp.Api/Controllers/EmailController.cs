using Name.Api.Base;
using Name.Core.Features.Email.Commands.Models;
using Name.Data.MetaData;
using Microsoft.AspNetCore.Mvc;

namespace Name.Api.Controllers
{

    [ApiController]
    public class EmailController : AppControllerBase
    {

        [HttpPost(Router.EmailRouter.Send)]
        public async Task<IActionResult> SendEmail([FromQuery] SendEmailCommand command)
        {
            var response = await Mediator.Send(command);

            return NewResult(response);
        }

    }
}
