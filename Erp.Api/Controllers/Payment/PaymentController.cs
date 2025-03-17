using Erp.Core.Features.Payment.Queries.Models;
using Microsoft.AspNetCore.Mvc;
using Name.Api.Base;
using Name.Data.MetaData;

namespace Erp.Api.Controllers.Payment
{
  [Route("api/[controller]")]
  [ApiController]
  public class PaymentController : AppControllerBase
  {


    [HttpGet(Router.PaymentRouter.SupplierPaymentList)]
    public async Task<IActionResult> GetSupplierPaymentsList()
    {
      var response = await Mediator.Send(new GetSupplierPaymentListQuery());

      return Ok(response);
    }

    //[HttpGet(Router.PaymentRouter.GetSecondaryPaymentsList)]
    //public async Task<IActionResult> GetSecondaryPaymentsList()
    //{
    //  var response = await Mediator.Send(new GetSecondaryPaymentsListQuery());

    //  return Ok(response);
    //}


    //[HttpGet(Router.PaymentRouter.GetPaymentTypeById)]
    //public async Task<IActionResult> GetPaymentTypeById(int Id)
    //{
    //  var response = await Mediator.Send(new GetPaymentTypeByIdQuery(Id));

    //  return NewResult(response);
    //}

    [HttpGet(Router.PaymentRouter.GetSupplierPaymentById)]
    public async Task<IActionResult> GetSupplierPaymentByIdQuery(int Id)
    {
      var response = await Mediator.Send(new GetSupplierPaymentByIdQuery(Id));

      return Ok(response);
    }


    //[HttpGet(Router.PaymentRouter.GetPrimaryPaymentById)]
    //public async Task<IActionResult> GetPrimaryPaymentById(int Id)
    //{
    //  var response = await Mediator.Send(new GetPrimaryPaymentByIdQuery(Id));

    //  return NewResult(response);
    //}


  }
}
