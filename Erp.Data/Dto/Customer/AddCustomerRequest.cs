using Erp.Data.Entities.CustomersModule;

namespace Erp.Data.Dto.Customer
{
  public class AddCustomerRequest
  {
    public string? PhoneNumber { get; set; } = null!;
    //هاتف ارضي
    public string? Landline { get; set; } = null!;

    public string? StreetAddress1 { get; set; }

    public string? StreetAddress2 { get; set; }
    public string? City { get; set; }

    //المنطقه
    public string? zone { get; set; }
    public string? postcode { get; set; }

    public string? Country { get; set; }

    public BillingMethod billingMethod { get; set; }
    public CommercialOrIndividual commercialOrIndividual { get; set; }
    public string? Email { get; set; }

    public int? ClassificationId { get; set; }

    public string? Notes { get; set; }

    public List<AddContactListDT0> contactListDT0s { get; set; } = new List<AddContactListDT0>();


    //for CommercialCustomer
    public string? CommercialName { get; set; } = null!;

    public string? FirstName { get; set; } = null!;

    public string? LastName { get; set; } = null!;

    //سجل تجاري
    public string? Commercialregister { get; set; } = null!;

    //بطاقه ضريبيه
    public string? TaxCard { get; set; } = null!;

    //for IndividualCustomer

    public string? FullName { get; set; } = null!;
  }


  public class AddContactListDT0
  {


    public string? FirstName { get; set; } = null!;

    public string? LastName { get; set; } = null!;

    public string? PhoneNumber { get; set; } = null!;
    //هاتف ارضي
    public string? Landline { get; set; } = null!;


    public string? Email { get; set; }


  }
}
