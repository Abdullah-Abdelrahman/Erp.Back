using AutoMapper;
using Erp.Core.Features.Company.Commands.Models;
using Erp.Data.MetaData;
using Erp.Service.Abstracts.MainModule;
using MediatR;
using Name.Core.Bases;
using Entitis = Erp.Data.Entities;
namespace Erp.Core.Features.Company.Commands.Handlers
{

  public class CompanyCommandHandler : ResponseHandler,
    IRequestHandler<AddCompanyCommand, Response<string>>,
     IRequestHandler<EditCompanyCommand, Response<string>>,
     IRequestHandler<DeleteCompanyCommand, Response<string>>
  {
    private readonly ICompanyService _CompanyService;
    private readonly IMapper _mapper;

    public CompanyCommandHandler(ICompanyService CompanyService, IMapper mapper)
    {
      _CompanyService = CompanyService;
      _mapper = mapper;
    }

    public async Task<Response<string>> Handle(AddCompanyCommand request, CancellationToken cancellationToken)
    {
      var CompanyMapper = _mapper.Map<Entitis.MainModule.Company>(request);
      var result = await _CompanyService.AddCompanyAsync(CompanyMapper);

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
        return BadRequest<string>("Somthing bad happened :" + result);
      }
    }

    public async Task<Response<string>> Handle(EditCompanyCommand request, CancellationToken cancellationToken)
    {
      var CompanyMapper = _mapper.Map<Entitis.MainModule.Company>(request);
      var result = await _CompanyService.UpdateAsync(CompanyMapper);

      if (result == MessageCenter.CrudMessage.Success)
      {
        return Created<string>("Updated successfuly");
      }
      else
      {
        return BadRequest<string>("Somthing bad happened");
      }
    }

    public async Task<Response<string>> Handle(DeleteCompanyCommand request, CancellationToken cancellationToken)
    {
      var CompanyInDB = await _CompanyService.GetCompanyByIdAsync(request.Id);


      if (CompanyInDB == null)
      {
        return NotFound<string>("There is no Company with this id");
      }
      else
      {

        var result = await _CompanyService.DeleteAsync(CompanyInDB);

        if (result == MessageCenter.CrudMessage.Success)
        {
          return Deleted<string>();
        }
        else
        {
          return BadRequest<string>("Somthing bad happened");
        }



      }
    }
  }
}

