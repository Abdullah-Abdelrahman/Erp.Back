using AutoMapper;
using Erp.Core.Features.CreditNote.Queries.Models;
using Erp.Data.Dto.CreditNote;
using Erp.Service.Abstracts.SalesModule;
using MediatR;
using Name.Core.Bases;

namespace Erp.Core.Features.CreditNote.Queries.Handlers
{
  public class CreditNoteQueryHandler : ResponseHandler,
    IRequestHandler<GetCreditNoteByIdQuery, Response<GetCreditNoteByIdDto>>,
    IRequestHandler<GetCreditNoteListQuery, Response<List<GetCreditNoteByIdDto>>>
  {
    private readonly ICreditNoteService _CreditNoteService;
    private readonly IMapper _mapper;


    public CreditNoteQueryHandler(ICreditNoteService CreditNoteService, IMapper mapper)
    {
      _CreditNoteService = CreditNoteService;
      _mapper = mapper;
    }



    public async Task<Response<List<GetCreditNoteByIdDto>>> Handle(GetCreditNoteListQuery request, CancellationToken cancellationToken)
    {
      var CreditNotes = await _CreditNoteService.GetCreditNotesListAsync();


      return Success(CreditNotes);

    }

    public async Task<Response<GetCreditNoteByIdDto>> Handle(GetCreditNoteByIdQuery request, CancellationToken cancellationToken)
    {
      var CreditNote = await _CreditNoteService.GetCreditNoteByIdAsync(request.Id);


      if (CreditNote == null)
      {
        return NotFound<GetCreditNoteByIdDto>("CreditNote Not Found");
      }
      else
      {

        return Success(CreditNote);
      }
    }
  }
}
