using AutoMapper;
using Erp.Core.Features.CostCenter.Commands.Models;
using Erp.Data.Entities.AccountsModule;
using Erp.Data.MetaData;
using Erp.Service.Abstracts.CostCentersModule;
using MediatR;
using Name.Core.Bases;
using Entitis = Erp.Data.Entities;
namespace Erp.Core.Features.CostCenter.Commands.Handlers
{

  public class CostCenterCommandHandler : ResponseHandler,
    IRequestHandler<AddCostCenterCommand, Response<string>>,
     IRequestHandler<EditCostCenterCommand, Response<string>>,
     IRequestHandler<DeleteCostCenterCommand, Response<string>>
  {
    private readonly ICostCenterService _CostCenterService;
    private readonly IMapper _mapper;

    public CostCenterCommandHandler(ICostCenterService CostCenterService, IMapper mapper)
    {
      _CostCenterService = CostCenterService;
      _mapper = mapper;
    }

    public async Task<Response<string>> Handle(AddCostCenterCommand request, CancellationToken cancellationToken)
    {

      Entitis.AccountsModule.CostCenter CostCenterMapper = null!;
      switch (request.PrimaryOrSecondary)
      {
        case PrimaryOrSecondary.Primary:
          CostCenterMapper = _mapper.Map<PrimaryCostCenter>(request);
          break;
        case PrimaryOrSecondary.Secondary:
          CostCenterMapper = _mapper.Map<SecondaryCostCenter>(request);
          break;
        default:
          return new Response<string>("Unknown CostCenter type");
      }

      var result = await _CostCenterService.AddCostCenterAsync(CostCenterMapper);

      if (result == MessageCenter.CrudMessage.Exist)
      {
        return UnprocessableEntity<string>("Exist Befor");
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

    public async Task<Response<string>> Handle(EditCostCenterCommand request, CancellationToken cancellationToken)
    {
      var CostCenterMapper = _mapper.Map<Entitis.AccountsModule.CostCenter>(request);
      var result = await _CostCenterService.UpdateCostCenterAsync(CostCenterMapper);

      if (result == MessageCenter.CrudMessage.Success)
      {
        return Created<string>("Updated successfuly");
      }
      else
      {
        return BadRequest<string>("Somthing bad happened");
      }
    }

    public async Task<Response<string>> Handle(DeleteCostCenterCommand request, CancellationToken cancellationToken)
    {
      var CostCenterInDB = await _CostCenterService.GetCostCenterByIdAsync(request.Id);


      if (CostCenterInDB == null)
      {
        return NotFound<string>("There is no CostCenter with this id");
      }
      else
      {

        var result = await _CostCenterService.DeleteCostCenterAsync(CostCenterInDB.CostCenterId);

        if (result == MessageCenter.CrudMessage.Success)
        {
          return Deleted<string>();
        }
        else
        {
          return BadRequest<string>(MessageCenter.CrudMessage.Falied);
        }



      }
    }
  }
}

