using AutoMapper;
using Erp.Core.Features.Department.Queries.Models;
using Erp.Core.Features.Department.Queries.Results;
using Erp.Service.Abstracts.HumanResources.OrganizationalStructure;
using MediatR;
using Name.Core.Bases;

namespace Erp.Core.Features.Department.Queries.Handlers
{
  public class DepartmentQueryHandler : ResponseHandler, IRequestHandler<GetDepartmentByIdQuery, Response<GetDepartmentByIdResult>>, IRequestHandler<GetDepartmentListQuery, Response<List<GetDepartmentByIdResult>>>
  {
    #region Fields
    private readonly IDepartmentService _DepartmentService;
    private readonly IMapper _mapper;
    #endregion
    public DepartmentQueryHandler(IDepartmentService DepartmentService, IMapper mapper)
    {
      _mapper = mapper;
      _DepartmentService = DepartmentService;
    }

    public async Task<Response<GetDepartmentByIdResult>> Handle(GetDepartmentByIdQuery request, CancellationToken cancellationToken)
    {
      var Department = await _DepartmentService.GetDepartmentByIdAsync(request.Id);


      if (Department == null)
      {
        return NotFound<GetDepartmentByIdResult>("Department Not Found");
      }
      else
      {
        var DepartmentMapper = _mapper.Map<GetDepartmentByIdResult>(Department);
        return Success(DepartmentMapper);
      }
    }

    public async Task<Response<List<GetDepartmentByIdResult>>> Handle(GetDepartmentListQuery request, CancellationToken cancellationToken)
    {
      var DepartmentList = await _DepartmentService.GetDepartmentsListAsync();

      var DepartmentListMapper = _mapper.Map<List<GetDepartmentByIdResult>>(DepartmentList);

      return Success(DepartmentListMapper);
    }
  }
}
