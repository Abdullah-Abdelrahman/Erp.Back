using AutoMapper;
using Erp.Core.Features.JournalEntry.Commands.Models;
using Erp.Data.Dto.JournalEntry;
using Erp.Data.MetaData;
using Erp.Service.Abstracts.AccountsModule;
using MediatR;
using Name.Core.Bases;

namespace Erp.Core.Features.JournalEntry.Commands.Handlers
{
  public class JournalEntryCommandHandler : ResponseHandler,
    IRequestHandler<AddJournalEntryCommand, Response<string>>,
    IRequestHandler<EditJournalEntryCommand, Response<string>>,
  IRequestHandler<DeleteJournalEntryCommand, Response<string>>


  {

    private readonly IJournalEntryService _JournalEntryService;
    private readonly IMapper _mapper;

    public JournalEntryCommandHandler(IJournalEntryService JournalEntryService, IMapper mapper)
    {
      _JournalEntryService = JournalEntryService;
      _mapper = mapper;
    }

    public async Task<Response<string>> Handle(AddJournalEntryCommand request, CancellationToken cancellationToken)
    {
      var AddJournalEntryRequestMapper = _mapper.Map<AddJournalEntryRequest>(request);
      var result = await _JournalEntryService.AddJournalEntry(AddJournalEntryRequestMapper);

      if (result == MessageCenter.CrudMessage.Success)
      {
        return Created<string>("Added successfuly");
      }
      else
      {
        return BadRequest<string>("Somthing bad happened");
      }
    }

    public async Task<Response<string>> Handle(EditJournalEntryCommand request, CancellationToken cancellationToken)
    {

      var EditJournalEntryRequestMapper = _mapper.Map<UpdateJournalEntryRequest>(request);
      var result = await _JournalEntryService.UpdateAsync(EditJournalEntryRequestMapper);

      if (result == MessageCenter.CrudMessage.Success)
      {
        return Created<string>("Updated successfuly");
      }
      else
      {
        return BadRequest<string>("Somthing bad happened");
      }


    }

    public async Task<Response<string>> Handle(DeleteJournalEntryCommand request, CancellationToken cancellationToken)
    {


      var result = await _JournalEntryService.DeleteByIdAsync(request.Id);

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
