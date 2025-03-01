using AutoMapper;
using Erp.Core.Features.Treasury.Queries.Models;
using Erp.Data.Dto.Treasury;
using Erp.Service.Abstracts.Finance;
using MediatR;
using Name.Core.Bases;

namespace Erp.Core.Features.Treasury.Queries.Handlers
{
  public class TreasuryQueryHandler : ResponseHandler,
    IRequestHandler<GetTreasuryByIdQuery, Response<GetTreasuryByIdDto>>,
    IRequestHandler<GetTreasuryListQuery, Response<List<GetTreasuryByIdDto>>>
  {
    private readonly ITreasuryService _TreasuryService;
    private readonly IMapper _mapper;


    public TreasuryQueryHandler(ITreasuryService TreasuryService, IMapper mapper)
    {
      _TreasuryService = TreasuryService;
      _mapper = mapper;
    }



    public async Task<Response<List<GetTreasuryByIdDto>>> Handle(GetTreasuryListQuery request, CancellationToken cancellationToken)
    {
      var Treasurys = await _TreasuryService.GetTreasurysListAsync();


      return Success(Treasurys);

    }

    public async Task<Response<GetTreasuryByIdDto>> Handle(GetTreasuryByIdQuery request, CancellationToken cancellationToken)
    {
      var Treasury = await _TreasuryService.GetTreasuryByIdAsync(request.Id);


      if (Treasury == null)
      {
        return NotFound<GetTreasuryByIdDto>("Treasury Not Found");
      }
      else
      {

        return Success(Treasury);
      }
    }
  }
}
