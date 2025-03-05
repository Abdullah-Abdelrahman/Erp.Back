using Erp.Data.Entities.InventoryModule;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Erp.Data.Dto.ProductAndService
{
  public class AddServiceRequest
  {
    [Required]
    public string ServiceName { get; set; } = null!;

    public string? Description { get; set; }

    [Required]
    public decimal PurchasePrice { get; set; }

    [Required]
    public decimal SellPrice { get; set; }

    public decimal? LowestSellingPrice { get; set; }


    public string? InternalNotes { get; set; }

    [Required]
    public ProductStatus Status { get; set; }
    public IFormFile? ImageFile { get; set; }

    public List<int> categoriesIds { get; set; } = new List<int>();

    [JsonIgnore]
    public string? WebRootPath { get; set; }


  }
}
