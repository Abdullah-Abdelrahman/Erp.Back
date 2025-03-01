using AutoMapper;
using Erp.Core.Features.EmploymentType.Commands.Models;
using Erp.Data.MetaData;
using Erp.Service.Abstracts.HumanResources.OrganizationalStructure;
using MediatR;
using Name.Core.Bases;
using Entitis = Erp.Data.Entities;
namespace Erp.Core.Features.EmploymentType.Commands.Handlers
{
  public class EmploymentTypeCommandHandler : ResponseHandler,
    IRequestHandler<AddEmploymentTypeCommand, Response<string>>,
    IRequestHandler<EditEmploymentTypeCommand, Response<string>>,
    IRequestHandler<DeleteEmploymentTypeCommand, Response<string>>


  {
    private readonly IEmploymentTypeService _EmploymentTypeService;
    private readonly IMapper _mapper;

    public EmploymentTypeCommandHandler(IEmploymentTypeService EmploymentTypeService, IMapper mapper)
    {
      _EmploymentTypeService = EmploymentTypeService;
      _mapper = mapper;
    }

    public async Task<Response<string>> Handle(AddEmploymentTypeCommand request, CancellationToken cancellationToken)
    {
      var EmploymentTypeMapper = _mapper.Map<Entitis.HumanResources.OrganizationalStructure.EmploymentType>(request);
      var result = await _EmploymentTypeService.AddEmploymentTypeAsync(EmploymentTypeMapper);

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

    public async Task<Response<string>> Handle(EditEmploymentTypeCommand request, CancellationToken cancellationToken)
    {
      var EmploymentTypeMapper = _mapper.Map<Entitis.HumanResources.OrganizationalStructure.EmploymentType>(request);
      var result = await _EmploymentTypeService.UpdateAsync(EmploymentTypeMapper);

      if (result == MessageCenter.CrudMessage.Success)
      {
        return Created<string>("Updated successfuly");
      }
      else
      {
        return BadRequest<string>("Somthing bad happened");
      }
    }

    public async Task<Response<string>> Handle(DeleteEmploymentTypeCommand request, CancellationToken cancellationToken)
    {
      var EmploymentType = await _EmploymentTypeService.GetEmploymentTypeByIdAsync(request.EmploymentTypeId);
      var result = await _EmploymentTypeService.DeleteAsync(EmploymentType);

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
