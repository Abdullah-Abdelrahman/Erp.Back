using AutoMapper;
using Erp.Core.Features.JournalEntry.Queries.Models;
using Erp.Data.Dto.JournalEntry;
using Erp.Service.Abstracts.AccountsModule;
using MediatR;
using Name.Core.Bases;

namespace Erp.Core.Features.JournalEntry.Queries.Handlers
{
  public class JournalEntryQueryHandler : ResponseHandler,
    IRequestHandler<GetJournalEntryByIdQuery, Response<GetJournalEntryByIdDto>>,
    IRequestHandler<GetJournalEntryListQuery, Response<List<GetJournalEntryByIdDto>>>
  {
    private readonly IJournalEntryService _JournalEntryService;
    private readonly IMapper _mapper;


    public JournalEntryQueryHandler(IJournalEntryService JournalEntryService, IMapper mapper)
    {
      _JournalEntryService = JournalEntryService;
      _mapper = mapper;
    }



    public async Task<Response<List<GetJournalEntryByIdDto>>> Handle(GetJournalEntryListQuery request, CancellationToken cancellationToken)
    {
      var JournalEntrys = await _JournalEntryService.GetJournalEntrysListAsync();


      return Success(JournalEntrys);

    }

    public async Task<Response<GetJournalEntryByIdDto>> Handle(GetJournalEntryByIdQuery request, CancellationToken cancellationToken)
    {
      var JournalEntry = await _JournalEntryService.GetJournalEntryByIdAsync(request.Id);


      if (JournalEntry == null)
      {
        return NotFound<GetJournalEntryByIdDto>("JournalEntry Not Found");
      }
      else
      {

        return Success(JournalEntry);
      }
    }
  }
}
