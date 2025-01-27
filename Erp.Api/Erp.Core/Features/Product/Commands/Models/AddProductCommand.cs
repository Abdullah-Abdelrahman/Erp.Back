using MediatR;
using Microsoft.AspNetCore.Http;
using Name.Core.Bases;
using System.Text.Json.Serialization;

namespace Erp.Core.Features.Product.Commands.Models
{
  public class AddProductCommand : IRequest<Response<string>>
  {
    public string ProductName { get; set; } = null!;

    public string? Description { get; set; }

    public decimal Price { get; set; }

    public int StockQuantity { get; set; }
    public bool isActive { get; set; }
    public IFormFile? ImageFile { get; set; }

    [JsonIgnore]
    public string? WebRootPath { get; set; }

    // Foreign Key
    public int CategoryId { get; set; }


  }
}
