using AutoMapper;
using Erp.Core.Features.Quotation.Commands.Models;
using Erp.Data.Dto.Quotation;
using Erp.Data.MetaData;
using Erp.Service.Abstracts.SalesModule;
using MediatR;
using Name.Core.Bases;

namespace Erp.Core.Features.Quotation.Commands.Handlers
{
  public class QuotationCommandHandler : ResponseHandler,
    IRequestHandler<AddQuotationCommand, Response<string>>,
    IRequestHandler<EditQuotationCommand, Response<string>>,
  IRequestHandler<DeleteQuotationCommand, Response<string>>


  {

    private readonly IQuotationService _QuotationService;
    private readonly IMapper _mapper;

    public QuotationCommandHandler(IQuotationService QuotationService, IMapper mapper)
    {
      _QuotationService = QuotationService;
      _mapper = mapper;
    }

    public async Task<Response<string>> Handle(AddQuotationCommand request, CancellationToken cancellationToken)
    {
      var AddQuotationRequestMapper = _mapper.Map<AddQuotationRequest>(request);
      var result = await _QuotationService.AddQuotation(AddQuotationRequestMapper);

      if (result == MessageCenter.CrudMessage.Success)
      {
        return Created<string>("Added successfuly");
      }
      else
      {
        return BadRequest<string>("Somthing bad happened");
      }
    }

    public async Task<Response<string>> Handle(EditQuotationCommand request, CancellationToken cancellationToken)
    {

      var EditQuotationRequestMapper = _mapper.Map<UpdateQuotationRequest>(request);
      var result = await _QuotationService.UpdateAsync(EditQuotationRequestMapper);

      if (result == MessageCenter.CrudMessage.Success)
      {
        return Created<string>("Updated successfuly");
      }
      else
      {
        return BadRequest<string>("Somthing bad happened");
      }


    }

    public async Task<Response<string>> Handle(DeleteQuotationCommand request, CancellationToken cancellationToken)
    {


      var result = await _QuotationService.DeleteByIdAsync(request.Id);

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
