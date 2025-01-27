using AutoMapper;
using Erp.Core.Features.DebitNote.Commands.Models;
using Erp.Data.Dto.DebitNote;
using Erp.Data.MetaData;
using Erp.Service.Abstracts;
using MediatR;
using Name.Core.Bases;

namespace Erp.Core.Features.DebitNote.Commands.Handlers
{
  public class DebitNoteCommandHandler : ResponseHandler,
    IRequestHandler<AddDebitNoteCommand, Response<string>>,
    IRequestHandler<EditDebitNoteCommand, Response<string>>,
  IRequestHandler<DeleteDebitNoteCommand, Response<string>>


  {

    private readonly IDebitNoteService _DebitNoteService;
    private readonly IMapper _mapper;

    public DebitNoteCommandHandler(IDebitNoteService DebitNoteService, IMapper mapper)
    {
      _DebitNoteService = DebitNoteService;
      _mapper = mapper;
    }

    public async Task<Response<string>> Handle(AddDebitNoteCommand request, CancellationToken cancellationToken)
    {
      var AddDebitNoteRequestMapper = _mapper.Map<AddDebitNoteRequest>(request);
      var result = await _DebitNoteService.AddDebitNote(AddDebitNoteRequestMapper);

      if (result == MessageCenter.CrudMessage.Success)
      {
        return Created<string>("Added successfuly");
      }
      else
      {
        return BadRequest<string>("Somthing bad happened");
      }
    }

    public async Task<Response<string>> Handle(EditDebitNoteCommand request, CancellationToken cancellationToken)
    {

      var EditDebitNoteRequestMapper = _mapper.Map<UpdateDebitNoteRequest>(request);
      var result = await _DebitNoteService.UpdateAsync(EditDebitNoteRequestMapper);

      if (result == MessageCenter.CrudMessage.Success)
      {
        return Created<string>("Updated successfuly");
      }
      else
      {
        return BadRequest<string>("Somthing bad happened");
      }


    }

    public async Task<Response<string>> Handle(DeleteDebitNoteCommand request, CancellationToken cancellationToken)
    {


      var result = await _DebitNoteService.DeleteByIdAsync(request.Id);

      if (result == MessageCenter.CrudMessage.Success)
      {
        return Deleted<string>();
      }
      else
      {
        return BadRequest<string>(result);
      }




    }



  }
}
