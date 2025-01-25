using MediatR;
using Microsoft.AspNetCore.Http;
using Name.Core.Bases;

namespace Erp.Core.Features.Product.Commands.Models
{
  public class EditProductCommand : IRequest<Response<string>>
  {
    public int ProductId { get; set; }
    public string ProductName { get; set; } = null!;
    public string? Description { get; set; }
    public decimal Price { get; set; }
    public int StockQuantity { get; set; }

    public IFormFile? ImageFile { get; set; }
    // Foreign Key
    public int CategoryId { get; set; }
  }
}
