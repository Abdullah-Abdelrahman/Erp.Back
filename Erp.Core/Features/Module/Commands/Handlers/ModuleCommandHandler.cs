using AutoMapper;
using Erp.Core.Features.Module.Commands.Models;
using Erp.Data.MetaData;
using Erp.Service.Abstracts.MainModule;
using MediatR;
using Name.Core.Bases;
using Entitis = Erp.Data.Entities;
namespace Erp.Core.Features.Module.Commands.Handlers
{
  public class ModuleCommandHandler : ResponseHandler,
    IRequestHandler<AddModuleCommand, Response<string>>,
    IRequestHandler<EditModuleCommand, Response<string>>,
    IRequestHandler<DeleteModuleCommand, Response<string>>


  {
    private readonly IModuleService _ModuleService;
    private readonly IMapper _mapper;

    public ModuleCommandHandler(IModuleService ModuleService, IMapper mapper)
    {
      _ModuleService = ModuleService;
      _mapper = mapper;
    }

    public async Task<Response<string>> Handle(AddModuleCommand request, CancellationToken cancellationToken)
    {
      var ModuleMapper = _mapper.Map<Entitis.MainModule.Module>(request);
      var result = await _ModuleService.AddModuleAsync(ModuleMapper);

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

    public async Task<Response<string>> Handle(EditModuleCommand request, CancellationToken cancellationToken)
    {
      var ModuleMapper = _mapper.Map<Entitis.MainModule.Module>(request);
      var result = await _ModuleService.UpdateAsync(ModuleMapper);

      if (result == MessageCenter.CrudMessage.Success)
      {
        return Created<string>("Updated successfuly");
      }
      else
      {
        return BadRequest<string>("Somthing bad happened");
      }
    }

    public async Task<Response<string>> Handle(DeleteModuleCommand request, CancellationToken cancellationToken)
    {
      var Module = await _ModuleService.GetModuleByIdAsync(request.ModuleId);
      var result = await _ModuleService.DeleteAsync(Module);

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
