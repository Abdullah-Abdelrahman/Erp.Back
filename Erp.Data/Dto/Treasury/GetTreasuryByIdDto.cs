using Erp.Data.Entities.HumanResources.Staff;
using E = Erp.Data.Entities.HumanResources.Staff;
namespace Erp.Data.Dto.Treasury
{
  public class GetTreasuryByIdDto
  {
    public int Id { get; set; }

    public string Name { get; set; }


    public string Description { get; set; }


    public bool IsActive { get; set; } = true;



    public WhoHaveType DepositPermission { get; set; } = WhoHaveType.None;
    public WhoHaveType WithdrawPermission { get; set; } = WhoHaveType.None;

    public ICollection<Employee> employeesWhoHaveDepositPermessions { get; set; } = new List<Employee>();
    public ICollection<E.ApplicationRole> RolesWhoHaveWithdrawPermessions { get; set; } = new List<E.ApplicationRole>();
    public ICollection<Employee> employeesWhoHaveWithdrawPermessions { get; set; } = new List<Employee>();

    public ICollection<E.ApplicationRole> RolesWhoHaveDepositPermessions { get; set; } = new List<E.ApplicationRole>();
  }



}
