using MediatR;
using Microsoft.AspNetCore.Http;
using Name.Core.Bases;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Erp.Core.Features.Category.Commands.Models
{
  public class AddCategoryCommand : IRequest<Response<string>>
  {
    [Required]
    public string CategoryName { get; set; } = null!;
    public int? MainCategoryId { get; set; }

    public IFormFile? ImageFile { get; set; }


    [JsonIgnore]
    public string? WebRootPath { get; set; }
  }
}
