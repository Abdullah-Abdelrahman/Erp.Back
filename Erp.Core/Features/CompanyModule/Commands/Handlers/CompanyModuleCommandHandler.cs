using AutoMapper;
using Erp.Core.Features.CompanyModule.Commands.Models;
using Erp.Data.MetaData;
using Erp.Service.Abstracts.MainModule;
using MediatR;
using Name.Core.Bases;
namespace Erp.Core.Features.CompanyModule.Commands.Handlers
{
  public class CompanyModuleCommandHandler : ResponseHandler,
    IRequestHandler<ActivateModuleCommand, Response<string>>,
    IRequestHandler<DeActivateModuleCommand, Response<string>>


  {
    private readonly ICompanyModuleService _CompanyModuleService;
    private readonly IMapper _mapper;

    public CompanyModuleCommandHandler(ICompanyModuleService CompanyModuleService, IMapper mapper)
    {
      _CompanyModuleService = CompanyModuleService;
      _mapper = mapper;
    }

    public async Task<Response<string>> Handle(ActivateModuleCommand request, CancellationToken cancellationToken)
    {
      var result = await _CompanyModuleService.ActivateModuleAsync(request.ModelId);


      if (result == MessageCenter.CrudMessage.Success)
      {
        return Created<string>("Added successfuly");
      }
      else
      {
        return BadRequest<string>("Somthing bad happened :" + result);
      }
    }

    public async Task<Response<string>> Handle(DeActivateModuleCommand request, CancellationToken cancellationToken)
    {
      var result = await _CompanyModuleService.DeActivateModuleAsync(request.ModelId);


      if (result == MessageCenter.CrudMessage.Success)
      {
        return Created<string>("Added successfuly");
      }
      else
      {
        return BadRequest<string>("Somthing bad happened :" + result);
      }
    }
  }
}
