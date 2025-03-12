namespace Erp.Data.Dto.Customer
{
  public class GetCustomerListResponse
  {
    public int CustomerId { get; set; }
    public string? PhoneNumber { get; set; } = null!;

    public string? Email { get; set; }

    public int? ClassificationId { get; set; }
    public int AccountId { get; set; } // الحساب الفرعي (اختياري)

  }
}
