using AutoMapper;
using Erp.Core.Features.Employee.Queries.Models;
using Erp.Core.Features.Employee.Queries.Results;
using Erp.Service.Abstracts.HumanResources.Staff;
using MediatR;
using Name.Core.Bases;

namespace Erp.Core.Features.Employee.Queries.Handlers
{
  public class EmployeeQueryHandler : ResponseHandler, IRequestHandler<GetEmployeeByIdQuery, Response<GetEmployeeByIdResult>>, IRequestHandler<GetEmployeeListQuery, Response<List<GetEmployeeByIdResult>>>
  {
    #region Fields
    private readonly IEmployeeService _EmployeeService;
    private readonly IMapper _mapper;
    #endregion
    public EmployeeQueryHandler(IEmployeeService EmployeeService, IMapper mapper)
    {
      _mapper = mapper;
      _EmployeeService = EmployeeService;
    }

    public async Task<Response<GetEmployeeByIdResult>> Handle(GetEmployeeByIdQuery request, CancellationToken cancellationToken)
    {
      var Employee = await _EmployeeService.GetEmployeeByIdAsync(request.Id);


      if (Employee == null)
      {
        return NotFound<GetEmployeeByIdResult>("Employee Not Found");
      }
      else
      {
        var EmployeeMapper = _mapper.Map<GetEmployeeByIdResult>(Employee);
        return Success(EmployeeMapper);
      }
    }

    public async Task<Response<List<GetEmployeeByIdResult>>> Handle(GetEmployeeListQuery request, CancellationToken cancellationToken)
    {
      var EmployeeList = await _EmployeeService.GetEmployeesListAsync();

      var EmployeeListMapper = _mapper.Map<List<GetEmployeeByIdResult>>(EmployeeList);

      return Success(EmployeeListMapper);
    }
  }
}
