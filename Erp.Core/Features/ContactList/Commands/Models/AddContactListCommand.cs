using MediatR;
using Name.Core.Bases;

namespace Erp.Core.Features.ContactList.Commands.Models
{
  public class AddContactListCommand : IRequest<Response<string>>
  {

    public string? FirstName { get; set; } = null!;

    public string? LastName { get; set; } = null!;

    public string? PhoneNumber { get; set; } = null!;
    //هاتف ارضي
    public string? Landline { get; set; } = null!;


    public string? Email { get; set; }

    public int CustomerId { get; set; }


  }
}
