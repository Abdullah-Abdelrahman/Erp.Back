using AutoMapper;
using Erp.Core.Features.ReceiptCategory.Queries.Models;
using Erp.Core.Features.ReceiptCategory.Queries.Results;
using Erp.Service.Abstracts.Finance;
using MediatR;
using Name.Core.Bases;

namespace Erp.Core.Features.ReceiptCategory.Queries.Handlers
{
  public class ReceiptCategoryQueryHandler : ResponseHandler, IRequestHandler<GetReceiptCategoryByIdQuery, Response<GetReceiptCategoryByIdResult>>, IRequestHandler<GetReceiptCategoryListQuery, Response<List<GetReceiptCategoryByIdResult>>>
  {
    #region Fields
    private readonly IReceiptCategoryService _ReceiptCategoryService;
    private readonly IMapper _mapper;
    #endregion
    public ReceiptCategoryQueryHandler(IReceiptCategoryService ReceiptCategoryService, IMapper mapper)
    {
      _mapper = mapper;
      _ReceiptCategoryService = ReceiptCategoryService;
    }

    public async Task<Response<GetReceiptCategoryByIdResult>> Handle(GetReceiptCategoryByIdQuery request, CancellationToken cancellationToken)
    {
      var ReceiptCategory = await _ReceiptCategoryService.GetReceiptCategoryByIdAsync(request.Id);


      if (ReceiptCategory == null)
      {
        return NotFound<GetReceiptCategoryByIdResult>("ReceiptCategory Not Found");
      }
      else
      {
        var ReceiptCategoryMapper = _mapper.Map<GetReceiptCategoryByIdResult>(ReceiptCategory);
        return Success(ReceiptCategoryMapper);
      }
    }

    public async Task<Response<List<GetReceiptCategoryByIdResult>>> Handle(GetReceiptCategoryListQuery request, CancellationToken cancellationToken)
    {
      var ReceiptCategoryList = await _ReceiptCategoryService.GetReceiptCategorysListAsync();

      var ReceiptCategoryListMapper = _mapper.Map<List<GetReceiptCategoryByIdResult>>(ReceiptCategoryList);

      return Success(ReceiptCategoryListMapper);
    }
  }
}
