using Erp.Data.Dto.Product;
using MediatR;
using Name.Core.Bases;

namespace Erp.Core.Features.Product.Commands.Models
{
  public class EditProductCommand : UpdateProductRequest, IRequest<Response<string>>
  {


  }
}
