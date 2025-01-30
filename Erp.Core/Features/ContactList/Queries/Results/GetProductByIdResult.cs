using Entitis = Erp.Data.Entities;

namespace Erp.Core.Features.ContactList.Queries.Results
{
  public class GetContactListByIdResult
  {
    public int ContactListId { get; set; }
    public string? FirstName { get; set; } = null!;

    public string? LastName { get; set; } = null!;

    public string? PhoneNumber { get; set; } = null!;
    //هاتف ارضي
    public string? Landline { get; set; } = null!;


    public string? Email { get; set; }


    public Entitis.CustomersModule.Customer Customer { get; set; }


  }
}
