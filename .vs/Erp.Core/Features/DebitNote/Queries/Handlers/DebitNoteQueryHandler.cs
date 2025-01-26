using AutoMapper;
using Erp.Core.Features.DebitNote.Queries.Models;
using Erp.Data.Dto.DebitNote;
using Erp.Service.Abstracts;
using MediatR;
using Name.Core.Bases;

namespace Erp.Core.Features.DebitNote.Queries.Handlers
{
  public class DebitNoteQueryHandler : ResponseHandler,
    IRequestHandler<GetDebitNoteByIdQuery, Response<GetDebitNoteByIdDto>>,
    IRequestHandler<GetDebitNoteListQuery, Response<List<GetDebitNoteByIdDto>>>
  {
    private readonly IDebitNoteService _DebitNoteService;
    private readonly IMapper _mapper;


    public DebitNoteQueryHandler(IDebitNoteService DebitNoteService, IMapper mapper)
    {
      _DebitNoteService = DebitNoteService;
      _mapper = mapper;
    }



    public async Task<Response<List<GetDebitNoteByIdDto>>> Handle(GetDebitNoteListQuery request, CancellationToken cancellationToken)
    {
      var DebitNotes = await _DebitNoteService.GetDebitNotesListAsync();


      return Success(DebitNotes);

    }

    public async Task<Response<GetDebitNoteByIdDto>> Handle(GetDebitNoteByIdQuery request, CancellationToken cancellationToken)
    {
      var DebitNote = await _DebitNoteService.GetDebitNoteByIdAsync(request.Id);


      if (DebitNote == null)
      {
        return NotFound<GetDebitNoteByIdDto>("DebitNote Not Found");
      }
      else
      {

        return Success(DebitNote);
      }
    }
  }
}
