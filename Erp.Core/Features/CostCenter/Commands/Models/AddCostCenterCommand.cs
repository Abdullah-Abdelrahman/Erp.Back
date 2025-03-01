using Erp.Data.Entities.AccountsModule;
using MediatR;
using Name.Core.Bases;
using System.ComponentModel.DataAnnotations;

namespace Erp.Core.Features.CostCenter.Commands.Models
{
  public class AddCostCenterCommand : IRequest<Response<string>>
  {

    [Required]
    public string CostCenterName { get; set; }

    //Primary,Secondary
    public PrimaryOrSecondary PrimaryOrSecondary { get; set; }

    public int? ParentCostCenterID { get; set; }

    public bool IsActive { get; set; } = true;

    public DateTime CreatedDate { get; set; } = DateTime.UtcNow;

  }



}
