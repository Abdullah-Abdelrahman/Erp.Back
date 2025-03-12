namespace Erp.Data.Dto.ApplicationRole
{
  public class EditApplicationRoleRequest
  {
    public string RoleId { get; set; }
    public string Name { get; set; } = null!;

    public List<string> Claims { get; set; } = new List<string>();
  }
}
