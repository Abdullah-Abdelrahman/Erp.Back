using AutoMapper;
using Erp.Core.Features.EmploymentLevel.Commands.Models;
using Erp.Data.MetaData;
using Erp.Service.Abstracts.HumanResources.OrganizationalStructure;
using MediatR;
using Name.Core.Bases;
using Entitis = Erp.Data.Entities;
namespace Erp.Core.Features.EmploymentLevel.Commands.Handlers
{
  public class EmploymentLevelCommandHandler : ResponseHandler,
    IRequestHandler<AddEmploymentLevelCommand, Response<string>>,
    IRequestHandler<EditEmploymentLevelCommand, Response<string>>,
    IRequestHandler<DeleteEmploymentLevelCommand, Response<string>>


  {
    private readonly IEmploymentLevelService _EmploymentLevelService;
    private readonly IMapper _mapper;

    public EmploymentLevelCommandHandler(IEmploymentLevelService EmploymentLevelService, IMapper mapper)
    {
      _EmploymentLevelService = EmploymentLevelService;
      _mapper = mapper;
    }

    public async Task<Response<string>> Handle(AddEmploymentLevelCommand request, CancellationToken cancellationToken)
    {
      var EmploymentLevelMapper = _mapper.Map<Entitis.HumanResources.OrganizationalStructure.EmploymentLevel>(request);
      var result = await _EmploymentLevelService.AddEmploymentLevelAsync(EmploymentLevelMapper);

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

    public async Task<Response<string>> Handle(EditEmploymentLevelCommand request, CancellationToken cancellationToken)
    {
      var EmploymentLevelMapper = _mapper.Map<Entitis.HumanResources.OrganizationalStructure.EmploymentLevel>(request);
      var result = await _EmploymentLevelService.UpdateAsync(EmploymentLevelMapper);

      if (result == MessageCenter.CrudMessage.Success)
      {
        return Created<string>("Updated successfuly");
      }
      else
      {
        return BadRequest<string>("Somthing bad happened");
      }
    }

    public async Task<Response<string>> Handle(DeleteEmploymentLevelCommand request, CancellationToken cancellationToken)
    {
      var EmploymentLevel = await _EmploymentLevelService.GetEmploymentLevelByIdAsync(request.EmploymentLevelId);
      var result = await _EmploymentLevelService.DeleteAsync(EmploymentLevel);

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
