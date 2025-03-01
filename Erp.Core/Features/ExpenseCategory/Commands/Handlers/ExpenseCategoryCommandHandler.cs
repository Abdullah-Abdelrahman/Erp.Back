using AutoMapper;
using Erp.Core.Features.ExpenseCategory.Commands.Models;
using Erp.Data.MetaData;
using Erp.Service.Abstracts.Finance;
using MediatR;
using Name.Core.Bases;
using Entitis = Erp.Data.Entities;
namespace Erp.Core.Features.ExpenseCategory.Commands.Handlers
{
  public class ExpenseCategoryCommandHandler : ResponseHandler,
    IRequestHandler<AddExpenseCategoryCommand, Response<string>>,
    IRequestHandler<EditExpenseCategoryCommand, Response<string>>,
    IRequestHandler<DeleteExpenseCategoryCommand, Response<string>>


  {
    private readonly IExpenseCategoryService _ExpenseCategoryService;
    private readonly IMapper _mapper;

    public ExpenseCategoryCommandHandler(IExpenseCategoryService ExpenseCategoryService, IMapper mapper)
    {
      _ExpenseCategoryService = ExpenseCategoryService;
      _mapper = mapper;
    }

    public async Task<Response<string>> Handle(AddExpenseCategoryCommand request, CancellationToken cancellationToken)
    {
      var ExpenseCategoryMapper = _mapper.Map<Entitis.Finance.ExpenseCategory>(request);
      var result = await _ExpenseCategoryService.AddExpenseCategoryAsync(ExpenseCategoryMapper);

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

    public async Task<Response<string>> Handle(EditExpenseCategoryCommand request, CancellationToken cancellationToken)
    {
      var ExpenseCategoryMapper = _mapper.Map<Entitis.Finance.ExpenseCategory>(request);
      var result = await _ExpenseCategoryService.UpdateAsync(ExpenseCategoryMapper);

      if (result == MessageCenter.CrudMessage.Success)
      {
        return Created<string>("Updated successfuly");
      }
      else
      {
        return BadRequest<string>("Somthing bad happened");
      }
    }

    public async Task<Response<string>> Handle(DeleteExpenseCategoryCommand request, CancellationToken cancellationToken)
    {
      var ExpenseCategory = await _ExpenseCategoryService.GetExpenseCategoryByIdAsync(request.ExpenseCategoryId);
      var result = await _ExpenseCategoryService.DeleteAsync(ExpenseCategory);

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
