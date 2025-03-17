using Microsoft.AspNetCore.Mvc;
using Name.Api.Base;

namespace Erp.Api.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class CustomerPaymentController : AppControllerBase
  {

    public CustomerPaymentController(IWebHostEnvironment webHostEnvironment)
    {
      _webHost = webHostEnvironment;
    }


  }
}
