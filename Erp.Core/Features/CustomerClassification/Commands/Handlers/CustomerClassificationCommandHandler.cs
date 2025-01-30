using AutoMapper;
using Erp.Core.Features.CustomerClassification.Commands.Models;
using Erp.Data.MetaData;
using Erp.Service.Abstracts.CustomersModule;
using MediatR;
using Name.Core.Bases;
using Entitis = Erp.Data.Entities;
namespace Erp.Core.Features.CustomerClassification.Commands.Handlers
{
  public class CustomerClassificationCommandHandler : ResponseHandler,
    IRequestHandler<AddCustomerClassificationCommand, Response<string>>,
    IRequestHandler<EditCustomerClassificationCommand, Response<string>>,
    IRequestHandler<DeleteCustomerClassificationCommand, Response<string>>


  {
    private readonly ICustomerClassificationService _CustomerClassificationService;
    private readonly IMapper _mapper;

    public CustomerClassificationCommandHandler(ICustomerClassificationService CustomerClassificationService, IMapper mapper)
    {
      _CustomerClassificationService = CustomerClassificationService;
      _mapper = mapper;
    }

    public async Task<Response<string>> Handle(AddCustomerClassificationCommand request, CancellationToken cancellationToken)
    {
      var CustomerClassificationMapper = _mapper.Map<Entitis.CustomersModule.CustomerClassification>(request);
      var result = await _CustomerClassificationService.AddCustomerClassificationAsync(CustomerClassificationMapper);

      if (result == MessageCenter.CrudMessage.Exist)
      {
        return UnprocessableEntity<string>("Name Exist Befor");
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

    public async Task<Response<string>> Handle(EditCustomerClassificationCommand request, CancellationToken cancellationToken)
    {
      var CustomerClassificationMapper = _mapper.Map<Entitis.CustomersModule.CustomerClassification>(request);
      var result = await _CustomerClassificationService.UpdateAsync(CustomerClassificationMapper);

      if (result == MessageCenter.CrudMessage.Success)
      {
        return Created<string>("Updated successfuly");
      }
      else
      {
        return BadRequest<string>("Somthing bad happened");
      }
    }

    public async Task<Response<string>> Handle(DeleteCustomerClassificationCommand request, CancellationToken cancellationToken)
    {
      var CustomerClassificationMapper = _mapper.Map<Entitis.CustomersModule.CustomerClassification>(request);
      var result = await _CustomerClassificationService.DeleteAsync(CustomerClassificationMapper);

      if (result == MessageCenter.CrudMessage.Success)
      {
        return Created<string>("Deleted successfuly");
      }
      else
      {
        return BadRequest<string>("Somthing bad happened");
      }
    }
  }
}
