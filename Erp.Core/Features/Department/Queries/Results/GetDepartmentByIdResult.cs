namespace Erp.Core.Features.Department.Queries.Results
{
  public class GetDepartmentByIdResult
  {
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public bool IsActive { get; set; } = true;

    public int? DepartmentHeadID { get; set; }

  }
}
