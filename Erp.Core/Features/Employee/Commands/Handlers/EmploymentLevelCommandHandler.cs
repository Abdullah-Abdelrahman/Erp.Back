using AutoMapper;
using Erp.Core.Features.Employee.Commands.Models;
using Erp.Data.MetaData;
using Erp.Service.Abstracts.HumanResources.Staff;
using MediatR;
using Name.Core.Bases;
using Entitis = Erp.Data.Entities;
namespace Erp.Core.Features.Employee.Commands.Handlers
{
  public class EmployeeCommandHandler : ResponseHandler,
    IRequestHandler<AddEmployeeCommand, Response<string>>,
    IRequestHandler<EditEmployeeCommand, Response<string>>,
    IRequestHandler<DeleteEmployeeCommand, Response<string>>


  {
    private readonly IEmployeeService _EmployeeService;
    private readonly IMapper _mapper;

    public EmployeeCommandHandler(IEmployeeService EmployeeService, IMapper mapper)
    {
      _EmployeeService = EmployeeService;
      _mapper = mapper;
    }

    public async Task<Response<string>> Handle(AddEmployeeCommand request, CancellationToken cancellationToken)
    {
      var EmployeeMapper = _mapper.Map<Entitis.HumanResources.Staff.Employee>(request);
      var result = await _EmployeeService.AddEmployeeAsync(EmployeeMapper);

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

    public async Task<Response<string>> Handle(EditEmployeeCommand request, CancellationToken cancellationToken)
    {
      var EmployeeMapper = _mapper.Map<Entitis.HumanResources.Staff.Employee>(request);
      var result = await _EmployeeService.UpdateAsync(EmployeeMapper);

      if (result == MessageCenter.CrudMessage.Success)
      {
        return Created<string>("Updated successfuly");
      }
      else
      {
        return BadRequest<string>("Somthing bad happened");
      }
    }

    public async Task<Response<string>> Handle(DeleteEmployeeCommand request, CancellationToken cancellationToken)
    {
      var Employee = await _EmployeeService.GetEmployeeByIdAsync(request.EmployeeId);
      var result = await _EmployeeService.DeleteAsync(Employee);

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
