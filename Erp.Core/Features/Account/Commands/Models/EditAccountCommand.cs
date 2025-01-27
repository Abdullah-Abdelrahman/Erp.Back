using Erp.Data.Entities.AccountsModule;
using MediatR;
using Name.Core.Bases;

namespace Erp.Core.Features.Account.Commands.Models
{
  public class EditAccountCommand : IRequest<Response<string>>
  {
    public int AccountID { get; set; }

    public string AccountName { get; set; } = string.Empty;
    //داءن او مدين
    public AccountType Type { get; set; }
    //Primary,Secondary

    public int? ParentAccountID { get; set; }

    public bool IsActive { get; set; } = true;

    public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
  }
}
