using AutoMapper;
using Erp.Core.Features.JobType.Queries.Models;
using Erp.Core.Features.JobType.Queries.Results;
using Erp.Service.Abstracts.HumanResources.OrganizationalStructure;
using MediatR;
using Name.Core.Bases;

namespace Erp.Core.Features.JobType.Queries.Handlers
{
  public class JobTypeQueryHandler : ResponseHandler, IRequestHandler<GetJobTypeByIdQuery, Response<GetJobTypeByIdResult>>, IRequestHandler<GetJobTypeListQuery, Response<List<GetJobTypeByIdResult>>>
  {
    #region Fields
    private readonly IJobTypeService _JobTypeService;
    private readonly IMapper _mapper;
    #endregion
    public JobTypeQueryHandler(IJobTypeService JobTypeService, IMapper mapper)
    {
      _mapper = mapper;
      _JobTypeService = JobTypeService;
    }

    public async Task<Response<GetJobTypeByIdResult>> Handle(GetJobTypeByIdQuery request, CancellationToken cancellationToken)
    {
      var JobType = await _JobTypeService.GetJobTypeByIdAsync(request.Id);


      if (JobType == null)
      {
        return NotFound<GetJobTypeByIdResult>("JobType Not Found");
      }
      else
      {
        var JobTypeMapper = _mapper.Map<GetJobTypeByIdResult>(JobType);
        return Success(JobTypeMapper);
      }
    }

    public async Task<Response<List<GetJobTypeByIdResult>>> Handle(GetJobTypeListQuery request, CancellationToken cancellationToken)
    {
      var JobTypeList = await _JobTypeService.GetJobTypesListAsync();

      var JobTypeListMapper = _mapper.Map<List<GetJobTypeByIdResult>>(JobTypeList);

      return Success(JobTypeListMapper);
    }
  }
}
