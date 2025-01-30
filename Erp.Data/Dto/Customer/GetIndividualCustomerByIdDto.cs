namespace Erp.Data.Dto.Customer
{
  public class GetIndividualCustomerByIdDto : GetCustomerByIdDto
  {

    public string? FullName { get; set; } = null!;
  }
}
