using AutoMapper;
using Erp.Core.Features.Category.Queries.Models;
using Erp.Core.Features.Category.Queries.Results;
using Erp.Service.Abstracts;
using MediatR;
using Name.Core.Bases;

namespace Erp.Core.Features.Category.Queries.Handlers
{
  public class CategoryQueryHandler : ResponseHandler, IRequestHandler<GetCategoryByIdQuery, Response<GetCategoryByIdResult>>, IRequestHandler<GetCategoryListQuery, Response<List<GetCategoryByIdResult>>>
  {
    #region Fields
    private readonly ICategoryService _categoryService;
    private readonly IMapper _mapper;
    #endregion
    public CategoryQueryHandler(ICategoryService categoryService, IMapper mapper)
    {
      _mapper = mapper;
      _categoryService = categoryService;
    }

    public async Task<Response<GetCategoryByIdResult>> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
    {
      var Category = await _categoryService.GetCategoryByIdAsync(request.Id);


      if (Category == null)
      {
        return NotFound<GetCategoryByIdResult>("Category Not Found");
      }
      else
      {
        var CategoryMapper = _mapper.Map<GetCategoryByIdResult>(Category);
        return Success(CategoryMapper);
      }
    }

    public async Task<Response<List<GetCategoryByIdResult>>> Handle(GetCategoryListQuery request, CancellationToken cancellationToken)
    {
      var CategoryList = await _categoryService.GetCategorysListAsync();

      var CategoryListMapper = _mapper.Map<List<GetCategoryByIdResult>>(CategoryList);

      return Success(CategoryListMapper);
    }
  }
}
