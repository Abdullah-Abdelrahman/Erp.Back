namespace Erp.Core.Features.Product.Queries.Results
{
  public class GetProductByIdResult
  {
    public int ProductId { get; set; }
    public string ProductName { get; set; } = null!;
    public string? Description { get; set; }
    public decimal Price { get; set; }
    public int StockQuantity { get; set; }
    public bool isActive { get; set; }
    public string? ImagePath { get; set; }
    public int CategoryId { get; set; }
    public string CategoryName { get; set; }

    //Image
    public byte[]? ImageFile { get; set; }

  }
}
