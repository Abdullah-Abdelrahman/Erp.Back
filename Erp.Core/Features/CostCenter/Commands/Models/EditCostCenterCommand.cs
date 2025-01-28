using MediatR;
using Name.Core.Bases;

namespace Erp.Core.Features.CostCenter.Commands.Models
{
  public class EditCostCenterCommand : IRequest<Response<string>>
  {
    public int CostCenterID { get; set; }

    public string CostCenterName { get; set; } = string.Empty;


    public int? ParentCostCenterID { get; set; }

    public bool IsActive { get; set; } = true;

    public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
  }
}
