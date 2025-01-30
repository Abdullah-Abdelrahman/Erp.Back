using AutoMapper;
using Erp.Core.Features.Customer.Commands.Models;
using Erp.Data.MetaData;
using Erp.Service.Abstracts.CustomersModule;
using MediatR;
using Name.Core.Bases;
namespace Erp.Core.Features.Customer.Commands.Handlers
{

  public class CustomerCommandHandler : ResponseHandler,
    IRequestHandler<AddCustomerCommand, Response<string>>,
     IRequestHandler<EditCustomerCommand, Response<string>>,
     IRequestHandler<DeleteCustomerCommand, Response<string>>
  {
    private readonly ICustomerService _CustomerService;
    private readonly IMapper _mapper;

    public CustomerCommandHandler(ICustomerService CustomerService, IMapper mapper)
    {
      _CustomerService = CustomerService;
      _mapper = mapper;
    }

    public async Task<Response<string>> Handle(AddCustomerCommand request, CancellationToken cancellationToken)
    {



      var result = await _CustomerService.AddCustomerAsync(request);

      if (result == MessageCenter.CrudMessage.Exist)
      {
        return UnprocessableEntity<string>("Exist Befor");
      }
      else if (result == MessageCenter.CrudMessage.Success)
      {
        return Created<string>("Added successfuly");
      }
      else
      {
        return BadRequest<string>("Somthing bad happened");
      }
    }

    public async Task<Response<string>> Handle(EditCustomerCommand request, CancellationToken cancellationToken)
    {

      var result = await _CustomerService.UpdateCustomerAsync(request);

      if (result == MessageCenter.CrudMessage.Success)
      {
        return Created<string>("Updated successfuly");
      }
      else
      {
        return BadRequest<string>("Somthing bad happened");
      }
    }

    public async Task<Response<string>> Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
    {
      var CustomerInDB = await _CustomerService.GetCustomerByIdAsync(request.Id);


      if (CustomerInDB == null)
      {
        return NotFound<string>("There is no Customer with this id");
      }
      else
      {

        var result = await _CustomerService.DeleteCustomerAsync(CustomerInDB.CustomerId);

        if (result == MessageCenter.CrudMessage.Success)
        {
          return Deleted<string>();
        }
        else
        {
          return BadRequest<string>(MessageCenter.CrudMessage.Falied);
        }



      }
    }
  }
}

