namespace Erp.Data.Dto.Customer
{
  public class GetCommercialCustomerByIdDto : GetCustomerByIdDto
  {
    public string? CommercialName { get; set; } = null!;

    public string? FirstName { get; set; } = null!;

    public string? LastName { get; set; } = null!;

    //سجل تجاري
    public string? Commercialregister { get; set; } = null!;

    //بطاقه ضريبيه
    public string? TaxCard { get; set; } = null!;
  }
}
