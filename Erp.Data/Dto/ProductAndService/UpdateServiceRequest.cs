using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Erp.Data.Dto.ProductAndService
{
  public class UpdateServiceRequest
  {
    [Required]
    public int ServiceId { get; set; }

    [Required]
    public string ServiceName { get; set; } = null!;
    public string? Description { get; set; }

    [Required]
    public decimal PurchasePrice { get; set; }

    [Required]
    public decimal SellPrice { get; set; }

    public decimal LowestSellingPrice { get; set; }

    public string InternalNotes { get; set; } = string.Empty;

    public bool isActive { get; set; }

    public IFormFile? ImageFile { get; set; }

    public List<int> categoriesIds = new List<int>();
  }
}
