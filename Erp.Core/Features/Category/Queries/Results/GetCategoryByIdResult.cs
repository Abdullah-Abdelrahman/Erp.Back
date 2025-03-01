namespace Erp.Core.Features.Category.Queries.Results
{
  public class GetCategoryByIdResult
  {
    public int CategoryId { get; set; }
    public string CategoryName { get; set; } = null!;
    public int? MainCategoryId { get; set; }
    public string? ImagePath { get; set; }
    public byte[]? ImageFile { get; set; }

  }
}
