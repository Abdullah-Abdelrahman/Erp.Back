using Erp.Data.Dto.Customer;

namespace Erp.Data.Entities.CustomersModule
{
  public class CommercialCustomer : Customer
  {
    public CommercialCustomer()
    {

    }
    public CommercialCustomer(AddCustomerRequest request) : base(request)
    {
      this.CommercialName = request.CommercialName;
      this.FirstName = request.FullName;
      this.LastName = request.LastName;
      this.Commercialregister = request.Commercialregister;
      this.TaxCard = request.TaxCard;
    }
    public CommercialCustomer(UpdateCustomerRequest request) : base(request)
    {
      this.CommercialName = request.CommercialName;
      this.FirstName = request.FullName;
      this.LastName = request.LastName;
      this.Commercialregister = request.Commercialregister;
      this.TaxCard = request.TaxCard;
    }
    public string CommercialName { get; set; } = null!;

    public string? FirstName { get; set; } = null!;

    public string? LastName { get; set; } = null!;

    //سجل تجاري
    public string? Commercialregister { get; set; } = null!;

    //بطاقه ضريبيه
    public string? TaxCard { get; set; } = null!;


  }
}
