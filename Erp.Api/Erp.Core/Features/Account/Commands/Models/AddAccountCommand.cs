using Erp.Data.Entities.AccountsModule;
using MediatR;
using Name.Core.Bases;

namespace Erp.Core.Features.Account.Commands.Models
{
  public class AddAccountCommand : IRequest<Response<string>>
  {


    public string AccountName { get; set; } = string.Empty;
    //داءن او مدين
    public AccountType Type { get; set; }
    //Primary,Secondary
    public PrimaryOrSecondary PrimaryOrSecondary { get; set; }

    public int? ParentAccountID { get; set; }

    public bool IsActive { get; set; } = true;

    public DateTime CreatedDate { get; set; } = DateTime.UtcNow;

  }



}
