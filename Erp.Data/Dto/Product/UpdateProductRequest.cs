using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Erp.Data.Dto.Product
{
  public class UpdateProductRequest
  {

    [Required]
    public int ProductId { get; set; }

    [Required]
    public string ProductName { get; set; } = null!;
    public string? Description { get; set; }

    [Required]
    public decimal PurchasePrice { get; set; }

    [Required]
    public decimal SellPrice { get; set; }

    public decimal LowestSellingPrice { get; set; }
    public int StockQuantity { get; set; }
    public int MinAmountBeforNotefy { get; set; }
    public string InternalNotes { get; set; } = string.Empty;
    public int? SupplierId { get; set; }
    public bool isActive { get; set; }

    public IFormFile? ImageFile { get; set; }

    public List<int> categoriesIds = new List<int>();
  }


}
