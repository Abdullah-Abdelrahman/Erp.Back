namespace Erp.Core.Features.JobType.Queries.Results
{
  public class GetJobTypeByIdResult
  {
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public int? DepartmentId { get; set; }

    public bool IsActive { get; set; } = true;


  }
}
