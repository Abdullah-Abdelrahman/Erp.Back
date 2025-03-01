using Microsoft.AspNetCore.Mvc;
using Name.Api.Base;
using Name.Core.Features.Email.Commands.Models;
using Name.Data.MetaData;

namespace Name.Api.Controllers
{
  [Route("api/[controller]")]
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
