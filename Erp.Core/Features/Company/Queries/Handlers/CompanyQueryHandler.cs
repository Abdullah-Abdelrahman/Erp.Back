using AutoMapper;
using Erp.Core.Features.Company.Queries.Models;
using Erp.Core.Features.Company.Queries.Results;
using Erp.Service.Abstracts.MainModule;
using MediatR;
using Name.Core.Bases;

namespace Erp.Core.Features.Company.Queries.Handlers
{
  public class CompanyQueryHandler : ResponseHandler, IRequestHandler<GetCompanyByIdQuery, Response<GetCompanyByIdResult>>, IRequestHandler<GetCompanyListQuery, Response<List<GetCompanyByIdResult>>>
  {
    #region Fields
    private readonly ICompanyService _CompanyService;

    private readonly IMapper _mapper;
    #endregion
    public CompanyQueryHandler(ICompanyService CompanyService, IMapper mapper)
    {
      _mapper = mapper;
      _CompanyService = CompanyService;
    }

    public async Task<Response<GetCompanyByIdResult>> Handle(GetCompanyByIdQuery request, CancellationToken cancellationToken)
    {
      var Company = await _CompanyService.GetCompanyByIdAsync(request.Id);


      if (Company == null)
      {
        return NotFound<GetCompanyByIdResult>("Company Not Found");
      }
      else
      {
        var CompanyMapper = _mapper.Map<GetCompanyByIdResult>(Company);
        return Success(CompanyMapper);
      }
    }

    public async Task<Response<List<GetCompanyByIdResult>>> Handle(GetCompanyListQuery request, CancellationToken cancellationToken)
    {
      var CompanyList = await _CompanyService.GetCompanysListAsync();

      var CompanyListMapper = _mapper.Map<List<GetCompanyByIdResult>>(CompanyList);

      return Success(CompanyListMapper);
    }
  }
}
