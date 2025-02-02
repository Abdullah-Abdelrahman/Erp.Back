using AutoMapper;
using Erp.Core.Features.CustomerPayment.Commands.Models;
using Erp.Data.MetaData;
using Erp.Service.Abstracts.SalesModule;
using MediatR;
using Name.Core.Bases;
using Entitis = Erp.Data.Entities;
namespace Erp.Core.Features.CustomerPayment.Commands.Handlers
{

  public class CustomerPaymentCommandHandler : ResponseHandler,
    IRequestHandler<AddCustomerPaymentCommand, Response<string>>,
     IRequestHandler<EditCustomerPaymentCommand, Response<string>>,
     IRequestHandler<DeleteCustomerPaymentCommand, Response<string>>
  {
    private readonly ICustomerPaymentService _CustomerPaymentService;
    private readonly IMapper _mapper;

    public CustomerPaymentCommandHandler(ICustomerPaymentService CustomerPaymentService, IMapper mapper)
    {
      _CustomerPaymentService = CustomerPaymentService;
      _mapper = mapper;
    }

    public async Task<Response<string>> Handle(AddCustomerPaymentCommand request, CancellationToken cancellationToken)
    {
      var CustomerPaymentMapper = _mapper.Map<Entitis.SalesModule.CustomerPayment>(request);
      var result = await _CustomerPaymentService.AddCustomerPaymentAsync(CustomerPaymentMapper);

      if (result == MessageCenter.CrudMessage.Success)
      {
        return Created<string>("Added successfuly");
      }
      else
      {
        return BadRequest<string>("Somthing bad happened");
      }
    }

    public async Task<Response<string>> Handle(EditCustomerPaymentCommand request, CancellationToken cancellationToken)
    {
      var CustomerPaymentMapper = _mapper.Map<Entitis.SalesModule.CustomerPayment>(request);
      var result = await _CustomerPaymentService.UpdateAsync(CustomerPaymentMapper);

      if (result == MessageCenter.CrudMessage.Success)
      {
        return Created<string>("Updated successfuly");
      }
      else
      {
        return BadRequest<string>("Somthing bad happened");
      }
    }

    public async Task<Response<string>> Handle(DeleteCustomerPaymentCommand request, CancellationToken cancellationToken)
    {
      var CustomerPaymentInDB = await _CustomerPaymentService.GetCustomerPaymentByIdAsync(request.Id);


      if (CustomerPaymentInDB == null)
      {
        return NotFound<string>("There is no CustomerPayment with this id");
      }
      else
      {

        var result = await _CustomerPaymentService.DeleteAsync(CustomerPaymentInDB);

        if (result == MessageCenter.CrudMessage.Success)
        {
          return Deleted<string>();
        }
        else
        {
          return BadRequest<string>("Somthing bad happened");
        }



      }
    }
  }
}

