using AutoMapper;
using Erp.Core.Features.Department.Commands.Models;
using Erp.Data.MetaData;
using Erp.Service.Abstracts.HumanResources.OrganizationalStructure;
using MediatR;
using Name.Core.Bases;
using Entitis = Erp.Data.Entities;
namespace Erp.Core.Features.Department.Commands.Handlers
{
  public class DepartmentCommandHandler : ResponseHandler,
    IRequestHandler<AddDepartmentCommand, Response<string>>,
    IRequestHandler<EditDepartmentCommand, Response<string>>,
    IRequestHandler<DeleteDepartmentCommand, Response<string>>


  {
    private readonly IDepartmentService _DepartmentService;
    private readonly IMapper _mapper;

    public DepartmentCommandHandler(IDepartmentService DepartmentService, IMapper mapper)
    {
      _DepartmentService = DepartmentService;
      _mapper = mapper;
    }

    public async Task<Response<string>> Handle(AddDepartmentCommand request, CancellationToken cancellationToken)
    {
      var DepartmentMapper = _mapper.Map<Entitis.HumanResources.OrganizationalStructure.Department>(request);
      var result = await _DepartmentService.AddDepartmentAsync(DepartmentMapper);

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

    public async Task<Response<string>> Handle(EditDepartmentCommand request, CancellationToken cancellationToken)
    {
      var DepartmentMapper = _mapper.Map<Entitis.HumanResources.OrganizationalStructure.Department>(request);
      var result = await _DepartmentService.UpdateAsync(DepartmentMapper);

      if (result == MessageCenter.CrudMessage.Success)
      {
        return Created<string>("Updated successfuly");
      }
      else
      {
        return BadRequest<string>("Somthing bad happened");
      }
    }

    public async Task<Response<string>> Handle(DeleteDepartmentCommand request, CancellationToken cancellationToken)
    {
      var Department = await _DepartmentService.GetDepartmentByIdAsync(request.DepartmentId);
      var result = await _DepartmentService.DeleteAsync(Department);

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
