using MediatR;
using Name.Core.Bases;

namespace Erp.Core.Features.ContactList.Commands.Models
{
  public class EditContactListCommand : IRequest<Response<string>>
  {
    public int ContactListId { get; set; }
    public string? FirstName { get; set; } = null!;

    public string? LastName { get; set; } = null!;

    public string? PhoneNumber { get; set; } = null!;
    //هاتف ارضي
    public string? Landline { get; set; } = null!;


    public string? Email { get; set; }

    public int CustomerId { get; set; }


  }
}
