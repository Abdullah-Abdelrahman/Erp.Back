using AutoMapper;
using Erp.Core.Features.JobType.Commands.Models;
using Erp.Data.MetaData;
using Erp.Service.Abstracts.HumanResources.OrganizationalStructure;
using MediatR;
using Name.Core.Bases;
using Entitis = Erp.Data.Entities;
namespace Erp.Core.Features.JobType.Commands.Handlers
{
  public class JobTypeCommandHandler : ResponseHandler,
    IRequestHandler<AddJobTypeCommand, Response<string>>,
    IRequestHandler<EditJobTypeCommand, Response<string>>,
    IRequestHandler<DeleteJobTypeCommand, Response<string>>


  {
    private readonly IJobTypeService _JobTypeService;
    private readonly IMapper _mapper;

    public JobTypeCommandHandler(IJobTypeService JobTypeService, IMapper mapper)
    {
      _JobTypeService = JobTypeService;
      _mapper = mapper;
    }

    public async Task<Response<string>> Handle(AddJobTypeCommand request, CancellationToken cancellationToken)
    {
      var JobTypeMapper = _mapper.Map<Entitis.HumanResources.OrganizationalStructure.JobType>(request);
      var result = await _JobTypeService.AddJobTypeAsync(JobTypeMapper);

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

    public async Task<Response<string>> Handle(EditJobTypeCommand request, CancellationToken cancellationToken)
    {
      var JobTypeMapper = _mapper.Map<Entitis.HumanResources.OrganizationalStructure.JobType>(request);
      var result = await _JobTypeService.UpdateAsync(JobTypeMapper);

      if (result == MessageCenter.CrudMessage.Success)
      {
        return Created<string>("Updated successfuly");
      }
      else
      {
        return BadRequest<string>("Somthing bad happened");
      }
    }

    public async Task<Response<string>> Handle(DeleteJobTypeCommand request, CancellationToken cancellationToken)
    {
      var JobType = await _JobTypeService.GetJobTypeByIdAsync(request.JobTypeId);
      var result = await _JobTypeService.DeleteAsync(JobType);

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
