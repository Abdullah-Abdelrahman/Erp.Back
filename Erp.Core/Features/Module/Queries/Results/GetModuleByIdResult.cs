namespace Erp.Core.Features.Module.Queries.Results
{
  public class GetModuleByIdResult
  {

    public int ModuleID { get; set; }


    public string Name { get; set; }

    public string Description { get; set; }

    public bool IsActive { get; set; }
    public DateTime CreatedDate { get; set; }

    public ICollection<string> ClaimList { get; set; } = new List<string>();
  }
}
