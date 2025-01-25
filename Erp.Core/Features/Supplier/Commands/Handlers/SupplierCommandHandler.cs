using AutoMapper;
using Erp.Core.Features.Supplier.Commands.Models;
using Erp.Data.MetaData;
using Erp.Service.Abstracts;
using MediatR;
using Name.Core.Bases;
using Entitis = Erp.Data.Entities;
namespace Erp.Core.Features.Supplier.Commands.Handlers
{

  public class SupplierCommandHandler : ResponseHandler,
    IRequestHandler<AddSupplierCommand, Response<string>>,
     IRequestHandler<EditSupplierCommand, Response<string>>,
     IRequestHandler<DeleteSupplierCommand, Response<string>>
  {
    private readonly ISupplierService _SupplierService;
    private readonly IMapper _mapper;

    public SupplierCommandHandler(ISupplierService SupplierService, IMapper mapper)
    {
      _SupplierService = SupplierService;
      _mapper = mapper;
    }

    public async Task<Response<string>> Handle(AddSupplierCommand request, CancellationToken cancellationToken)
    {
      var SupplierMapper = _mapper.Map<Entitis.Supplier>(request);
      var result = await _SupplierService.AddSupplierAsync(SupplierMapper);

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

    public async Task<Response<string>> Handle(EditSupplierCommand request, CancellationToken cancellationToken)
    {
      var SupplierMapper = _mapper.Map<Entitis.Supplier>(request);
      var result = await _SupplierService.UpdateAsync(SupplierMapper);

      if (result == MessageCenter.CrudMessage.Success)
      {
        return Created<string>("Updated successfuly");
      }
      else
      {
        return BadRequest<string>("Somthing bad happened");
      }
    }

    public async Task<Response<string>> Handle(DeleteSupplierCommand request, CancellationToken cancellationToken)
    {
      var SupplierInDB = await _SupplierService.GetSupplierByIdAsync(request.Id);


      if (SupplierInDB == null)
      {
        return NotFound<string>("There is no Supplier with this id");
      }
      else
      {

        var result = await _SupplierService.DeleteAsync(SupplierInDB);

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

