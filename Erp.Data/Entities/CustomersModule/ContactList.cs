using System.ComponentModel.DataAnnotations.Schema;

namespace Erp.Data.Entities.CustomersModule
{
  //قاءمه اتصال
  public class ContactList
  {
    public int ContactListId { get; set; }
    public string? FirstName { get; set; } = null!;

    public string? LastName { get; set; } = null!;

    public string? PhoneNumber { get; set; } = null!;
    //هاتف ارضي
    public string? Landline { get; set; } = null!;


    public string? Email { get; set; }

    public int CustomerId { get; set; }
    [ForeignKey("CustomerId")]
    public Customer Customer { get; set; }


  }
}
