using Erp.Data.Entities.CustomersModule;

namespace Erp.Data.Dto.Customer
{



  public class GetCustomerByIdDto
  {
    public int CustomerId { get; set; }
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

    public string? Email { get; set; }

    public int? ClassificationId { get; set; }

    public string? Notes { get; set; }
    public int AccountId { get; set; } // الحساب الفرعي (اختياري)

    public List<GetContactListDT0> contactListDT0s { get; set; } = new List<GetContactListDT0>();
  }

  public class GetContactListDT0
  {
    public int CustomerId { get; set; }

    public int ContactListId { get; set; }

    public string? FirstName { get; set; } = null!;

    public string? LastName { get; set; } = null!;

    public string? PhoneNumber { get; set; } = null!;
    //هاتف ارضي
    public string? Landline { get; set; } = null!;


    public string? Email { get; set; }

  }

}
