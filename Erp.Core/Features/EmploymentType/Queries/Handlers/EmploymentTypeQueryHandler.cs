using AutoMapper;
using Erp.Core.Features.EmploymentType.Queries.Models;
using Erp.Core.Features.EmploymentType.Queries.Results;
using Erp.Service.Abstracts.HumanResources.OrganizationalStructure;
using MediatR;
using Name.Core.Bases;

namespace Erp.Core.Features.EmploymentType.Queries.Handlers
{
  public class EmploymentTypeQueryHandler : ResponseHandler, IRequestHandler<GetEmploymentTypeByIdQuery, Response<GetEmploymentTypeByIdResult>>, IRequestHandler<GetEmploymentTypeListQuery, Response<List<GetEmploymentTypeByIdResult>>>
  {
    #region Fields
    private readonly IEmploymentTypeService _EmploymentTypeService;
    private readonly IMapper _mapper;
    #endregion
    public EmploymentTypeQueryHandler(IEmploymentTypeService EmploymentTypeService, IMapper mapper)
    {
      _mapper = mapper;
      _EmploymentTypeService = EmploymentTypeService;
    }

    public async Task<Response<GetEmploymentTypeByIdResult>> Handle(GetEmploymentTypeByIdQuery request, CancellationToken cancellationToken)
    {
      var EmploymentType = await _EmploymentTypeService.GetEmploymentTypeByIdAsync(request.Id);


      if (EmploymentType == null)
      {
        return NotFound<GetEmploymentTypeByIdResult>("EmploymentType Not Found");
      }
      else
      {
        var EmploymentTypeMapper = _mapper.Map<GetEmploymentTypeByIdResult>(EmploymentType);
        return Success(EmploymentTypeMapper);
      }
    }

    public async Task<Response<List<GetEmploymentTypeByIdResult>>> Handle(GetEmploymentTypeListQuery request, CancellationToken cancellationToken)
    {
      var EmploymentTypeList = await _EmploymentTypeService.GetEmploymentTypesListAsync();

      var EmploymentTypeListMapper = _mapper.Map<List<GetEmploymentTypeByIdResult>>(EmploymentTypeList);

      return Success(EmploymentTypeListMapper);
    }
  }
}
