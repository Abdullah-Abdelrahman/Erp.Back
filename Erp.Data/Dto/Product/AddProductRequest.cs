using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Erp.Data.Dto.Product
{
  public class AddProductRequest
  {
    [Required]
    public string ProductName { get; set; } = null!;

    public string? Description { get; set; }

    [Required]
    public decimal PurchasePrice { get; set; }

    [Required]
    public decimal SellPrice { get; set; }

    public decimal? LowestSellingPrice { get; set; }
    public int? StockQuantity { get; set; }
    public int? MinAmountBeforNotefy { get; set; }

    public string? InternalNotes { get; set; }
    public int? SupplierId { get; set; }
    [Required]
    public bool isActive { get; set; }
    public IFormFile? ImageFile { get; set; }

    public List<int> categoriesIds { get; set; } = new List<int>();

    [JsonIgnore]
    public string? WebRootPath { get; set; }


  }


}
