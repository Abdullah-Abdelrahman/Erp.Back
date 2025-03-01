using AutoMapper;
using Erp.Core.Features.ReceiptCategory.Commands.Models;
using Erp.Data.MetaData;
using Erp.Service.Abstracts.Finance;
using MediatR;
using Name.Core.Bases;
using Entitis = Erp.Data.Entities;
namespace Erp.Core.Features.ReceiptCategory.Commands.Handlers
{
  public class ReceiptCategoryCommandHandler : ResponseHandler,
    IRequestHandler<AddReceiptCategoryCommand, Response<string>>,
    IRequestHandler<EditReceiptCategoryCommand, Response<string>>,
    IRequestHandler<DeleteReceiptCategoryCommand, Response<string>>


  {
    private readonly IReceiptCategoryService _ReceiptCategoryService;
    private readonly IMapper _mapper;

    public ReceiptCategoryCommandHandler(IReceiptCategoryService ReceiptCategoryService, IMapper mapper)
    {
      _ReceiptCategoryService = ReceiptCategoryService;
      _mapper = mapper;
    }

    public async Task<Response<string>> Handle(AddReceiptCategoryCommand request, CancellationToken cancellationToken)
    {
      var ReceiptCategoryMapper = _mapper.Map<Entitis.Finance.ReceiptCategory>(request);
      var result = await _ReceiptCategoryService.AddReceiptCategoryAsync(ReceiptCategoryMapper);

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
        return BadRequest<string>("Somthing bad happened");
      }
    }

    public async Task<Response<string>> Handle(EditReceiptCategoryCommand request, CancellationToken cancellationToken)
    {
      var ReceiptCategoryMapper = _mapper.Map<Entitis.Finance.ReceiptCategory>(request);
      var result = await _ReceiptCategoryService.UpdateAsync(ReceiptCategoryMapper);

      if (result == MessageCenter.CrudMessage.Success)
      {
        return Created<string>("Updated successfuly");
      }
      else
      {
        return BadRequest<string>("Somthing bad happened");
      }
    }

    public async Task<Response<string>> Handle(DeleteReceiptCategoryCommand request, CancellationToken cancellationToken)
    {
      var ReceiptCategory = await _ReceiptCategoryService.GetReceiptCategoryByIdAsync(request.ReceiptCategoryId);
      var result = await _ReceiptCategoryService.DeleteAsync(ReceiptCategory);

      if (result == MessageCenter.CrudMessage.Success)
      {
        return Created<string>("Deleted successfuly");
      }
      else
      {
        return BadRequest<string>("Somthing bad happened");
      }
    }
  }
}
