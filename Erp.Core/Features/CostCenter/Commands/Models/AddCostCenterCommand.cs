using Erp.Data.Entities.AccountsModule;
using MediatR;
using Name.Core.Bases;

namespace Erp.Core.Features.CostCenter.Commands.Models
{
  public class AddCostCenterCommand : IRequest<Response<string>>
  {


    public string CostCenterName { get; set; } = string.Empty;

    //Primary,Secondary
    public PrimaryOrSecondary PrimaryOrSecondary { get; set; }

    public int? ParentCostCenterID { get; set; }

    public bool IsActive { get; set; } = true;

    public DateTime CreatedDate { get; set; } = DateTime.UtcNow;

  }



}
