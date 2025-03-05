using Erp.Data.Dto.Product;
using MediatR;
using Name.Core.Bases;

namespace Erp.Core.Features.ProductAndService.Commands.Models
{
  public class EditProductCommand : UpdateProductRequest, IRequest<Response<string>>
  {


  }
}
