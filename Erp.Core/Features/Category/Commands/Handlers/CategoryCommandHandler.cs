using AutoMapper;
using Erp.Core.Features.Category.Commands.Models;
using Erp.Data.MetaData;
using Erp.Service.Abstracts;
using MediatR;
using Name.Core.Bases;
using Entitis = Erp.Data.Entities;
namespace Erp.Core.Features.Category.Commands.Handlers
{
  public class CategoryCommandHandler : ResponseHandler,
    IRequestHandler<AddCategoryCommand, Response<string>>,
    IRequestHandler<EditCategoryCommand, Response<string>>,
    IRequestHandler<DeleteCategoryCommand, Response<string>>


  {
    private readonly ICategoryService _categoryService;
    private readonly IMapper _mapper;

    public CategoryCommandHandler(ICategoryService categoryService, IMapper mapper)
    {
      _categoryService = categoryService;
      _mapper = mapper;
    }

    public async Task<Response<string>> Handle(AddCategoryCommand request, CancellationToken cancellationToken)
    {
      var CategoryMapper = _mapper.Map<Entitis.InventoryModule.Category>(request);
      var result = await _categoryService.AddCategoryAsync(CategoryMapper);

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

    public async Task<Response<string>> Handle(EditCategoryCommand request, CancellationToken cancellationToken)
    {
      var CategoryMapper = _mapper.Map<Entitis.InventoryModule.Category>(request);
      var result = await _categoryService.UpdateAsync(CategoryMapper);

      if (result == MessageCenter.CrudMessage.Success)
      {
        return Created<string>("Updated successfuly");
      }
      else
      {
        return BadRequest<string>("Somthing bad happened");
      }
    }

    public async Task<Response<string>> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
    {
      var Category = await _categoryService.GetCategoryByIdAsync(request.CategoryId);
      var result = await _categoryService.DeleteAsync(Category);

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
