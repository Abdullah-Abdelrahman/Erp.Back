using AutoMapper;
using Erp.Core.Features.CreditNote.Commands.Models;
using Erp.Data.Dto.CreditNote;
using Erp.Data.MetaData;
using Erp.Service.Abstracts.SalesModule;
using MediatR;
using Name.Core.Bases;

namespace Erp.Core.Features.CreditNote.Commands.Handlers
{
  public class CreditNoteCommandHandler : ResponseHandler,
    IRequestHandler<AddCreditNoteCommand, Response<string>>,
    IRequestHandler<EditCreditNoteCommand, Response<string>>,
  IRequestHandler<DeleteCreditNoteCommand, Response<string>>


  {

    private readonly ICreditNoteService _CreditNoteService;
    private readonly IMapper _mapper;

    public CreditNoteCommandHandler(ICreditNoteService CreditNoteService, IMapper mapper)
    {
      _CreditNoteService = CreditNoteService;
      _mapper = mapper;
    }

    public async Task<Response<string>> Handle(AddCreditNoteCommand request, CancellationToken cancellationToken)
    {
      var AddCreditNoteRequestMapper = _mapper.Map<AddCreditNoteRequest>(request);
      var result = await _CreditNoteService.AddCreditNote(AddCreditNoteRequestMapper);

      if (result == MessageCenter.CrudMessage.Success)
      {
        return Created<string>("Added successfuly");
      }
      else
      {
        return BadRequest<string>("Somthing bad happened");
      }
    }

    public async Task<Response<string>> Handle(EditCreditNoteCommand request, CancellationToken cancellationToken)
    {

      var EditCreditNoteRequestMapper = _mapper.Map<UpdateCreditNoteRequest>(request);
      var result = await _CreditNoteService.UpdateAsync(EditCreditNoteRequestMapper);

      if (result == MessageCenter.CrudMessage.Success)
      {
        return Created<string>("Updated successfuly");
      }
      else
      {
        return BadRequest<string>("Somthing bad happened");
      }


    }

    public async Task<Response<string>> Handle(DeleteCreditNoteCommand request, CancellationToken cancellationToken)
    {


      var result = await _CreditNoteService.DeleteByIdAsync(request.Id);

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
