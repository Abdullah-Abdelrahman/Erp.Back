using MediatR;
using Microsoft.AspNetCore.Http;
using Name.Core.Bases;
using System.ComponentModel.DataAnnotations;

namespace Erp.Core.Features.Category.Commands.Models
{
  public class EditCategoryCommand : IRequest<Response<string>>
  {
    [Required]
    public int CategoryId { get; set; }

    [Required]
    public string CategoryName { get; set; } = null!;
    public int? MainCategoryId { get; set; }

    public IFormFile? ImageFile { get; set; }
  }
}
