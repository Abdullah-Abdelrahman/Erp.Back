namespace Erp.Data.Dto.ApplicationRole
{
  public class AddApplicationRoleRequest
  {

    public string Name { get; set; } = null!;

    public List<string> Claims { get; set; } = new List<string>();
  }



}
